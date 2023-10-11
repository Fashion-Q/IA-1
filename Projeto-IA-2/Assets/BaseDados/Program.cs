using System;
namespace BaseDeAnimais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseDeDados dados = new BaseDeDados();
            dados.NormalizarDados(new Animal(
                "Macaco",
                "Terrestre",
                "Pelo",
                false,
                "Pequeno",
                "Média",
                4,
                false,
                "Herbívoro"
                ));
            

            foreach (Animal animal in dados.animais)
            {
                Console.WriteLine(
                    "--------------------------\n"+
                animal.Name + " | " +
                animal.HabitatNormalized + " | " +
                animal.RevestimentoNormalized + " | " +
                animal.TonalidadePeleNormalized + " | " +
                animal.TamanhoNormalized + " | " +
                animal.VelocidadeNormalized + " | " +
                animal.NumeroDePatasNormalized + " | " +
                animal.HabitoNoturnoNormalized + " | "+
                animal.Alimentacao + "\n"
                + "Normalizado: "+ animal.NumeroDePatasNormalized);
                Console.WriteLine("Proximidade " + animal.Name + ": " + animal.Proximidade);
            }
            int valorDeK = 8;
            int carnivoro = 0, herbivoro = 0, onivoro = 0;

            for(int i=0;i<valorDeK;i++)
            {
                if (dados.animais[i].Alimentacao.Equals("Carnívoro"))
                    carnivoro++;
                else if (dados.animais[i].Alimentacao.Equals("Herbívoro"))
                    herbivoro++;
                else
                    onivoro++;
            }
            string alimentacao;
            if (onivoro >= herbivoro && onivoro >= carnivoro)
                alimentacao = "Onívoro";
            else if (herbivoro >= carnivoro && herbivoro >= onivoro)
                alimentacao = "Herbívoro";
            else
                alimentacao = "Carnívoro";

            Console.WriteLine("Classificação:\nCarnívoro: " + carnivoro);
            Console.WriteLine("Herbívoro: " + herbivoro);
            Console.WriteLine("Onívoro: " + onivoro);
            Console.WriteLine("O animal [Macaco] foi classificado como: " + alimentacao);
            Console.ReadKey();
        }
    }
}
