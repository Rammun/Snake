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
        void Initialization();
        void Start();
        void Step();
        void Stop();
        void Instruction(Direction direction);
        Action<Point, Item> Draw { get; set; }

        GameState State { get; }

    }
}
