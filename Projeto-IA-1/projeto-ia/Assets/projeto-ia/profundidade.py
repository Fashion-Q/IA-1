import automaton


class Profundidade:
    def __init__(self,origem,destino,automatos):
        self.origem = origem
        self.destino = destino
        self.automatos = automatos
        self.automatoStart = None
        self.caminho = []
        self.chegou = False
        
    def rodarAutomato(self):
        for a in self.automatos:
            if(a.nome == self.origem): 
                self.automatoStart = a
                self.automatoStart.visitado = True
                self.caminho.append(self.automatoStart.nome)
                break
        self.profundidade(automaton.pegaAutomato(self.automatoStart))
        for c in self.caminho:
            print(c)
        with open("unity.txt","w") as file:
            for item in self.caminho:
                file.write(item + "\n")
        

    def profundidade(self, automatoswitch):
        # print(automatoswitch.nome)
        if(automatoswitch.nome == self.destino):
            self.chegou = True
            return 
        for a in automatoswitch.transition:
            if(self.chegou == True):
                break
            for b in self.automatos:
                if(self.chegou == True):
                    break
                if(a[0] == b.id and b.visitado == False):
                    b.visitado = True
                    self.caminho.append(b.nome)
                    self.profundidade(automaton.pegaAutomato(b))
        if(self.chegou== False):
            self.caminho.append("backtrack:  "+(automatoswitch.nome))