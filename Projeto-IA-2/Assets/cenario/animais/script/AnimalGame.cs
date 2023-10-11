using BaseDeAnimais;
using TMPro;
using UnityEngine;

public class AnimalGame : IAnimal
{
    private Animal animal;
    [SerializeField]
    private GameObject valuesTable;
    [SerializeField]
    private GameObject nomeAnimal;
    [SerializeField]
    private AudioSource audioSource;

    private void OnMouseDown()
    {
        nomeAnimal.GetComponent<TextMeshProUGUI>().text = animal.Name;
        TextMeshProUGUI[] text = valuesTable.GetComponentsInChildren<TextMeshProUGUI>();
        text[0].text = animal.HabitatNormalized.ToString("0.00");
        text[1].text = animal.RevestimentoNormalized.ToString("0.00");
        text[2].text = animal.TonalidadePeleNormalized.ToString("0.00");
        text[3].text = animal.TamanhoNormalized.ToString("0.00");
        text[4].text = animal.VelocidadeNormalized.ToString("0.00");
        text[5].text = animal.NumeroDePatasNormalized.ToString("0.00");
        text[6].text = animal.HabitoNoturnoNormalized.ToString("0.00");
        text[7].text = animal.AlimentacaoNormalized.ToString("0.0");
        text[8].text = animal.Proximidade.ToString("0.000");
        if(audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }

    public override void ShowUi()
    {
        OnMouseDown();
    }

    public override void SetAnimal(Animal animal)
    {
        this.animal = animal;
        this.animal.PosX = transform.position.x;
        this.animal.PosY = transform.position.y;
    }

    public override Animal GetAnimal()
    {
        return animal;
    }
}
