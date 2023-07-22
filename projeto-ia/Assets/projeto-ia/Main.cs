using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    public LerArquivo lerArquivo;
    public Profundidade profundidade;
    private ValidarPath validarPath;
    public Text textOrigem, textDestino, textAlternatePath,textLerArquivo,textVitoria;
    public GameObject automatoPrefe, cam,alcidesName;
    public List<GameObject> allAltomatos = new();
    private Play play;
    public GameObject validateScreen,playingGame,brasileirinho;
    public SpriteRenderer renderr;
    public Animator animacao;
    public ITransformSimple main,iFront,iBack,iBrasileirinho;
    public float calcDistance,speedRot,controlSpeedRot = 1f,rotCharacter = 1;
    public float pFrontRight,pBackRight,pFrontLeft,pBackLeft,nameFixY,nameFixX,brasileirinhoX;
    public string origem,alternatePath;
    public string destino;

    void Start()
    {
        pFrontRight = 1.55f;
        pFrontLeft = -1.55f;
        pBackRight = -0.75f;
        pBackLeft = 0.75f;
        nameFixX = 0.88f;
        nameFixY = 1.56f;
       
        validarPath = new(this);
        //originalPath = Application.dataPath + "/projeto-ia/jflap.jff";
        alternatePath = "";
        Transform pFront = transform.Find("pFront");
        Transform pBack = transform.Find("pBack");
        renderr = GetComponent<SpriteRenderer>();
        play = new(this)
        {
            instance = 0,
            canPlay = false
        };
        //origem = "simaodias";
        //destino = "propria";
        calcDistance = 0.09f;
        main = new ITransformSimple(transform, 4, GetComponent<SpriteRenderer>());
        iFront = new(pFront, 4, pFront.GetComponent<SpriteRenderer>());
        iBack = new(pBack, 4, pBack.GetComponent<SpriteRenderer>());
        iBrasileirinho = new(brasileirinho.transform,0,brasileirinho.GetComponent<SpriteRenderer>());
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
        //modo debug
        //alternatePath = originalPath;
        validarPath.Validar();
        if (validarPath.validar)
        {
            play.indexAutomato = 0;
            for(int i=0;i<profundidade.automatosGerados.Count;i++)
            {
                allAltomatos.Add(Instantiate(automatoPrefe, new Vector3(profundidade.automatosGerados[i].x * calcDistance, profundidade.automatosGerados[i].y * calcDistance, 0f), Quaternion.identity));
                allAltomatos[i].GetComponent<TextMeshPro>().text = profundidade.automatosGerados[i].nome;
                //print("nome: "+ profundidade.automatosGerados[play.indexAutomato].nome + " | " + play.getIndexX() + " | " + play.getIndexY());
                play.indexAutomato++;
            }
            //print("**************");
            play.instance = 0;
            play.indexAutomato = 0;
            play.canPlay = true;
            validateScreen.SetActive(false);
            playingGame.SetActive(true);
            if (play.Gx > play.getIndexX())
            {
                brasileirinhoX = 0;
            }
            else
            {
                brasileirinhoX = 2.5f;
            }
        }
    }

    public void stopGame()
    {
        if(playingGame.activeSelf)
        {
            playingGame.SetActive(false);
            validateScreen.SetActive(true);
            play.canPlay = false;
            play.inWay = false;
            foreach (GameObject obj in allAltomatos)
                Destroy(obj);
            allAltomatos.Clear();
            textVitoria.enabled = false;
            animacao.SetBool("run", false);
            main.RotReset();
            iFront.RotReset();
            iBack.RotReset();
        }
    }

    public void SetInWay()
    {
        if (!play.inWay && play.indexAutomato+1 < profundidade.automatosGerados.Count)
        {
            play.indexAutomato++;
            if (play.Gx > play.getIndexX())
            {
                play.goLeftRight = true;
                renderr.flipX = true;
                controlSpeedRot = 1f;
                brasileirinhoX = 0;
                iFront.Gx = main.Gx + pFrontLeft;
                iBack.Gx = main.Gx + pBackLeft;
            }
            else
            {
                play.goLeftRight = false;
                renderr.flipX=false;
                controlSpeedRot = -1f;
                brasileirinhoX = 2.5f;
                iFront.Gx = main.Gx + pFrontRight;
                iBack.Gx = main.Gx + pBackRight;
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
            animacao.SetBool("run", true);
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