using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;
using AutomatonNameSpace;

public class LerArquivo
{
    //Todos os automatos que ler do jflah fica aqui
    public List<Automaton> automatos = new();
    readonly XmlDocument xmlDoc = new();
    public bool LerArquivoXML(ValidarPath validarPath){
        //aqui o xml abre o "caminho/diretorio" do arquivo xml
        xmlDoc.Load(validarPath.main.alternatePath);
        //aqui no estados pega TODAS as tags "state" e guarda
        XmlNodeList estados = xmlDoc.SelectNodes("//state");
        CultureInfo culture = CultureInfo.InvariantCulture;
        //nesse for, para cada tag "state", cria uma entidaded "Automato" mas sem transição
        foreach (XmlNode estado in estados) {
            automatos.Add(new Automaton(
                int.TryParse(estado.Attributes["id"].Value, out int parseId) ? parseId : 0,
                estado.Attributes["name"].Value,
                float.TryParse(estado.SelectSingleNode("x").InnerText, NumberStyles.Float, culture, out float x) ? (float)Math.Round(x, 2) : 0,
                float.TryParse(estado.SelectSingleNode("y").InnerText, NumberStyles.Float, culture, out float y) ? (float)Math.Round(y, 2) : 0,
                float.TryParse(estado.SelectSingleNode("label").InnerText, NumberStyles.Float, culture, out float label) ? (float)Math.Round(label, 2) : 0
                ));
            //validarPath.main.PrintarTexto(estado.Attributes["name"].Value.ToLower() + " | "+ validarPath.main.origem.ToLower() + "  |||  "+ estado.Attributes["name"].Value.ToLower() + " | " + validarPath.main.destino.ToLower());
            if (estado.Attributes["name"].Value.ToLower() == validarPath.main.origem.ToLower())
            {
                validarPath.validarOrigem = true;
                validarPath.main.origem = estado.Attributes["name"].Value;
                //validarPath.main.PrintarTexto("achou Origem");
            }
            if (estado.Attributes["name"].Value.ToLower() == validarPath.main.destino.ToLower())
            {
                validarPath.validarDestino = true;
                validarPath.main.destino = estado.Attributes["name"].Value;
                //validarPath.main.PrintarTexto("achou Destino");
            }
        }
        //depois de ter lido os "states", ler as "transições" e adiciona as
        //transições nas entidades que foi criada a cima
        XmlNodeList transition = xmlDoc.SelectNodes("//transition");
        if(automatos.Count == 0)
        {
            return false;
        }
        bool validarTransition = false;
        foreach(XmlNode tran in transition)
        {
            foreach(Automaton auto in automatos )
            {

                if (auto.id == (int.TryParse(tran.SelectSingleNode("from").InnerText,out int f) ? f : 0))
                {
                    auto.transition.Add(new int[] { int.Parse(tran.SelectSingleNode("to").InnerText), int.Parse(tran.SelectSingleNode("read").InnerText)});
                    validarTransition = true;
                }
            }
        }
        //PrintarAutomatons("**** LerArquivo ***",automatos);
        return validarTransition;
    }

    public void PrintarAutomatons(string text,List<Automaton> autos)
    {
        //serve só pra printar os automatos
        Debug.Log(text);
        string logString;
        foreach (Automaton auto in autos)
        {
            logString=("id: " + auto.id + " | nome: " + auto.nome + " | x: " + auto.x + " | y: " + auto.y + " | label: "+ auto.label + "\n");
            for(int i = 0; i < auto.transition.Count; i++)
            {
                logString +=("from: " + auto.id + " to: " + auto.transition[i][0] + " lendo: " + auto.transition[i][1] + "\n");
            }
        }
    }
}