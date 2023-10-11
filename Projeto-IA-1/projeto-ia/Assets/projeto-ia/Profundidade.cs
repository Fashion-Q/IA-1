using System.Collections.Generic;
using AutomatonNameSpace;
using UnityEngine;

public class Profundidade
{
    public string origem, destino;
    public bool chegou;
    List<Automaton> automatos = new();
    Automaton automatoStart;
    public List<Automaton> automatosGerados;
    public Main main;
    public Profundidade(string origem, string destino, List<Automaton> automatos,Main main)
    {
        this.origem = origem;
        this.destino = destino;
        this.automatos = automatos;
        this.main = main;
        automatosGerados = new List<Automaton> ();
    }
    public void RodarAutomato()
    {
        chegou = false;
        foreach(Automaton automaton in automatos)
        {
            if(automaton.nome == origem)
            {
                automatoStart = automaton;
                automatoStart.visitado = true;
                automatosGerados.Add(new Automaton(automaton));
                break;
            }
        }
        ProfundidadeLookForWay(new Automaton(automatoStart));
        bool checkBackTrack = false;
        for(int i = 0,indexFix=0; i < automatosGerados.Count; i++)
        {
            if (automatosGerados[i].nome != "backtrack")
            {
                checkBackTrack = false;
            }
            if (automatosGerados[i].nome == "backtrack" && !checkBackTrack)
            {
                indexFix = i - 2;
                checkBackTrack = true;
            }
            
            if (checkBackTrack && indexFix >= 0)
            {
                automatosGerados[i] = new Automaton(automatosGerados[indexFix]);// caminho[indexFix];
                indexFix--;
            }
        }

        //aqui serve só pra printar no terminal da unity pra ver se ta tudo certo
       /* if (debugPrint)
        {
            string log = "";
            foreach (Automaton aut in automatosGerados)
            {
                log = ("id: " + aut.id);
                log += (" | nome: " + aut.nome);
                log += (" | x: " + aut.x);
                log += (" | y: " + aut.y);
                log += (" | label: " + aut.label);
                for (int i = 0; i < aut.transition.Count; i++)
                {
                    log += ("\nfrom: " + aut.id + " to: " + aut.transition[i][0] + " lendo: " + aut.transition[i][1]);
                }
                Debug.Log(log);
            }
        }*/
    }

    public void ProfundidadeLookForWay(Automaton automatoSwitch)
    {
        if(automatoSwitch.nome == destino)
        {
            chegou = true;
            return;
        }
        foreach(int[] tran in automatoSwitch.transition)
        {
            if(chegou)
            {
                break;
            }
            foreach(Automaton automato in automatos)
            {
                if (chegou)
                {
                    break;
                }
                if (tran[0] == automato.id && automato.visitado == false)
                {
                    automato.visitado = true;
                    automatosGerados.Add(new Automaton(automato));
                    ProfundidadeLookForWay(new Automaton(automato));
                }
            }
        }
        if (chegou == false)
        {
            automatoSwitch.nome = "backtrack";
            automatosGerados.Add(new Automaton(automatoSwitch));
        }
    }
}
