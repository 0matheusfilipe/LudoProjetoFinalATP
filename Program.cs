using System;
using System.IO;
/*class Peao
    private int posicao;
    private bool estaEmJogo;
    private bool estaNaCasaFinal;
    private int distanciaPercorrida;
    public int Posicao 
    { 
        get { return posicao; } 
        set { posicao = value; } 
    }
    public bool EstaEmJogo 
    {
        get { return estaEmJogo; }
        set { estaEmJogo = value; }
    }
    public bool EstaNaCasaFinal 
    {
        get { return estaNaCasaFinal; }
        set { estaNaCasaFinal = value; }
    }
    public int DistanciaPercorrida
    {
        get { return distanciaPercorrida; }
        set { distanciaPercorrida = value; }
    }

    public Peao()
    {
        Posicao = -1;
        EstaEmJogo = false;
        EstaNaCasaFinal = false;
        DistanciaPercorrida = 0;
    }
}*/

/*class Jogador
{
    public string Cor { get; }
    public Peao[] Peoes { get; }
    public int SeisConsecutivos { get; set; }
    public int CasaInicial { get; }

    public Jogador(string cor, int casaInicial)
    {
        Cor = cor;
        Peoes = new Peao[4] { new Peao(), new Peao(), new Peao(), new Peao() };
        SeisConsecutivos = 0;
        CasaInicial = casaInicial;
    }
}*/

/*class Tabuleiro
{
    public const int TamanhoPista = 52;
    public const int TamanhoCasaFinal = 6;
    public static int[] CasasSeguras = { 9, 22, 35, 48 };
    public static int[] CasasIniciais = { 1, 14, 27, 40 };
}*/

/*class Jogo
{
    private Jogador[] jogadores;
    private int jogadorAtual;
    private Random dado;
    private StreamWriter escreveLog;
    private string[,] casas;
    private int numeroJogadores;

    public Jogo(int numeroJogadores)
    {
        string[] cores = { "Vermelho", "Verde", "Amarelo", "Azul" };
        this.numeroJogadores = numeroJogadores;
        jogadores = new Jogador[numeroJogadores];
        for (int i = 0; i < numeroJogadores; i++)
        {
            jogadores[i] = new Jogador(cores[i], Tabuleiro.CasasIniciais[i]);
        }
        jogadorAtual = 0;
        dado = new Random();
        escreveLog = new StreamWriter("ludo_log.txt");
        casas = new string[15, 15];
    }
    public int TamanhoCasaFinal { get; private set; }

    public void Jogar()
    {
        while (!VerificarVitoria())
        {
            Console.Clear();
            ExibirTabuleiro(); // Exibe o tabuleiro estático e o estado atual dos peões
            ExecutarTurno();
            jogadorAtual = (jogadorAtual + 1) % jogadores.Length;
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        Console.Clear();
        ExibirTabuleiro(); // Exibe o tabuleiro final
        escreveLog.Close();
    }

    private void ExecutarTurno()
    {
            Jogador jogador = jogadores[jogadorAtual];
            Console.WriteLine($"\nTurno do Jogador {jogador.Cor}");
            int valorDado = LancarDado();
            Log($"Jogador {jogador.Cor} lançou o dado: {valorDado}");

            if (valorDado == 6)
            {
                jogador.SeisConsecutivos++;
                if (jogador.SeisConsecutivos == 3)
                {
                    Log($"Jogador {jogador.Cor} tirou 6 três vezes consecutivas. Passando a vez.");
                    jogador.SeisConsecutivos = 0;
                    return;
                }
            }
            else
            {
                jogador.SeisConsecutivos = 0;
            }

            if (valorDado == 6 && TemPeaoForaDoJogo(jogador))
            {
                if (!TemPeaoNoJogo(jogador))
                {
                    // Se não tem peão no jogo, obrigatoriamente coloca um novo peão
                    ColocarPeaoEmJogo(jogador);
                }
                else
                {
                    Console.WriteLine("Você tirou 6! Escolha uma opção:");
                    Console.WriteLine("1 - Colocar um novo peão em jogo");
                    Console.WriteLine("2 - Mover um peão já em jogo");
                    int escolha = LerInteiro(1, 2);

                    if (escolha == 1)
                    {
                        ColocarPeaoEmJogo(jogador);
                    }
                    else
                    {
                        MoverPeao(jogador, valorDado);
                    }
                }
            }
            else if (TemPeaoNoJogo(jogador))
            {
                MoverPeao(jogador, valorDado);
            }
            else
            {
                Log($"Jogador {jogador.Cor} não pode mover nenhum peão.");
            }

            if (valorDado == 6 && jogador.SeisConsecutivos < 3)
            {
                ExecutarTurno();
            }
    }

    private int LancarDado()
    {
        Console.WriteLine("Lançando o dado...\n");
        return dado.Next(1, 7);
    }

    private bool TemPeaoForaDoJogo(Jogador jogador)
    {
        for (int i = 0; i < jogador.Peoes.Length; i++)
        {
            if (!jogador.Peoes[i].EstaEmJogo)
            {
                return true;
            }
        }
        return false;
    }

    private bool TemPeaoNoJogo(Jogador jogador)
    {
        for (int i = 0; i < jogador.Peoes.Length; i++)
        {
            if (jogador.Peoes[i].EstaEmJogo)
            {
                return true;
            }
        }
        return false;
    }

    private void ColocarPeaoEmJogo(Jogador jogador)
    {
        for (int i = 0; i < jogador.Peoes.Length; i++)
        {
            if (!jogador.Peoes[i].EstaEmJogo)
            {
                jogador.Peoes[i].EstaEmJogo = true;
                jogador.Peoes[i].Posicao = jogador.CasaInicial;
                Log($"Jogador {jogador.Cor} colocou um peão em jogo na posição {jogador.CasaInicial}.");
                return;
            }
        }
    }

    private void MoverPeao(Jogador jogador, int casas)
    {
        int escolha;
        Peao peao;

        do
        {
            Console.WriteLine($"Jogador {jogador.Cor}, escolha um peão para mover (1-4):");
            escolha = LerInteiro(1, 4) - 1;
            peao = jogador.Peoes[escolha];

            if (!peao.EstaEmJogo)
            {
                Console.WriteLine("Este peão não está em jogo. Por favor, escolha outro.");
            }
        } while (!peao.EstaEmJogo);

        if (peao.EstaNaCasaFinal)
        {
            MoverNaCasaFinal(peao, casas);
        }
        else
        {
            int distanciaTotal = peao.DistanciaPercorrida + casas;
            int casaFinalJogador = (jogador.CasaInicial + Tabuleiro.TamanhoPista - 1) % Tabuleiro.TamanhoPista;

            if (distanciaTotal > Tabuleiro.TamanhoPista)
            {
                // O peão ultrapassou a casa final do jogador
                int excesso = distanciaTotal - Tabuleiro.TamanhoPista;
                peao.EstaNaCasaFinal = true;
                peao.Posicao = excesso - 1; // -1 porque a posição na estrada final começa em 0
                Log($"Jogador {jogador.Cor} entrou na estrada final, posição {peao.Posicao + 1}.");
            }
            else if (distanciaTotal == Tabuleiro.TamanhoPista)
            {
                // O peão chegou exatamente na casa final do jogador
                peao.EstaNaCasaFinal = true;
                peao.Posicao = 0;
                Log($"Jogador {jogador.Cor} entrou na estrada final, posição 1.");
            }
            else
            {
                // Movimento normal na pista principal
                peao.Posicao = (peao.Posicao + casas) % Tabuleiro.TamanhoPista;
                peao.DistanciaPercorrida = distanciaTotal;
                VerificarCaptura(jogador, peao);
                Log($"Jogador {jogador.Cor} moveu um peão para a posição {peao.Posicao}.");
            }
        }
    }

    private bool EMovimentoValido(Peao peao, int casas)
    {
        return peao.DistanciaPercorrida + casas <= Tabuleiro.TamanhoPista + TamanhoCasaFinal;
    }

    private void MoverNaCasaFinal(Peao peao, int casas)
    {
        int novaPosicao = peao.Posicao + casas;
        if (novaPosicao < Tabuleiro.TamanhoCasaFinal - 1)
        {
            peao.Posicao = novaPosicao;
            Log($"Peão moveu na estrada final para a posição Final({peao.Posicao + 1})");
        }
        else if (novaPosicao == Tabuleiro.TamanhoCasaFinal - 1)
        {
            peao.Posicao = novaPosicao;
            Log($"Peão chegou à casa final (Final(6))!");
        }
        else
        {
            Log($"Movimento inválido na estrada final. O peão deve chegar exatamente à Final(6). Turno perdido.");
        }
    }
    private void VerificarCaptura(Jogador jogadorAtual, Peao peaoAtual)
    {
        bool casaSegura = false;
        for (int i = 0; i < Tabuleiro.CasasSeguras.Length; i++)
        {
            if (Tabuleiro.CasasSeguras[i] == peaoAtual.Posicao)
            {
                casaSegura = true;
                break;
            }
        }
        if (casaSegura)
        {
            return;
        }

        for (int i = 0; i < jogadores.Length; i++)
        {
            Jogador jogador = jogadores[i];
            if (jogador != jogadorAtual)
            {
                for (int j = 0; j < jogador.Peoes.Length; j++)
                {
                    Peao peaoAdversario = jogador.Peoes[j];
                    if (peaoAdversario.Posicao == peaoAtual.Posicao && peaoAdversario.EstaEmJogo && !peaoAdversario.EstaNaCasaFinal)
                    {
                        peaoAdversario.EstaEmJogo = false;
                        peaoAdversario.Posicao = -1;
                        peaoAdversario.DistanciaPercorrida = 0;
                        Log($"Jogador {jogadorAtual.Cor} capturou um peão do jogador {jogador.Cor}!");
                        return;
                    }
                }
            }
        }
    }

    private bool VerificarVitoria()
    {
        for (int i = 0; i < jogadores.Length; i++)
        {
            bool todosNaCasaFinal = true;
            for (int j = 0; j < jogadores[i].Peoes.Length; j++)
            {
                if (!jogadores[i].Peoes[j].EstaNaCasaFinal || jogadores[i].Peoes[j].Posicao != Tabuleiro.TamanhoCasaFinal - 1)
                {
                    todosNaCasaFinal = false;
                    break;
                }
            }
            if (todosNaCasaFinal)
            {
                Log($"Jogador {jogadores[i].Cor} venceu o jogo! Todos os peões chegaram à Final(6)!");
                return true;
            }
        }
        return false;
    }

    private void ExibirTabuleiro()
    {
        Console.WriteLine("=== Ludo ===");

        // Exibir o estado atual dos peões
        Console.WriteLine("\nPosição atual dos peões:");
        for (int i = 0; i < jogadores.Length; i++)
        {
            Console.Write($"Jogador {jogadores[i].Cor}: ");
            for (int j = 0; j < jogadores[i].Peoes.Length; j++)
            {
                Peao peao = jogadores[i].Peoes[j];
                if (!peao.EstaEmJogo)
                {
                    Console.Write("Base ");
                }
                else if (peao.EstaNaCasaFinal)
                {
                    Console.Write($"Final({peao.Posicao+1}) ");
                }
                else
                {
                    Console.Write($"{peao.Posicao} ");
                }
            }
            Console.WriteLine();
        }
    }

    private void ExibirEstadoAtual()
    {
        for (int i = 0; i < jogadores.Length; i++)
        {
            Jogador jogador = jogadores[i];
            Console.Write($"{jogador.Cor}: ");
            for (int j = 0; j < jogador.Peoes.Length; j++)
            {
                if (!jogador.Peoes[j].EstaEmJogo)
                    Console.Write("Base ");
                else if (jogador.Peoes[j].EstaNaCasaFinal)
                    Console.Write($"Final({jogador.Peoes[j].Posicao + 1}) ");
                else
                    Console.Write($"{jogador.Peoes[j].Posicao} ");
            }
            Console.WriteLine();
        }
    }

    private void ExibirStatusJogadores()
    {
        ExibirEstadoAtual();
    }

    private void Log(string mensagem)
    {
        escreveLog.WriteLine($"{DateTime.Now}: {mensagem}");
        Console.WriteLine(mensagem);
    }

    private int LerInteiro(int min, int max)
    {
        int escolha;
        while (true)
        {
            try
            {
                escolha = int.Parse(Console.ReadLine());
                if (escolha >= min && escolha <= max)
                {
                    return escolha;
                }
                Console.WriteLine($"Por favor, digite um número entre {min} e {max}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        }
    }

}*/

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Bem-vindo ao Ludo! ===");
        int numeroJogadores;
        while (true)
        {
            Console.Write("Digite o número de jogadores (2 ou 4): ");
            try
            {
                numeroJogadores = int.Parse(Console.ReadLine());
                if (numeroJogadores == 2 || numeroJogadores == 4)
                {
                    break;
                }
                Console.WriteLine("Número inválido. Por favor, digite 2 ou 4.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        }

        Jogo jogo = new Jogo(numeroJogadores);
        jogo.Jogar();

        Console.WriteLine("Jogo encerrado. Verifique o arquivo de log para detalhes da partida.");
    }
}
