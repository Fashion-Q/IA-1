using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseDeAnimais
{
    public class BaseDeDados
    {
        public List<Animal> animais = new List<Animal>
        {
        new Animal("Leao", "Terrestre", "Pelo", true, "Médio", "Alta", 4, false, "Carnívoro"),
        new Animal("Águia", "Aéreo", "Pena", false, "Médio", "Alta", 2, false, "Carnívoro"),
        new Animal("Hipopótamo", "Aquático", "Pele", false, "Grande", "Baixa", 4, false, "Herbívoro"),
        new Animal("Lagarto", "Terrestre", "Escama", false, "Pequeno", "Média", 4, false, "Onívoro"),
        new Animal("Lince", "Terrestre", "Pelo", true, "Médio", "Alta", 4, true, "Carnívoro"),
        new Animal("Pinguim", "Aquático", "Pena", false, "Médio", "Baixa", 2, false, "Carnívoro"),
        new Animal("Crocodilo", "Aquático", "Escama", true, "Grande", "Alta", 4, false, "Carnívoro"),
        new Animal("Tigre", "Terrestre", "Pelo", true, "Grande", "Alta", 4, false, "Carnívoro"),
        new Animal("Girafa", "Terrestre", "Pelo", false, "Grande", "Média", 4, false, "Herbívoro"),
        new Animal("Elefante", "Terrestre", "Pelo", false, "Grande", "Baixa", 4, false, "Herbívoro"),
        new Animal("Rinoceronte", "Terrestre", "Pelo", false, "Grande", "Baixa", 4, false, "Herbívoro"),
        new Animal("Ornitorrinco", "Aquático", "Pelo", true, "Pequeno", "Baixa", 4, true, "Onívoro"),
        new Animal("Capivara", "Terrestre", "Pelo", false, "Médio", "Baixa", 4, false, "Herbívoro"),
        new Animal("Lobo", "Terrestre", "Pelo", true, "Médio", "Alta", 4, false, "Carnívoro"),
        new Animal("Gorila", "Terrestre", "Pelo", true, "Grande", "Baixa", 2, false, "Herbívoro"),
        new Animal("Raposa", "Terrestre", "Pelo", false, "Médio", "Alta", 4, false, "Carnívoro"),
        new Animal("Bixo-preguiça", "Terrestre", "Pelo", true, "Médio", "Baixa", 4, true, "Herbívoro"),
        new Animal("Panda", "Terrestre", "Pelo", false, "Médio", "Baixa", 4, false, "Herbívoro"),
        new Animal("Garça", "Aquático", "Pena", false, "Médio", "Média", 2, false, "Carnívoro"),
        new Animal("Flamingo", "Aquático", "Pena", false, "Grande", "Média", 2, false, "Herbívoro"),
        new Animal("Aracnídeo", "Terrestre", "Escama", false, "Pequeno", "Baixa", 8, false, "Carnívoro"),
        new Animal("Besouro", "Terrestre", "Escama", false, "Pequeno", "Baixa", 6, false, "Herbívoro"),
        new Animal("Cobra", "Terrestre", "Escama", false, "Médio", "Média", 0, false, "Carnívoro"),
        new Animal("Escorpião", "Terrestre", "Escama", false, "Pequeno", "Média", 10, false, "Carnívoro")
        };//         Nome        Habitat    Revest   Ton      Tam        Vel   NºP  Hab.N   Dieta

        public void NormalizarDados(Animal newAnimal)
        {
            int maxPatas = animais.Max(animal => animal.NumeroDePatas);
            int minPatas = animais.Min(animal => animal.NumeroDePatas);
            maxPatas = newAnimal.NumeroDePatas > maxPatas ? newAnimal.NumeroDePatas : maxPatas;
            minPatas = newAnimal.NumeroDePatas < minPatas ? newAnimal.NumeroDePatas : minPatas;
            newAnimal.NumeroDePatasNormalized = ((float)newAnimal.NumeroDePatas - minPatas) / (maxPatas - minPatas);
            foreach (Animal animal in animais)
            {
                animal.NumeroDePatasNormalized = ((float)animal.NumeroDePatas - minPatas) / (maxPatas - minPatas);
                animal.Proximidade = Math.Sqrt((
                    Math.Pow(animal.HabitatNormalized - newAnimal.HabitatNormalized, 2) +
                    Math.Pow(animal.RevestimentoNormalized - newAnimal.RevestimentoNormalized, 2) +
                    Math.Pow(animal.TonalidadePeleNormalized - newAnimal.TonalidadePeleNormalized, 2) +
                    Math.Pow(animal.TamanhoNormalized - newAnimal.TamanhoNormalized, 2) +
                    Math.Pow(animal.VelocidadeNormalized - newAnimal.VelocidadeNormalized, 2) +
                    Math.Pow(animal.HabitoNoturnoNormalized - newAnimal.HabitoNoturnoNormalized, 2) +
                    Math.Pow(animal.NumeroDePatasNormalized - newAnimal.NumeroDePatasNormalized, 2)
                    ));
            }
            //animais.Sort((animal1, animal2) => animal1.Proximidade.CompareTo(animal2.Proximidade));
        }
    }
}
