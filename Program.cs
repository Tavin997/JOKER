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
            Console.Clear();
            Console.WriteLine("===== BEM VINDO AO JOKER =====");
            Console.Write("Digite seu nome: ");
            jogador.Nome = Console.ReadLine();
            //Console.WriteLine("Agora escolha o valor da carta Joker (0 - 9): ");
            //jogador.joker = int.Parse(Console.ReadLine());
            Joker(jogador);
        }

        public static void Joker(Jogador jogador)
        {
            int escolha;
            
            do
            {
                Console.Clear();
                Console.WriteLine("O QUE DESEJA?");
                Console.WriteLine("1 - JOGAR\n2 - VISUALIZAR TABELA DE PONTOS\n3 - VISUALIZAR TABELA DE COMBINAÇÕES");
                escolha = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (escolha)
                {

                    case 2:
                        Console.WriteLine("1 = 11\n2 = 2\n3 = 3\n4 = 4\n5 = 5\n6 = 0\n7 = 10\n8 = 8\n9 = 10\nJoker = ?");
                        Console.WriteLine("Pressione qualquer teclar para voltar...");
                        Console.ReadKey(true);
                        
                        break;
                    case 1:
                        jogador.Jogar(jogador);
                        return;
                        
                    case 3:
                        Console.WriteLine("===== COMBINAÇÕES =====");
                        Console.WriteLine("um par = [SOMA].2\ndois pares = [SOMA]^2.2\numa trinca = [SOMA]^3\nsequência = [SOMA]^5\nfull house = [SOMA]^5.3\nquadra = mude um número da mesa\nqintupla = [SOMA]^5.5");
                        Console.WriteLine("Pressione qualquer teclar para voltar...");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        Thread.Sleep(200);
                        break;
                }
            }
            while (true);
            

        }
    }
}
