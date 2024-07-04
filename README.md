# Ludo Game em C#

Este projeto é uma implementação do clássico jogo de tabuleiro Ludo em C#. O jogo suporta 2 ou 4 jogadores e segue as regras tradicionais do Ludo.

## Sobre o Projeto

Este jogo foi desenvolvido como projeto final da disciplina de Algoritmos e Técnicas de Programação para o curso de graduação em Sistemas de Informação na PUC-Minas. 

**Desenvolvedores:**
- [0matheusfilipe] (www.linkedin.com/in/matheusfilipesilva/)
- [marquesht] (www.linkedin.com/in/arthur-marques-b984162a9/)
  
## Características

- Suporte para 2 ou 4 jogadores
- Implementação completa das regras do Ludo, incluindo:
  - Movimento dos peões
  - Captura de peões adversários
  - Entrada na casa final
  - Regra dos três 6 consecutivos
- Interface de console para interação com o usuário (não consta visual do tabuleiro)
- Registro de todas as ações do jogo em um arquivo de log

## Estrutura do Projeto

O projeto é composto por várias classes:

- `Peao`: Representa um peão individual no jogo
- `Jogador`: Representa um jogador e seus peões
- `Tabuleiro`: Contém as constantes e configurações do tabuleiro
- `Jogo`: Gerencia a lógica principal do jogo
- `Program`: Contém o método `Main` para iniciar o jogo

## Como Jogar

1. Execute o programa
2. Escolha o número de jogadores (2 ou 4)
3. Siga as instruções na tela para lançar o dado e mover os peões

## Requisitos

- .NET Framework ou .NET Core

## Como Executar

1. Clone este repositório
2. Abra o projeto em seu ambiente de desenvolvimento C# preferido
3. Compile e execute o programa

## Logs do Jogo

Todas as ações do jogo são registradas em um arquivo chamado `ludo_log.txt`, que é criado no diretório de execução do programa.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para fazer um fork deste projeto e submeter pull requests com melhorias ou correções.
