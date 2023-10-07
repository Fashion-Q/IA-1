using System;
using System.Collections.Generic;

namespace BaseDeAnimais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseDeDados dados = new BaseDeDados();
            dados.NormalizeNumeroDePatas(new Animal(
                "Macaco",
                "Terrestre",
                "Pelo",
                false,
                "pequeno",
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
                animal.NumeroDePatas + " | " +
                animal.HabitoNoturnoNormalized + " | "+
                animal.Alimentacao + "\n"
                + "Normalizado: "+ animal.NumeroDePatasNormalized
                + "\n"
                );
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
