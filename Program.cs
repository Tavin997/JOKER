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
            public static int abrir { get; set; } = 1;
            //VARIÁVEL PARA VERIFICAR SE O JOGO FOI PAUSADO OU NÃO
            public static bool pausou { get; set; } = false;

            public static int[,] valoresPlayer = new int[5, 3];
        }
        static void Main()
        {
            Jogador jogador = new Jogador();
            Bot enemy = new Bot();
            Console.Clear();
            while (VG.abrir > 0)
            {
                Console.Clear();
                Console.WriteLine("===== BEM VINDO AO JOKER =====");
                Console.Write("\nDigite seu nome: ");
                jogador.Nome = Console.ReadLine();
                //Console.WriteLine("Agora escolha o valor da carta Joker (0 - 9): ");
                //jogador.joker = int.Parse(Console.ReadLine());
                VG.abrir = Menu();
                Mesa(jogador);
            }
            Console.WriteLine("Fechando...");
            Thread.Sleep(200);
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
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(200);
                        break;
                }
            }


        }

        //MESA - ONDE O JOGO VAI ACONTECER
        public static void Mesa(Jogador jogador)
        {
            if (VG.abrir != 0)
            {
                VG.rodada = 0;
                Random num_mesa = new Random();
                int[] slot = new int[3];
                int[,] valores = new int[5, 3];
                
                bool mesaGerou = false;

                while (variaveisGlobais.rodada < 5 && VG.abrir != 0)
                {
                    Console.Clear();
                    Console.WriteLine($"======== {VG.rodada + 1} RODADA ========");
                    Console.WriteLine("========== MESA ==========");

                    Console.Write("||");

                    //SE O JOGO NÃO FOI PAUSADO ELE GERA OS NÚMEROS DA RODADA
                    if (VG.pausou == false)
                    {
                        for (int i = 0; i < 3; i++)
                        {

                                slot[i] = num_mesa.Next(1, 10);
                                //slot[i] = slot[i] == 0 ? num_mesa.Next(1, 10) : slot[i];
                                valores[VG.rodada, i] = slot[i];
                                Console.Write($" {valores[VG.rodada, i]} ||");
                                //mesaGerou = i == 2 ? true : false;
                                if(i == 2) mesaPlayer(); 
                                
                       
                        }
                    }
                    //SE O JOGO FOI PAUSADO ELE SÓ EXIBE OS NÚMEROS DA MESA QUE JÁ FORAM GERADOS ANTERIORMENTE
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            //slot[i] = slot[i] == 0 ? num_mesa.Next(1, 10) : slot[i];
                            Console.Write($" {valores[VG.rodada, i]} ||");
                            Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ||");
                        }
                    }

                    Console.WriteLine("\n========== ---- ==========");

                    //ZERA A VARIÁVEL PARA CONSEGUIR GERAR OS NÚMEROS DA PRÓXIMA RODADA
                    VG.pausou = false;
                    AcaoPlayer(jogador);
                    Thread.Sleep(1000);
                    
                }
            }
        }

        public static void mesaPlayer()
        {
            int[] slotPlayer = new int[2];
            
            Random num_mesa = new Random();
            Console.WriteLine();
            Console.WriteLine("========== SUA MÃO ==========");
            for (int i = 0; i < 2; i++)
            {

                    
                    slotPlayer[i] = num_mesa.Next(0, 9);
                    VG.valoresPlayer[VG.rodada, i] = slotPlayer[i];
                    Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ||");
                   



            }
            VG.rodada = VG.rodada + 1;

        }

    

        //AÇÃO DO JOGADOR DURANTE O JOGO
        public static void AcaoPlayer(Jogador jogador)
        {
            if (VG.abrir != 0)
            {
                Console.WriteLine("[1]APOSTAR A MÃO\n[2]TROCAR NÚMERO\n[3]ABRIR MENU");

                while (VG.abrir > 0)
                {
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
                            VG.rodada -= 1;
                            //DECLRA QUE O JOGO FOI PAUSADO
                            VG.pausou = true;
                            Menu();
                            break;
                        default:
                            Console.WriteLine("AÇÃO INVÁLIDA!");
                            break;
                    }
                    break;
                }
            }
        }

        //TABELA DE PONTOS
        public static void TabelaPontos()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║   TABELA DE PONTOS     ║");
            Console.WriteLine("╠════════════════════════╣");
            Console.WriteLine("║  NÚMERO  │   PONTOS    ║");
            Console.WriteLine("╠══════════╪═════════════╣");
            Console.WriteLine("║    1     │    11       ║");
            Console.WriteLine("║    2     │    02       ║");
            Console.WriteLine("║    3     │    03       ║");
            Console.WriteLine("║    4     │    04       ║");
            Console.WriteLine("║    5     │    05       ║");
            Console.WriteLine("║    6     │    00       ║");
            Console.WriteLine("║    7     │    10       ║");
            Console.WriteLine("║    8     │    08       ║");
            Console.WriteLine("║    9     │    10       ║");
            Console.WriteLine("║   JOKER  │     ?       ║");
            Console.WriteLine("╚══════════╧═════════════╝");
            Console.Write("\nPressione qualquer tecla para voltar...");
            Console.ReadKey(true);
        }

        //TABELA DE COMBINAÇÕES POSSÍVEIS
        public static void TabelaCombinacoes()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║           TABELA DE COMBINAÇÕES - PONTOS          ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════╣");
            Console.WriteLine("║  COMBINAÇÃO   │           EXMULT.                 ║");
            Console.WriteLine("╠═══════════════╪═══════════════════════════════════╣");
            Console.WriteLine("║  UM PAR       │  [SOMA] × 2                       ║");
            Console.WriteLine("║  DOIS PARES   │  [SOMA]² × 2                      ║");
            Console.WriteLine("║  UMA TRINCA   │  [SOMA]³                          ║");
            Console.WriteLine("║  SEQUÊNCIA    │  [SOMA]^5                         ║");
            Console.WriteLine("║  FULL HOUSE   │  [SOMA]^5 × 3                     ║");
            Console.WriteLine("║  QUADRA       │  MUDE UM NÚMERO DA MESA           ║");
            Console.WriteLine("║  QUINTUPLA    │  [SOMA]^5  5                      ║");
            Console.WriteLine("║  JACKPOT      │  [SOMA]^10                        ║");
            Console.WriteLine("╚═══════════════╧═══════════════════════════════════╝");

            Console.Write("\nPressione qualquer tecla para voltar.\nPressione [E] para ver os exemplos...");
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            if (tecla.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                    EXEMPLOS DE COMBINAÇÕES                   ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║  UM PAR       │  7 │ 7 │ 1 │ 6 │ 3  │ →  UM PAR SOLITÁRIO    ║");
                Console.WriteLine("║  DOIS PARES   │  7 │ 7 │ 1 │ 1 │ 3  │ →  DUAS DUPLAS         ║");
                Console.WriteLine("║  UMA TRINCA   │  7 │ 7 │ 7 │ 6 │ 3  │ →  TRÊS IGUAIS!        ║");
                Console.WriteLine("║  SEQUÊNCIA    │  7 │ 5 │ 4 │ 6 │ 3  │ →  3, 4, 5, 6, 7       ║");
                Console.WriteLine("║  FULL HOUSE   │  7 │ 7 │ 7 │ 3 │ 3  │ →  UMA TRINCA + UM PAR ║");
                Console.WriteLine("║  QUADRA       │  7 │ 7 │ 7 │ 7 │ 3  │ →  QUATRO IGUAIS!      ║");
                Console.WriteLine("║  QUINTUPLA    │  7 │ 7 │ 7 │ 7 │ 7  │ →  TODOS SLOTS!        ║");
                Console.WriteLine("║  JACKPOT      │  7 │ 7 │ 7 │ 6 │ 6  │ →  UMA TRINCA + 0      ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");

                Console.Write("\nPressione qualquer tecla para voltar para o menu...");
                Console.ReadKey(true);
            }
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