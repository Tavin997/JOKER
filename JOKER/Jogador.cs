using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo2
{
    internal class Jogador
    {
        private string _nome;
        private int _fichas;
        private int _pontos;

        public string Nome { get; set; }
        public int Fichas { get; set; }
        public int Pontos { get; set; }

        public void Jogar(Jogador jogador)
        {
            Console.WriteLine($"{jogador.Nome} apostou {jogador.Fichas}...");
        }

        public Jogador(int _fichas)
        {
            _fichas = Fichas;
        }
    }
}