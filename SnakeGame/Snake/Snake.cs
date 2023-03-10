using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame.Snake
{
    class Snake : ISegmentBehavior
    {
        List<Segment> _snake;
        
        public Snake()
        {
            _snake = new List<Segment>();

            _snake.Add(new HeadSnake(30,500,15,Direction.UP));

            _snake.Add(new SegmentSnake(30, 530, 15, Direction.VERTICAL));
            //_snake.Add(new SegmentSnake(30, 550, 15, Direction.RIGHTUP));
            //_snake.Add(new SegmentSnake(60, 550, 15, Direction.LEFTDOWN));

           // _snake.Add(new TailSnake(60, 580, 15, Direction.DOWN));
            
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

        public void Move()
        {
            int x = 0, y = 0;

            Direction currDir = Direction.NULL;
            Direction lastDir = Direction.NULL;

            foreach(var item in _snake) 
            {
                
                if(item is HeadSnake) 
                {
                    currDir = item.CurrentDirection;
                    
                    if(currDir == Direction.UP) 
                        item.Y -= item.Radius * 2;
                    else if (currDir == Direction.DOWN)
                        item.Y +=  item.Radius * 2;
                    else if (currDir == Direction.LEFT)
                        item.X += item.Radius * 2;
                    else if (currDir == Direction.RIGHT)
                        item.X -= item.Radius * 2;
                }
                else
                {
                    item.CurrentDirection = lastDir;
                    item.X = x;
                    item.Y = y;
                }



                lastDir = item.CurrentDirection;
                x = item.X;
                y = item.Y;

            }


        }

    }
}
