using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jogador jogador = new Jogador();
            Bot enemy = new Bot();
            Console.Clear();
            while(true)
            {
                Console.Clear();
                Console.WriteLine("===== BEM VINDO AO JOKER =====");
                Console.Write("\nDigite seu nome: ");
                jogador.Nome = Console.ReadLine();
                //Console.WriteLine("Agora escolha o valor da carta Joker (0 - 9): ");
                //jogador.joker = int.Parse(Console.ReadLine());
                int menu = Menu(jogador);
                if(menu == 0)
                {
                    break;
                }
                Mesa(jogador);
            }
            
        }

        public static int Menu(Jogador jogador)
        {            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║           MENU PRINCIPAL       ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║  1 - JOGAR                     ║");
                Console.WriteLine("║  2 - TABELA DE PONTOS          ║");
                Console.WriteLine("║  3 - TABELA DE COMBINAÇÕES     ║");
                Console.WriteLine("║  4 - SAIR                      ║");
                Console.WriteLine("╚════════════════════════════════╝");
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                Console.Clear();
                int escolha;
                switch (tecla.Key)
                {
                    case ConsoleKey.D1:
                        return escolha = 1;

                    case ConsoleKey.D2:
                        Console.WriteLine("===== TABELA DE PONTOS =====");
                        Console.WriteLine("1 = 11 pontos");
                        Console.WriteLine("2 = 2 pontos");
                        Console.WriteLine("3 = 3 pontos");
                        Console.WriteLine("4 = 4 pontos");
                        Console.WriteLine("5 = 5 pontos");
                        Console.WriteLine("6 = 0 pontos");
                        Console.WriteLine("7 = 10 pontos");
                        Console.WriteLine("8 = 8 pontos");
                        Console.WriteLine("9 = 10 pontos");
                        Console.WriteLine("Joker = ?");
                        Console.Write("\nPressione qualquer tecla para voltar...");
                        Console.ReadKey(true);
                        
                        break;
                        
                    case ConsoleKey.D3:
                        Console.WriteLine("===== COMBINAÇÕES =====");
                        Console.WriteLine("UM PAR       = [SOMA].2");
                        Console.WriteLine("DOIS PARES   = [SOMA]^2.2");
                        Console.WriteLine("UMA TRINCA   = [SOMA]^3");
                        Console.WriteLine("SEQUÊNCIA    = [SOMA]^5");
                        Console.WriteLine("FULL HOUSE   = [SOMA]^5.3");
                        Console.WriteLine("QUADRA       = mude um número da mesa");
                        Console.WriteLine("QUINTUPLA    = [SOMA]^5.5");
                        Console.Write("\nPressione qualquer tecla para voltar...");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D4:
                        return escolha = 0;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(200);
                        break;
                }
            }
            

        }

        public static void Mesa(Jogador jogador)
        {
            int rodada = 0;
            do
            {
                Console.Clear();
                rodada = rodada + 1;
                Console.WriteLine($"======== {rodada} RODADA =======");
                Console.WriteLine("======== MESA ========");
                Random num_mesa = new Random();
                int[] slot = new int[3];
                char[] conversao = new char[3];

                Console.Write("||");
                for(int i = 0; i < 3; i++)
                {
                    slot[i] = num_mesa.Next(1, 10);
                    conversao[i] = slot[i].ToString()[0];
                    Console.Write($" {conversao[i]} ||");
                }
                Thread.Sleep(1000);
            }while(rodada < 5);
        }

        //PLANEJO UTILIZAR DESSA FUNÇÃO PARA CONVERTER OS NÚMEROS DA MESA E DAS MÃOS, MAS EU AINDA NEM COMECEI ELA
        //ISSO SÃO SÓ CÓDIGOS COPIADOS PARA REUTILIZAÇÃO.

        /*public static int Conversao_Num()
        {
            char joker = 'J';

            for(int i = 0; i < 3; i++)
            {
                slot[i] = num_mesa.Next(1, 10);
                conversao[i] = slot[i].ToString()[0];
                if (conversao[i] == '0')
                {
                    conversao[i] = (joker);
                }
                    Console.Write($" {conversao[i]} ||");
                }
        }*/
    }
}
