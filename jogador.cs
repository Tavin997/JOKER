using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo
{
    internal class Jogador
    {
        private string _nome;
        private int _fichas;
        private int _pontos;
        public int joker;
        
        public string Nome { get; set; }
        public string Fichas { get; set; }
        public string Pontos { get; set; }

        public void Jogar(Jogador jogador)
        {
            Console.WriteLine($"{jogador.Nome} jogou...");
            Console.ReadKey();
            Program.Joker(jogador);
        }

    }
}
