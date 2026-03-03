using Jogo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VG = Jogo2.Program.variaveisGlobais;
using static Jogo2.Controller;

namespace Jogo2
{
    public static class View
    {
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
                        Console.WriteLine("║   OPÇÃO INVÁLIDA!  ║");
                        Console.WriteLine("╚════════════════════╝");
                        Thread.Sleep(200);
                        break;
                }
            }
        }

        public static void AcaoPlayer(Jogador jogador, Bot rival)
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
                calcularMao(jogador, rival);
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
            Console.WriteLine("║ 6     │ 06         ║");
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
            Console.WriteLine("║ QUADRA        │ [SOMA] ^ 5 X 5 ║");
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
                Console.WriteLine("║ JACKPOT       │ 7 7 7 7 7 ║");
                Console.WriteLine("╚═══════════════╧═══════════╝");
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla...");
                Console.ReadKey(true);
            }
        }
    }
}