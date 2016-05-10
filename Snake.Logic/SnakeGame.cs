using Snake.Logic.Enums;
using Snake.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeGame : IGame
    {
        Item[,] region;
        Direction currentDirection;

        public SnakeGame()
        {
            Initialization(30, 40);
        }
        public void Initialization(int x, int y)
        {
            region = new Item[x, y];
            currentDirection = Direction.Right;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
