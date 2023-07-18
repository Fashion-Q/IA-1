using System.Diagnostics;
using System.IO;


public class ValidarPath
{
    public Main main;
    public bool validar,validarOrigem,validarDestino;
    public ValidarPath(Main main)
    {
        this.main = main;
    }

    public void Validar()
    {
        validar = true;
        SetBoolFalse();
        if(main.origem.Length == 0)
        {
            validar = false;
            main.textOrigem.enabled = true;
        }
        if(main.destino.Length == 0)
        {
            validar = false;
            main.textDestino.enabled = true;
        }
        if(main.alternatePath.Length > 0 && !File.Exists(main.alternatePath))
        {
            validar = false;
            main.textAlternatePath.enabled = true;
            main.textLerArquivo.text = " Error ";
            main.textLerArquivo.enabled = true;
            
        }
        if (validar)
        {
            main.lerArquivo = new();
            validarOrigem = false;
            validarDestino = false;
            try
            {
                if (!main.lerArquivo.LerArquivoXML(this))
                {
                    main.textLerArquivo.enabled = true;
                    validar = false;
                }
                if (!validarOrigem || !validarDestino)
                {
                    validar = false;
                    main.textOrigem.enabled = !validarOrigem;
                    main.textDestino.enabled = !validarDestino;
                    main.textLerArquivo.text = "Error ao achar a(s) cidade(s): " + (!validarOrigem ? "Origem" + (!validarDestino ? " e Destino" : "") : "Destino");
                    main.textLerArquivo.enabled = true;
                    if(main.alternatePath != main.originalPath)
                    {
                        main.textAlternatePath.enabled = true;
                    }
                }
                else
                {
                    main.profundidade = new Profundidade(main.origem, main.destino, main.lerArquivo.automatos,main);
                    main.profundidade.RodarAutomato();
                }
                
            }
            catch (System.Exception)
            {
                main.textLerArquivo.text = "Algum problema ocorreu ao ler o arquivo jff";
                main.textLerArquivo.enabled = true;
                validar = false;
                return;
            }
        }

    }
    public void SetBoolFalse()
    {

        main.textOrigem.enabled = false;
        main.textDestino.enabled = false;
        main.textAlternatePath.enabled = false;
        main.textLerArquivo.enabled = false;
    }
}
