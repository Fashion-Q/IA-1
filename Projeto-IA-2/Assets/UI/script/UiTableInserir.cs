using BaseDeAnimais;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiTableInserir : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ImagensEvent;
    [SerializeField]
    private TextMeshProUGUI numeroPatas,kNN;
    [SerializeField]
    private Button pesquisarButton;
    [SerializeField]
    private bool[] podePesquisar;
    [SerializeField]
    private GameObject menuInterface, zoologicoController,tabelaCaracteristicas;

    private void Start()
    {
        pesquisarButton.interactable = false;
    }
    public void HabitatTerrestre()
    {
        ImagensEvent[0].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Habitat = "Terrestre";
        ImagensEvent[1].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[2].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[0] = true;
        CheckPesquisar();
    }
    public void HabitatAquatico()
    {
        ImagensEvent[1].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Habitat = "Aquático";
        ImagensEvent[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[2].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[0] = true;
        CheckPesquisar();
    }
    public void HabitatAereo()
    {
        ImagensEvent[2].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Habitat = "Aéreo";
        ImagensEvent[1].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[0] = true;
        CheckPesquisar();
    }
    public void RevestimentoPelo()
    {
        ImagensEvent[3].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Revestimento = "Pelo";
        ImagensEvent[4].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[5].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[6].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[1] = true;
        CheckPesquisar();
    }
    public void RevestimentoEscama()
    {
        ImagensEvent[4].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Revestimento = "Escama";
        ImagensEvent[3].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[5].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[6].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[1] = true;
        CheckPesquisar();
    }
    public void RevestimentoPena()
    {
        ImagensEvent[5].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Revestimento = "Pena";
        ImagensEvent[3].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[4].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[6].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[1] = true;
        CheckPesquisar();
    }
    public void RevestimentoPele()
    {
        ImagensEvent[6].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Revestimento = "Pele";
        ImagensEvent[3].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[4].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[5].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[1] = true;
        CheckPesquisar();
    }
    public void TonalidadeClara()
    {
        ImagensEvent[7].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        TonalidadePele = true;
        ImagensEvent[8].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[2] = true;
        CheckPesquisar();
    }
    public void TonalidadeEscura()
    {
        ImagensEvent[8].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        TonalidadePele = false;
        ImagensEvent[7].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[2] = true;
        CheckPesquisar();
    }
    public void TamanhoPequeno()
    {
        ImagensEvent[9].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Tamanho = "Pequeno";
        ImagensEvent[10].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[11].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[3] = true;
        CheckPesquisar();
    }
    public void TamanhoMedio()
    {
        ImagensEvent[10].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Tamanho = "Médio";
        ImagensEvent[9].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[11].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[3] = true;
        CheckPesquisar();
    }
    public void TamanhoGrande()
    {
        ImagensEvent[11].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Tamanho = "Grande";
        ImagensEvent[9].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[10].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[3] = true;
        CheckPesquisar();
    }
    public void VelocidadeBaixa()
    {
        ImagensEvent[12].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Velocidade = "Baixa";
        ImagensEvent[13].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[14].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[4] = true;
        CheckPesquisar();
    }
    public void VelocidadeMedia()
    {
        ImagensEvent[13].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Velocidade = "Média";
        ImagensEvent[12].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[14].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[4] = true;
        CheckPesquisar();
    }
    public void VelocidadeAlta()
    {
        ImagensEvent[14].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        Velocidade = "Alta";
        ImagensEvent[12].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        ImagensEvent[13].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[4] = true;
        CheckPesquisar();
    }
    public void NumeroPatasMais()
    {
        if (NumeroDePatas < 99)
            NumeroDePatas++;
        numeroPatas.text = NumeroDePatas.ToString();
    }
    public void NumeroPatasMenos()
    {
        if (NumeroDePatas > 0)
            NumeroDePatas--;
        numeroPatas.text = NumeroDePatas.ToString();
    }
    public void HabitoNoturnoDiurno()
    {
        ImagensEvent[15].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        HabitoNoturno = false;
        ImagensEvent[16].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[5] = true;
        CheckPesquisar();
    }
    public void HabitoNoturnoNoturno()
    {
        ImagensEvent[16].GetComponent<Image>().color = new Color(0f, 1.0f, 0.0f, 1.0f);
        HabitoNoturno = true;
        ImagensEvent[15].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        podePesquisar[5] = true;
        CheckPesquisar();
    }

    public void KNNMais()
    {
        if (KNN < 23)
            KNN++;
        kNN.text = KNN.ToString();
    }
    public void KNNMenos()
    {
        if (KNN > 1)
            KNN--;
        kNN.text = KNN.ToString();
    }

    public void CheckPesquisar()
    {
        for (int i = 0; i < podePesquisar.Length; i++)
            if (!podePesquisar[i])
                return;
        pesquisarButton.interactable = true;
    }

    public void Pesquisar()
    {
        if (!pesquisarButton.interactable)
            return;
        menuInterface.SetActive(false);
        zoologicoController.GetComponent<ZoologicoController>().NormalizarNovoAnimal(new Animal(
            Name,
            Habitat,
            Revestimento,
            TonalidadePele,
            Tamanho,
            Velocidade,
            NumeroDePatas,
            HabitoNoturno,
            ""
            ),KNN);
        tabelaCaracteristicas.SetActive(true);
    }
    public void ShowUiInserir()
    {
        if (menuInterface.activeSelf)
        {
            menuInterface.SetActive(false);
            tabelaCaracteristicas.SetActive(true);
            return;
        }
        if(tabelaCaracteristicas.activeSelf)
            tabelaCaracteristicas.SetActive(false);
        for (int i = 0; i < podePesquisar.Length; i++)
            podePesquisar[i] = false;
        for (int i = 0; i < ImagensEvent.Length; i++)
            ImagensEvent[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1.0f);
        KNN = 1;
        kNN.text = KNN.ToString();
        NumeroDePatas = 0;
        numeroPatas.text = NumeroDePatas.ToString();
        pesquisarButton.interactable = false;
        menuInterface.SetActive(true);
    }

    public string Name { get; set; } = "Novo Animal";
    public string Habitat { get; set; }
    public string Revestimento { get; set; }
    public bool TonalidadePele { get; set; }
    public string Tamanho { get; set; }
    public string Velocidade { get; set; }
    public int NumeroDePatas { get; set; }
    public bool HabitoNoturno { get; set; }

    public int KNN { get; set; } = 1;
}
