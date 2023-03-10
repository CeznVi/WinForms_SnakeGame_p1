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
            _snake.Add(new SegmentSnake(30, 560, 15, Direction.LU));
            _snake.Add(new SegmentSnake(60, 560, 15, Direction.UL));
            _snake.Add(new TailSnake(60, 590, 15, Direction.UP));


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
            int xlast = 0, ylast = 0;

            Direction currDir = Direction.NULL;
            Direction lastDir = Direction.NULL;

            foreach(var item in _snake) 
            {
                currDir = item.CurrentDirection;
                x = item.X;
                y = item.Y;

                if (item is HeadSnake) 
                {
                     
                    xlast = item.X;
                    ylast = item.Y;

                    if (currDir == Direction.UP) 
                        item.Y -= item.Radius * 2;
                    else if (currDir == Direction.DOWN)
                        item.Y +=  item.Radius * 2;
                    else if (currDir == Direction.LEFT)
                        item.X += item.Radius * 2;
                    else if (currDir == Direction.RIGHT)
                        item.X -= item.Radius * 2;
                }
                else if(item is SegmentSnake)
                {
                    item.CurrentDirection = lastDir;

                    item.X = xlast;
                    item.Y = ylast;

                }
                else if (item is TailSnake)
                {
                    if(lastDir == Direction.UP)
                        item.CurrentDirection = Direction.UP;
                    else if (lastDir == Direction.DOWN)
                        item.CurrentDirection = Direction.DOWN;
                    else if (lastDir == Direction.LEFT)
                        item.CurrentDirection = Direction.LEFT;
                    else if (lastDir == Direction.RIGHT)
                        item.CurrentDirection = Direction.RIGHT;
                    
                    else if (lastDir == Direction.UL)
                        item.CurrentDirection = Direction.LEFT;
                    else if (lastDir == Direction.UR)
                        item.CurrentDirection = Direction.RIGHT;


                    else if (lastDir == Direction.LU)
                        item.CurrentDirection = Direction.UP;


                    ///////ДОДЕЛАТЬ

                    //else if (lastDir == Direction.RIGHTUP)
                    //    item.CurrentDirection = Direction.RIGHT;

                    //item.CurrentDirection = lastDir;

                    item.X = xlast;
                    item.Y = ylast;

                }
                xlast = x;
                ylast = y;
                lastDir = currDir;

            }


        }

    }
}
