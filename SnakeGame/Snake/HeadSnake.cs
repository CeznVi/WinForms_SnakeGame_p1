using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    class HeadSnake : Segment, ISegmentBehavior
    {
        //private Direction _direction;

        //public Direction CurrentDirection
        //{
        //    get { return _direction; }

        //    private set 
        //    {
        //        if(DirectionOperation.Check(value))
        //            _direction = value;
        //    }
        //}

        public HeadSnake(int x, int y, int radius, Direction direction) : base(x, y, radius, direction)
        {
            //CurrentDirection = direction;
        }

        public void Draw(Graphics graphics)
        {

            Bitmap bitmap = new Bitmap(GameResource.snake_head);

            bitmap.MakeTransparent();

            switch(CurrentDirection)
            {
                case Direction.UP:
                    bitmap = ImageAction.Rotate(bitmap, 180);
                    break;
                case Direction.DOWN:
                    bitmap = ImageAction.Rotate(bitmap, 0);
                    break;
                case Direction.LEFT:
                    bitmap = ImageAction.Rotate(bitmap, 90);
                    break;
                case Direction.RIGHT:
                    bitmap = ImageAction.Rotate(bitmap, 270);
                    break;
            }
            graphics.DrawImage(bitmap,new Rectangle(this.X - Radius, this.Y - Radius, this.Radius *2, this.Radius*2));
        
        }


    }
}
