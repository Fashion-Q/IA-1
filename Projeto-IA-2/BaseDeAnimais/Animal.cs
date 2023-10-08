namespace BaseDeAnimais
{
    public class Animal
    {
        public Animal(string name, string habitat, string revestimento, bool tonalidadePele, string tamanho, string velocidade, int numeroDePatas, bool habitoNoturno, string alimentacao)
        {
            Name = name;
            Habitat = habitat;
            Revestimento = revestimento;
            TonalidadePele = tonalidadePele;
            Tamanho = tamanho;
            Velocidade = velocidade;
            NumeroDePatas = numeroDePatas;
            HabitoNoturno = habitoNoturno;
            Alimentacao = alimentacao;
            if (Habitat == "Terrestre")
                HabitatNormalized = 0f;
            else if(Habitat == "Aquático")
                HabitatNormalized = 0.5f;
            else//Aereo
                HabitatNormalized = 1f;

            if (Revestimento == "Pelo")
                RevestimentoNormalized = 0;
            else if (Revestimento == "Escama")
                RevestimentoNormalized = 0.33f;
            else if (Revestimento == "Pena")
                RevestimentoNormalized = 0.66f;
            else//Pele lisa
                RevestimentoNormalized = 1f;

            //0 = claro | 1 = escuro
            TonalidadePeleNormalized = TonalidadePele ? 0 : 1;

            if (Tamanho == "Pequeno")
                TamanhoNormalized = 0f;
            else if (Tamanho == "Médio")
                TamanhoNormalized = 0.5f;
            else//Grande
                TamanhoNormalized = 1f;

            if (Velocidade == "Baixa")
                VelocidadeNormalized = 0f;
            else if (Velocidade == "Média")
                VelocidadeNormalized = 0.5f;
            else
                VelocidadeNormalized = 1f;

            //1 para Noturno 0 para Nao Noturno
            HabitoNoturnoNormalized = HabitoNoturno ? 1 : 0;
        }

        public string Name { get; set; }
        public string Habitat { get; set; }
        public string Revestimento { get; set; }
        public bool TonalidadePele { get; set; }
        public string Tamanho { get; set; }
        public string Velocidade { get; set; }
        public bool HabitoNoturno { get; set; }
        public int NumeroDePatas { get; set; }
        public string Alimentacao { get; set; }

        public float HabitatNormalized { get; set; }
        public float RevestimentoNormalized { get; set; }
        public float TonalidadePeleNormalized { get; set; }
        public float TamanhoNormalized { get; set; }
        public float VelocidadeNormalized { get; set; }
        public float HabitoNoturnoNormalized { get; set; }
        public float NumeroDePatasNormalized { get; set; }

        public double Around { get; set; }
    }
}
