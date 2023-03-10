using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    class Snake : ISegmentBehavior
    {
        List<Segment> _snake;
        
        public Snake()
        {
            _snake = new List<Segment>();

            _snake.Add(new HeadSnake(60,60,15,Direction.UP));

            _snake.Add(new SegmentSnake(60, 90, 15, Direction.VERTICAL));
            _snake.Add(new SegmentSnake(60, 120, 15, Direction.RIGHTUP));
            _snake.Add(new SegmentSnake(90, 120, 15, Direction.LEFTDOWN));

            _snake.Add(new TailSnake(90, 150, 15, Direction.DOWN));
            
            ////Старая версия
            //_snake.Add(new SegmentSnake(
            //            Head.X - Head.Radius * 2,
            //            Head.Y,
            //            Head.Radius,
            //            Color.LawnGreen

            //            ));
        }

        public HeadSnake Head
        {
            get 
            {
                return (HeadSnake)_snake.FirstOrDefault();
            }
        }

        public void Draw(Graphics graphics)
        {
            
            foreach (var item in _snake) 
            { 
                if(item is HeadSnake) 
                {
                    ((HeadSnake)item).Draw(graphics);
                }
                else if (item is SegmentSnake) 
                { 
                    ((SegmentSnake)item).Draw(graphics);
                }
                else if(item is TailSnake) 
                {
                    ((TailSnake)item).Draw(graphics);
                }
            }
        }

        

    }
}
