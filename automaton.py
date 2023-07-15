class Automaton:
    def __init__(self,id,nome,x,y,label):
        self.id = id
        self.nome = nome
        self.x = x
        self.y = y
        self.label = label
        self.transition = []
        self.visitado = False