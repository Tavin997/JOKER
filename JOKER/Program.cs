using Jogo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VG = Jogo2.Program.variaveisGlobais;

namespace Jogo2
{
    internal class Program
    {

        public static class variaveisGlobais
        {
            public static int rodada { get; set; } = 0;
            public static int abrir { get; set; } = 1;
            public static bool pausou { get; set; } = false;
            public static int[] slotPlayer = new int[2];
            public static int[,] valoresPlayer = new int[5, 2];
            public static int[] slotBot = new int[2];
            public static int[,] valoresBot = new int[5, 2];
            public static int[] slotMesa = new int[3];
            public static int[,] valoresMesa = new int[5, 3];
        }

        static void Main()
        {
            Jogador jogador = new Jogador(100);
            Bot rival = new Bot(100);
            Console.Clear();
            while (VG.abrir > 0)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║  BEM VINDO AO JOKER║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine();
                Console.Write("Digite seu nome: ");
                jogador.Nome = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Digite o nome de seu rival: ");
                rival.Nome = Console.ReadLine();
                rival.Nome = rival.Nome.ToUpper();
                VG.abrir = Menu();
                Mesa(jogador, rival);
            }
            Console.WriteLine();
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║     FECHANDO...    ║");
            Console.WriteLine("╚════════════════════╝");
            Thread.Sleep(200);
        }

        public static int Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║       MENU         ║");
                Console.WriteLine("╠════════════════════╣");
                Console.WriteLine("║ 1 - JOGAR          ║");
                Console.WriteLine("║ 2 - PONTOS         ║");
                Console.WriteLine("║ 3 - COMBINAÇÕES    ║");
                Console.WriteLine("║ 4 - SAIR           ║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine();
                Console.Write("ESCOLHA: ");
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                Console.Clear();
                switch (tecla.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        return VG.abrir = 1;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        TabelaPontos();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        TabelaCombinacoes();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        return VG.abrir = 0;


                    default:
                        Console.WriteLine("╔════════════════════╗");
                        Console.WriteLine("║   OPÇÃO INVÁLIDA! ║");
                        Console.WriteLine("╚════════════════════╝");
                        Thread.Sleep(200);
                        break;
                }
            }
        }

        public static void Mesa(Jogador jogador, Bot rival)
        {
            if (VG.abrir != 0)
            {
                VG.rodada = 0;
                while (VG.rodada < 5 && VG.abrir != 0)
                {
                    Console.Clear();

                    Console.WriteLine("╔════════════════════╗");
                    Console.WriteLine("║       JOKER        ║");
                    Console.WriteLine("╠════════════════════╣");
                    Console.WriteLine($"║   {VG.rodada + 1}ª RODADA DE 5   ║");
                    Console.WriteLine("╚════════════════════╝");
                    Console.WriteLine();

                    MaoMesa();
                    MaoBot(rival);
                    MaoPlayer();
                    VG.pausou = false;
                    AcaoPlayer(jogador);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void MaoMesa()
        {
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║       MESA         ║");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");

            Random num_mesa = new Random();
            if (VG.pausou == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    VG.slotMesa[i] = num_mesa.Next(1, 10);
                    VG.valoresMesa[VG.rodada, i] = VG.slotMesa[i];

                    Console.Write($" {VG.valoresMesa[VG.rodada, i]} ║");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($" {VG.valoresMesa[VG.rodada, i]} ║");
                }
            }

            Console.WriteLine("\n╚════════════════════╝");
            Console.WriteLine();
        }

        public static void MaoPlayer()
        {
            Random num_mesa = new Random();

            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║      SUA MÃO       ║");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");

            if (VG.pausou == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    VG.slotPlayer[i] = num_mesa.Next(10);
                    VG.slotPlayer[i] = VG.slotPlayer[i] == VG.slotBot[i] ? num_mesa.Next(1, 10) : VG.slotPlayer[i]; // compara se os dois numeros são iguais, se sim, é gerado outro numero
                    VG.valoresPlayer[VG.rodada, i] = VG.slotPlayer[i];

                    Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ║");
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ║");
                }
            }

            Console.WriteLine("\n╚════════════════════╝");

            VG.rodada++;
        }

        public static void MaoBot(Bot rival)
        {
            Random num_mesa = new Random();

            string nomeRival = rival.Nome.Length > 8 ? rival.Nome.Substring(0, 8) : rival.Nome;
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine($"║ {nomeRival,-8}      ║");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");

            if (VG.pausou == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    VG.slotBot[i] = num_mesa.Next(10);
                    VG.valoresBot[VG.rodada, i] = VG.slotBot[i];

                    Console.Write($" {VG.valoresBot[VG.rodada, i]} ║");
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.Write($" {VG.valoresBot[VG.rodada, i]} ║");
                }
            }

            Console.WriteLine("\n╚════════════════════╝");
        }

        public static void AcaoPlayer(Jogador jogador)
        {
            if (VG.abrir != 0)
            {
                Console.WriteLine("╔════════════════════╗");
                Console.WriteLine("║       AÇÕES        ║");
                Console.WriteLine("╠════════════════════╣");
                Console.WriteLine("║ [1] APOSTAR        ║");
                Console.WriteLine("║ [2] TROCAR         ║");
                Console.WriteLine("║ [3] MENU           ║");
                Console.WriteLine("╚════════════════════╝");
                Console.WriteLine();
                Console.Write("ESCOLHA: ");

                while (VG.abrir > 0)
                {
                    var tecla = Console.ReadKey(true);

                    switch (tecla.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine();
                            Console.WriteLine("╔════════════════════╗");
                            Console.WriteLine("║    APOSTANDO...    ║");
                            Console.WriteLine("╚════════════════════╝");
                            jogador.Jogar(jogador);
                            break;

                        case ConsoleKey.D2:
                            Console.WriteLine();
                            Console.WriteLine("╔════════════════════╗");
                            Console.WriteLine("║   TROCA REALIZADA  ║");
                            Console.WriteLine("╚════════════════════╝");
                            Thread.Sleep(200);
                            break;

                        case ConsoleKey.D3:
                            Console.WriteLine();
                            Console.WriteLine("╔════════════════════╗");
                            Console.WriteLine("║    ABRINDO MENU... ║");
                            Console.WriteLine("╚════════════════════╝");
                            Thread.Sleep(200);
                            VG.rodada -= 1;
                            VG.pausou = true;
                            Menu();
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("╔════════════════════╗");
                            Console.WriteLine("║  OPÇÃO INVÁLIDA!  ║");
                            Console.WriteLine("╚════════════════════╝");
                            Thread.Sleep(200);
                            Console.WriteLine();
                            Console.Write("ESCOLHA: ");
                            continue;
                    }
                    break;
                }
            }
        }

        public static void TabelaPontos()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║   TABELA PONTOS    ║");
            Console.WriteLine("╠═══════╪════════════╣");
            Console.WriteLine("║ Nº    │ PONTOS     ║");
            Console.WriteLine("╠═══════╪════════════╣");
            Console.WriteLine("║ 1     │ 11         ║");
            Console.WriteLine("║ 2     │ 02         ║");
            Console.WriteLine("║ 3     │ 03         ║");
            Console.WriteLine("║ 4     │ 04         ║");
            Console.WriteLine("║ 5     │ 05         ║");
            Console.WriteLine("║ 6     │ 00         ║");
            Console.WriteLine("║ 7     │ 10         ║");
            Console.WriteLine("║ 8     │ 08         ║");
            Console.WriteLine("║ 9     │ 10         ║");
            Console.WriteLine("║ JOKER │ ?          ║");
            Console.WriteLine("╚═══════╧════════════╝");
            Console.WriteLine();
            Console.Write("Pressione qualquer tecla para voltar...");
            Console.ReadKey(true);
        }

        public static void TabelaCombinacoes()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║          COMBINAÇÕES           ║");
            Console.WriteLine("╠═══════════════╪════════════════╣");
            Console.WriteLine("║ TIPO          │     EXMULT.    ║");
            Console.WriteLine("╠═══════════════╪════════════════╣");
            Console.WriteLine("║ UM PAR        │ [SOMA] X 2     ║");
            Console.WriteLine("║ DOIS PARES    │ [SOMA] ^ 2 X 2 ║");
            Console.WriteLine("║ TRINCA        │ [SOMA] ^ 3     ║");
            Console.WriteLine("║ SEQUÊNCIA     │ [SOMA] ^ 5     ║");
            Console.WriteLine("║ FULL HOUSE    │ [SOMA] ^ 5 X 3 ║");
            Console.WriteLine("║ QUADRA        │ MUDE UM NÚMERO ║");
            Console.WriteLine("║ QUINTUPLA     │ [SOMA] ^ 5 X 5 ║");
            Console.WriteLine("║ JACKPOT       │ [SOMA] ^ 10    ║");
            Console.WriteLine("╚═══════════════╧════════════════╝");
            Console.WriteLine();
            Console.Write("[E]Ver exemplos | pressione qualquer tecla para voltar... ");
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════╗");
                Console.WriteLine("║           EXEMPLOS        ║");
                Console.WriteLine("╠═══════════════╪═══════════╣");
                Console.WriteLine("║ UM PAR        │ 7 7 - - - ║");
                Console.WriteLine("║ DOIS PARES    │ 7 7 1 1 - ║");
                Console.WriteLine("║ TRINCA        │ 7 7 7 - - ║");
                Console.WriteLine("║ SEQUÊNCIA     │ 7 5 4 6 3 ║");
                Console.WriteLine("║ FULL HOUSE    │ 7 7 7 3 3 ║");
                Console.WriteLine("║ QUADRA        │ 7 7 7 7 - ║");
                Console.WriteLine("║ QUINTUPLA     │ 7 7 7 7 7 ║");
                Console.WriteLine("║ JACKPOT       │ 7 7 7 6 6 ║");
                Console.WriteLine("╚═══════════════╧═══════════╝");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla...");
                Console.ReadKey(true);
            }
        }
    }
}