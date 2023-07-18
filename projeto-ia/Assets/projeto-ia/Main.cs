using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.IO;

public class Main : MonoBehaviour
{
    public LerArquivo lerArquivo;
    public Profundidade profundidade;
    private ValidarPath validarPath;
    public Text textOrigem, textDestino, textAlternatePath,textLerArquivo;
    public GameObject automatoPrefe, cam,alcidesName;
    public List<GameObject> allAltomatos = new();
    private Play play;
    public GameObject validateScreen,playingGame;
    public SpriteRenderer renderr;
    public Transform pFront, pBack;
    public float calcDistance,speedRot,controlSpeedRot = 1f,rotCharacter = 1;
    public string origem,alternatePath;
    public string destino;
    public string originalPath;

    void Start()
    {
        validarPath = new(this);
        originalPath = Application.dataPath + "/projeto-ia/jflap.jff";
        alternatePath = "";
        pFront = transform.Find("pFront");
        pBack = transform.Find("bBack");
        renderr = GetComponent<SpriteRenderer>();
        play = new(this)
        {
            instance = 0,
            canPlay = false
        };
        origem = "simaodias";
        destino = "carira";
        calcDistance = 0.09f;
    }

    private void FixedUpdate()
    {
        play.Playy();
    }

    public void butaoTeste()
    {
        var t = automatoPrefe.GetComponent<TextMeshPro>();
        if(t != null)
        {
            print("Not NULL");
            t.text = "???";
        }
        else
        {
            print("NULL");
        }
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    public void Confirmar()
    {
        validarPath.Validar();
        if (validarPath.validar)
        {
            play.indexAutomato = 0;
            for(int i=0;i<profundidade.automatosGerados.Count;i++)
            {
                allAltomatos.Add(Instantiate(automatoPrefe, new Vector3(profundidade.automatosGerados[i].x * calcDistance, profundidade.automatosGerados[i].y * calcDistance, 0f), Quaternion.identity));
                allAltomatos[i].GetComponent<TextMeshPro>().text = profundidade.automatosGerados[i].nome;
                print("nome: "+ profundidade.automatosGerados[play.indexAutomato].nome + " | " + play.getIndexX() + " | " + play.getIndexY());
                play.indexAutomato++;
            }
            print("**************");
            play.instance = 0;
            play.indexAutomato = 0;
            play.canPlay = true;
            validateScreen.SetActive(false);
            playingGame.SetActive(true);
        }
    }

    public void stopGame()
    {
        if(playingGame.activeSelf)
        {
            playingGame.SetActive(false);
            validateScreen.SetActive(true);
            play.canPlay = false;
            foreach (GameObject obj in allAltomatos)
                Destroy(obj);
            allAltomatos.Clear();
        }
    }

    public void SetInWay()
    {
        if (!play.inWay && play.indexAutomato+1 < profundidade.automatosGerados.Count)
        {
            play.indexAutomato++;
            
            if(play.Gx > play.getIndexX())
            {
                play.goLeftRight = true;
                renderr.flipX = true;
                controlSpeedRot = 1f;
            }
            else
            {
                play.goLeftRight = false;
                renderr.flipX=false;
                controlSpeedRot = -1f;
            }
            if (play.Gy < play.getIndexY())
            {
                play.goUpDown = true;
            }
            else
            {
                play.goUpDown = false;
            }
            play.inWay = true;
            play.canPlay = true;
            play.endUpDown = false;
            play.endLeftRight = false;
            play.instance = 1;
        }
    }

    public void Cidade2Changed(string destino)
    {
        this.destino = destino;
    }
    public void Cidade1Changed(string origem)
    {
        this.origem = origem;
    }
    public void ChoosePath(string path)
    {
        alternatePath = path;
    }

    public void printarTexto(string texto)
    {
        print(texto);
    }
}