namespace AutomatonNameSpace
{

    using System.Collections.Generic;
    public class Automaton
    {
        public int id;
        public float x, y, label;
        public string nome;
        public List<int[]> transition;
        public bool visitado;
        public Automaton(int id, string nome, float x, float y, float label)
        {
            this.id = id;
            this.nome = nome;
            this.x = x;
            this.y = y;
            this.label = label;
            transition = new();
            visitado = false;
        }
        public Automaton(Automaton automaton)
        {
            id = automaton.id;
            nome = automaton.nome;
            x = automaton.x;
            y = automaton.y;
            label = automaton.label;
            transition = automaton.transition;
            visitado = automaton.visitado;
        }
    }
}