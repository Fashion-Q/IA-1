using BaseDeAnimais;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoologicoController : MonoBehaviour
{
    public BaseDeDados baseDeDados;
    [SerializeField]
    private List<GameObject> animaisObject;
    [SerializeField]
    private GameObject alcidez,tabelaNovoAnimal,menuNovoAnimal,menuAfterInsertedAnimal,tabelaInserirAnimal;
    private Animal newAnimal;
    private void Awake()
    {
        baseDeDados = new();
        for (int i = 0; i < animaisObject.Count; i++)
            animaisObject[i].GetComponent<IAnimal>().SetAnimal(baseDeDados.animais[i]);
        newAnimal = null;
        
    }

    public IALcides GetIALcides => alcidez.GetComponent<IALcides>();

    public void NormalizarNovoAnimal(Animal newAnimal, int kNN)
    {
        this.newAnimal = newAnimal;
        KNN = kNN;
        baseDeDados.NormalizarDados(this.newAnimal);
        animaisObject.Sort((animal1, animal2) => animal1.GetComponent<IAnimal>().
        GetAnimal().Proximidade.CompareTo(animal2.GetComponent<IAnimal>().GetAnimal().Proximidade));
        CalcularNormalizacao();
    }
    private void CalcularNormalizacao()
    {
        int carnivoro = 0, herbivoro = 0, onivoro = 0;
        for (int i = 0; i < KNN; i++)
        {
            if (animaisObject[i].GetComponent<IAnimal>().GetAnimal().Alimentacao.Equals("Carnívoro"))
                carnivoro++;
            else if (animaisObject[i].GetComponent<IAnimal>().GetAnimal().Alimentacao.Equals("Herbívoro"))
                herbivoro++;
            else
                onivoro++;
        }

        if (onivoro >= herbivoro && onivoro >= carnivoro)
        {
            newAnimal.Alimentacao = "Onívoro";
            newAnimal.AlimentacaoNormalized = 1f;
        }
        else if (herbivoro >= carnivoro && herbivoro >= onivoro)
        {
            newAnimal.Alimentacao = "Herbívoro";
            newAnimal.AlimentacaoNormalized = 0.5f;
        }
        else
        {
            newAnimal.Alimentacao = "Carnívoro";
            newAnimal.AlimentacaoNormalized = 0;
        }
        TextMeshProUGUI[] text = tabelaNovoAnimal.GetComponentsInChildren<TextMeshProUGUI>();
        text[0].text = newAnimal.HabitatNormalized.ToString("0.00");
        text[1].text = newAnimal.RevestimentoNormalized.ToString("0.00");
        text[2].text = newAnimal.TonalidadePeleNormalized.ToString("0.00");
        text[3].text = newAnimal.TamanhoNormalized.ToString("0.00");
        text[4].text = newAnimal.VelocidadeNormalized.ToString("0.00");
        text[5].text = newAnimal.NumeroDePatasNormalized.ToString("0.00");
        text[6].text = newAnimal.HabitoNoturnoNormalized.ToString("0.00");
        text[7].text = newAnimal.AlimentacaoNormalized.ToString("0.0");
        menuNovoAnimal.SetActive(true);
        menuAfterInsertedAnimal.SetActive(true);
        tabelaInserirAnimal.SetActive(false);
        CurrentIndexAnimal = 0;
        GetIALcides.SetAnimal(animaisObject[CurrentIndexAnimal++]);
    }

    public void Sair() => Application.Quit();
    public void ProximoAnimal()
    {
        if (GetIALcides.moveUpdate != null)
            return;
        if (CurrentIndexAnimal >= KNN || CurrentIndexAnimal >= animaisObject.Count)
            CurrentIndexAnimal = 0;
        GetIALcides.SetAnimal(animaisObject[CurrentIndexAnimal++]);
    }
    public void PararAnimal()
    {
        GetIALcides.moveUpdate = GetIALcides.GetMove.MoveAround;
        menuAfterInsertedAnimal.SetActive(false);
        tabelaInserirAnimal.SetActive(true);
        menuNovoAnimal.SetActive(false);
    }
    public int KNN { get; set; }
    public int CurrentIndexAnimal { get; set; }
}