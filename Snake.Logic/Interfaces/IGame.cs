using Snake.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic.Interfaces
{
    public interface IGame
    {
        void Initialization(int x, int y);
        void Start();
        void Step();
        void Stop();
        void Intstruction(Direction direction);

        GameState State { get; }
    }
}
