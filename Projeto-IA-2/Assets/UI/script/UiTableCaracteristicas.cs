using TMPro;
using UnityEngine;

public class UiTableCaracteristicas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject tabelaUi;

    public void TableMenuCaracteristicas()
    {
        if(text.text.Equals("Fechar"))
        {
            tabelaUi.SetActive(false);
            text.text = "Mostrar";
        }
        else
        {
            tabelaUi.SetActive(true);
            text.text = "Fechar";
        }
    }
}
