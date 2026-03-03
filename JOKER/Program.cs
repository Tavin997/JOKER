using Jogo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VG = Jogo2.Program.variaveisGlobais;
using static Jogo2.Controller;
using static Jogo2.View;

namespace Jogo2
{
    internal class Program
    {

        public static class variaveisGlobais
        {
            //sistema
            public static int rodada { get; set; } = 0;
            public static int abrir { get; set; } = 1;
            public static bool pausou { get; set; } = false;
            //numeros usuario
            public static int[,] valoresPlayer = new int[5, 2];
            //numeros bot
            public static int[,] valoresBot = new int[5, 2];
            //numeros mesa
            public static int[,] valoresMesa = new int[5, 3];
            //slots
            public static int[] slot = new int[3];
            //somas
            public static int somaMesa;
            public static int somaBot;
            public static int somaPlayer;
            public static int totalPlayer;
            public static int totalBot;
            //numeros/sorteios da partida
            public static bool escolhaJoker;
            public static int joker;
            public static Random random = new Random();
        }

        static void Main()
        {
            Jogador jogador = new Jogador(100);
            Bot rival = new Bot(100);
            Console.Clear();
            while (VG.abrir > 0)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════╗");
                Console.WriteLine("   BEM VINDO AO JOKER   ");
                Console.WriteLine("╚══════════════════════╝");
                Console.WriteLine();
                Console.Write("Digite seu nome: ");
                jogador.Nome = Console.ReadLine();
                jogador.Nome = jogador.Nome.Length > 8 ? jogador.Nome.Substring(0, 8) : jogador.Nome;

                Console.WriteLine();
                Console.Write("Digite o nome de seu rival: ");
                rival.Nome = Console.ReadLine();
                rival.Nome = rival.Nome.ToUpper();
                rival.Nome = rival.Nome.Length > 8 ? rival.Nome.Substring(0, 8) : rival.Nome;
                VG.abrir = Menu();
                Mesa(jogador, rival);
                
            }
            Console.WriteLine();
            Console.WriteLine("╔════════════════════╗");
            Console.WriteLine("║     FECHANDO...    ║");
            Console.WriteLine("╚════════════════════╝");
            Thread.Sleep(200);
        }
    }

}