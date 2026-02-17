using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo2
{
    internal class Bot : Jogador
    {
        public Bot(int Fichas) : base(Fichas)
        {
        }

        public void Jogar(Bot rival)
        {
            Console.WriteLine($"{rival.Nome} apostou {rival.Fichas}...");
        }
    }
}
