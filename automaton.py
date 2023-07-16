class Automaton:
    def __init__(self,id,nome,x,y,label,transition,visitado):
        self.id = id
        self.nome = nome
        self.x = x
        self.y = y
        self.label = label
        self.transition = transition
        self.visitado = visitado
        
class AutomatonFactory:
    def create_automaton(self, automaton):
        return Automaton(
            automaton.id,
            automaton.nome,
            automaton.x,
            automaton.y,
            automaton.label,
            automaton.transition,
            automaton.visitado,
        )



def pegaAutomato(automaton):
        return Automaton(
            automaton.id,
            automaton.nome,
            automaton.x,
            automaton.y,
            automaton.label,
            automaton.transition,
            automaton.visitado,
        )
