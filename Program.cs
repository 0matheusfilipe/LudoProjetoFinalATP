using System;
using System.IO;

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
