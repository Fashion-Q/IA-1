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
    public bool itsOkay,debugPrint;
    public Main main;
    public Profundidade(string origem, string destino, List<Automaton> automatos,Main main)
    {
        this.origem = origem;
        this.destino = destino;
        this.automatos = automatos;
        this.main = main;
        itsOkay = false;
        automatosGerados = new List<Automaton> ();
    }
    public void RodarAutomato()
    {
        //só pra mostrar as prints no terminal
        debugPrint = false;
        chegou = false;
        //Aqui procura a "Origem" que a pessoa digitou dentre os automatos
        //primeiro eu preciso pegar a "Origem" pra saber onde é o start
        foreach(Automaton automaton in automatos)
        {
            if(automaton.nome == origem)
            {
                automatoStart = automaton;
                automatoStart.visitado = true;
                //esse array são o caminho que vai ser gerado
                automatosGerados.Add(new Automaton(automaton));
                break;
            }
        }

        //Aqui é o start do algoritmo de profundidade
        ProfundidadeLookForWay(new Automaton(automatoStart));
        bool checkBackTrack = false;
        //aqui fica o for para fazer o "backtrack" voltar para a cidade anterior
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
        if (debugPrint)
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
        }
        //itsOkay é pra verificar se tudo deu certo
        itsOkay = true;
    }

    public void ProfundidadeLookForWay(Automaton automatoSwitch)
    {
        //se o automato passado é == ao destino, achou o destino
        //e a função para. Esse if faz isso
        if(automatoSwitch.nome == destino)
        {
            chegou = true;
            return;
        }
        //aqui, para cada transição de um automato, percorrer todas as transições
        foreach(int[] tran in automatoSwitch.transition)
        {
            //se chegou que é o bool for true, o for para da recursividade
            if(chegou)
            {
                break;
            }
            foreach(Automaton automato in automatos)
            {
                //se chegou que é o bool for true, o for para da recursividade
                if (chegou)
                {
                    break;
                }
                //para cada transição do automato, percorrer todos os possíveis lugares para visitar
                if (tran[0] == automato.id && automato.visitado == false)
                {
                    automato.visitado = true;
                    automatosGerados.Add(new Automaton(automato));
                    ProfundidadeLookForWay(new Automaton(automato));
                }
            }
        }
        //se chegou for false, significa que deu um "backtrack"
        if (chegou == false)
        {
            automatoSwitch.nome = "backtrack";
            automatosGerados.Add(new Automaton(automatoSwitch));
        }
    }
}
