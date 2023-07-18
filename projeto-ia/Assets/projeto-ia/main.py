import leitura 
import profundidade 
leitura.printAutomatons()
leitura.printarCidades()
contador = 0
origem = ""
destino = ""


def getString(inputTexto,validar):
    texto = input(inputTexto)
    flag = True
    while flag:
        for a in leitura.automatons:
            if(texto.lower() == a.nome.lower()):
                flag = False
                texto = a.nome
                break
        if(not flag):
            if(texto == validar):
                texto = input("\n*** Cidade repetida! Por favor, informe novamente a cidade: ")
                flag = True
            continue
        texto = input("*** Nome da cidade nao encontrado! ***\n\nDigite novamente: ")
    
    return texto

origem = getString("Digite sua posicao atual: ","")
destino = getString("Digite seu destino: ",origem)
# origem='SimaoDias'
# destino='Capela'
# destino = input("Digite seu destino: ")

p = profundidade.Profundidade(origem,destino, leitura.automatons)
p.rodarAutomato()

