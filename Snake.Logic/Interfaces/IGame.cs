using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic.Interfaces
{
    public interface IGame
    {
        public void Initialization();
        public void Start();
        public void Step();
        public void Stop();
    }
}
