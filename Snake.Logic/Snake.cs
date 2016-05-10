using Snake.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public struct Segment
    {
        public int X = 0;
        public int Y = 0;
    }

    public class Snake
    {
        Queue<Segment> segments;

        public Snake()
        {
            segments = new Queue<Segment>();
        }

        public void AddSegment(Segment segment)
        {
            segments.Enqueue(segment);
        }

        public Segment DeleteSegment()
        {
            return segments.Dequeue();
        }

        public void Move(Direction direction)
        {
            Segment newSegment = segments.Last();

            switch(direction)
            {
                case Direction.Up : newSegment.Y -= 1; break;
                case Direction.Down: newSegment.Y += 1; break;
                case Direction.Left: newSegment.X -= 1; break;
                case Direction.Right: newSegment.X += 1; break;
            }

            segments.Enqueue(newSegment);
            segments.Dequeue();
        }
    }
}
