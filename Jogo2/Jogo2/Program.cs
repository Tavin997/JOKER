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
            // Campo estático acessível de qualquer lugar
            public static int rodada { get; set; } = 0;
        }
        static void Main(string[] args)
        {
            Jogador jogador = new Jogador();
            Bot enemy = new Bot();
            Console.Clear();
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("===== BEM VINDO AO JOKER =====");
                Console.Write("\nDigite seu nome: ");
                jogador.Nome = Console.ReadLine();
                //Console.WriteLine("Agora escolha o valor da carta Joker (0 - 9): ");
                //jogador.joker = int.Parse(Console.ReadLine());
                int menu = Menu();
                if (menu == 0)
                {
                    break;
                }
                Mesa(jogador);
            }

        }

        //MENU PRINCIPAL
        public static int Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║              MENU              ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║  1 - JOGAR                     ║");
                Console.WriteLine("║  2 - TABELA DE PONTOS          ║");
                Console.WriteLine("║  3 - TABELA DE COMBINAÇÕES     ║");
                Console.WriteLine("║  4 - SAIR DO JOGO              ║");
                Console.WriteLine("╚════════════════════════════════╝");
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                Console.Clear();
                int escolha;
                switch (tecla.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        return escolha = 1;

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
                        return escolha = 0;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(200);
                        break;
                }
            }


        }

        //MESA - ONDE O JOGO VAI ACONTECER
        public static void Mesa(Jogador jogador)
        {
           
            while(variaveisGlobais.rodada < 5)
            {
                /*System.Threading.Thread.Sleep(100);
                ApagarUltimasLinhas(8);*/
                
                Console.WriteLine($"======== {VG.rodada + 1} RODADA ========");
                Console.WriteLine("========== MESA ==========");
                Random num_mesa = new Random();
                int[] slot = new int[3];
                int[][] valores = new int[5][]; 
                char[] conversao = new char[3];
                

                Console.Write("||");
                for (int i = 0; i < 3; i++)
                {
                    slot[i] = slot[i] == 0 ? num_mesa.Next(1, 10) : slot[i];
                    valores[VG.rodada] = new int[3];
                    valores[VG.rodada][i] = slot[i];
                    conversao[i] = valores[VG.rodada][i].ToString()[0];
                    Console.Write($" {conversao[i]} ||");
                }
                Console.WriteLine("\n============ ---- ============");

                AcaoPlayer(jogador);
                Thread.Sleep(1000);
                VG.rodada = VG.rodada + 1;
            } 
        }
        
        //AÇÃO DO JOGADOR DURANTE O JOGO
        public static void AcaoPlayer(Jogador jogador)
        {
            Console.WriteLine("[1]APOSTAR A MÃO\n[2]TROCAR NÚMERO\n[3]ABRIR MENU");
            var tecla = Console.ReadKey(true);
            switch (tecla.Key)
            {
                case ConsoleKey.D1:
                    jogador.Jogar(jogador);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("trocou a mão");
                    break;
                case ConsoleKey.D3:
                    Menu();
                    VG.rodada -= 1;
                    break;
            }
        }

        //TABELA DE PONTOS
        public static void TabelaPontos()
        {
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
        }

        //TABELA DE COMBINAÇÕES POSSÍVEIS
        public static void TabelaCombinacoes()
        {
            Console.Clear();
            Console.WriteLine("===== COMBINAÇÕES - PONTOS =====");
            Console.WriteLine("UM PAR       = [SOMA].2");
            Console.WriteLine("DOIS PARES   = [SOMA]^2.2");
            Console.WriteLine("UMA TRINCA   = [SOMA]^3");
            Console.WriteLine("SEQUÊNCIA    = [SOMA]^5");
            Console.WriteLine("FULL HOUSE   = [SOMA]^5.3");
            Console.WriteLine("QUADRA       = mude um número da mesa");
            Console.WriteLine("QUINTUPLA    = [SOMA]^5.5");
            Console.WriteLine("JACKPOT      = [SOMA]^10");
            Console.Write("\nPressione qualquer tecla para voltar.\nPressione [E] para ver os exemplos...");
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("===== COMBINAÇÕES - EXEMPLOS =====");
                Console.WriteLine("UM PAR       = || 7 || 7 || 1 || ");
                Console.WriteLine("DOIS PARES   = [SOMA]^2.2");
                Console.WriteLine("UMA TRINCA   = [SOMA]^3");
                Console.WriteLine("SEQUÊNCIA    = [SOMA]^5");
                Console.WriteLine("FULL HOUSE   = [SOMA]^5.3");
                Console.WriteLine("QUADRA       = mude um número da mesa");
                Console.WriteLine("QUINTUPLA    = [SOMA]^5.5");
                Console.Write("\nPressione qualquer tecla para voltar para o menu...");
                Console.ReadKey(true);
            }
        }


        //CATEI ISSO AQUI DO CHAT...
        /*static void ApagarUltimasLinhas(int linhasParaApagar)
        {
            try
            {
                // Verifica se há linhas suficientes para apagar
                int linhasDisponiveis = Console.CursorTop;
                
                if (linhasDisponiveis <= 0)
                {
                    // Se não há linhas acima, apenas retorna sem fazer nada
                    return;
                }
                
                // Garante que não vamos tentar apagar mais linhas do que existem
                int linhasParaApagarReal = Math.Min(linhasParaApagar, linhasDisponiveis);
                
                // Calcula a nova posição, garantindo que não seja negativa
                int novaPosicaoTop = Math.Max(0, Console.CursorTop - linhasParaApagarReal);
                
                // Posiciona o cursor
                Console.SetCursorPosition(0, novaPosicaoTop);
                
                // Limpa as linhas
                for (int i = 0; i < linhasParaApagarReal; i++)
                {
                    Console.Write(new string(' ', Console.BufferWidth));
                }
                
                // Volta o cursor para a posição correta
                Console.SetCursorPosition(0, novaPosicaoTop);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Tratamento de segurança caso algo ainda dê errado
                Console.Clear();
            }
        }*/

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