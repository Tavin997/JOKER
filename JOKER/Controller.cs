using Jogo2;
using static Jogo2.Program;
using VG = Jogo2.Program.variaveisGlobais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Jogo2.View;

namespace Jogo2
{
    public static class Controller
    {
        public static void Mesa(Jogador jogador, Bot rival)
        {
            if (VG.abrir != 0)
            {
                VG.rodada = 0;
                while (VG.rodada < 5 && VG.abrir != 0)
                {
                    VG.escolhaJoker = false;
                    if(VG.pausou == false)
                    {
                        VG.totalBot = 0; VG.totalPlayer = 0; VG.somaBot = 0; VG.somaMesa = 0; VG.somaPlayer = 0; VG.joker = 0;
                    } 
                    Console.Clear();

                    Console.WriteLine("╔════════════════════╗");
                    Console.WriteLine("        JOKER         ");
                    Console.WriteLine("╠════════════════════╣");
                    Console.WriteLine($"   {VG.rodada + 1}ª RODADA DE 5   ");
                    Console.WriteLine("╚════════════════════╝");
                    Console.WriteLine();

                    MaoMesa();
                    MaoBot(rival);
                    MaoPlayer();
                    VG.pausou = false;

                    if(VG.escolhaJoker == true) GerarJoker();
                    if(VG.pausou == false) AcaoPlayer(jogador, rival);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void MaoMesa()
        {
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("        MESA          ");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");
            if (VG.pausou == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    VG.slot[i] = VG.random.Next(1, 10);
                    VG.valoresMesa[VG.rodada, i] = VG.slot[i];

                    // ATRIBUI O VALOR DE CADA NUMERO CONFORME A TABELA DE VALORES
                    if (VG.slot[i] == 1) VG.somaMesa += 11;
                    else if(VG.slot[i] == 7 || VG.slot[i] == 9) VG.somaMesa += 10;
                    else
                    {
                        VG.somaMesa += VG.slot[i];
                    }

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
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("       SUA MÃO        ");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");
             
            if (VG.pausou == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    //gera números aleatórios pro player e os recebe
                    VG.slot[i] = VG.random.Next(10);
                    VG.valoresPlayer[VG.rodada, i] = VG.slot[i];

                    //escolha do joker
                    if (VG.valoresPlayer[VG.rodada, i] == 0)
                    {
                        Console.Write($" J = {VG.joker} ║");
                        //sinal que joker ainda não foi inserido
                        VG.escolhaJoker = true;
                    }

                    switch(VG.slot[i])
                    {
                        case 1:
                            VG.somaPlayer += 11;
                            break;
                        case 9:
                        case 7:
                            VG.somaPlayer += 10;
                            break;
                        default:
                            VG.somaPlayer += VG.slot[i];
                            break;
                    }

                    if(VG.valoresPlayer[VG.rodada, i] != 0) Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ║");
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (VG.valoresPlayer[VG.rodada, i] == 0) Console.Write($" J = {VG.joker} ║");
                    if(VG.valoresPlayer[VG.rodada, i] != 0) Console.Write($" {VG.valoresPlayer[VG.rodada, i]} ║");
                }
            }
            Console.WriteLine("\n╚════════════════════╝");

            VG.rodada++;
        }

        public static void MaoBot(Bot rival)
        {

            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine($"  MÃO DE {rival.Nome} ");
            Console.WriteLine("╠════════════════════╣");
            Console.Write("║");

            if (VG.pausou == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    VG.slot[i] = VG.random.Next(1, 10);
                    VG.valoresBot[VG.rodada, i] = VG.slot[i];
                    switch (VG.slot[i])
                    {
                        case 1:
                            VG.somaBot += 11;
                            break;
                        case 9:
                        case 7:
                            VG.somaBot += 10;
                            break;
                        default:
                            VG.somaBot += VG.slot[i];
                            break;
                    }
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

        public static void calcularMao(Jogador jogador, Bot rival)
        {
            VG.totalPlayer = VG.somaMesa + VG.somaPlayer;
            VG.totalBot = VG.somaMesa + VG.somaBot;

            Console.WriteLine($"\nPontos da sua mão: {VG.totalPlayer}");
            Console.WriteLine($"Pontos da mão de {rival.Nome}: {VG.totalBot}");
        }

        public static void GerarJoker()
        {
            VG.pausou = true;
            VG.rodada -= 1;
            Console.WriteLine("ESCOLHA UM NÚMERO PARA O JOKER!");
            int escolha = int.Parse(Console.ReadLine());
            while(true)
            {
                if(escolha > 0 && escolha < 10)
                {
                    VG.joker = escolha;
                    break;
                }
                else
                {
                    Console.WriteLine("ESCOLHA INVÁLIDA!");
                }
            }

            switch(escolha)
            {
                case 1:
                    VG.somaPlayer += 11;
                    break;
                case 9:
                case 7:
                    VG.somaPlayer += 10;
                    break;
                default:
                    VG.somaPlayer += escolha;
                    break;
            }
            
        }

        public static void Combinacao()
        {
            
        }
    }
}