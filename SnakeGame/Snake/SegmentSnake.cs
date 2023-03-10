using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    class SegmentSnake : Segment, ISegmentBehavior
    {
        ////Старая версия
        //public SegmentSnake(int x, int y, int radius, Color color):base(x, y, radius)
        //{
        //    Color = color;
        //}

        //public void Draw(Graphics graphics)
        //{
        //    graphics.FillRectangle(new SolidBrush(this.Color),
        //        this.X - Radius,
        //        this.Y - Radius,
        //        this.Radius *2,
        //        this.Radius*2
        //        );
        //}

        //private Direction _direction;

        //public Direction CurrentDirection
        //{
        //    get { return _direction; }

        //    private set
        //    {
        //        if (DirectionOperation.Check(value))
        //            _direction = value;
        //    }
        //}

        public SegmentSnake(int x, int y, int radius, Direction direction) : base(x, y, radius, direction)
        {
            //CurrentDirection = direction;
        }

        public void Draw(Graphics graphics)
        {
            Bitmap bitmap;

            ///В зависимости от директа используем разные картинки
            if (CurrentDirection == Direction.HORIZONTAL
                || CurrentDirection == Direction.VERTICAL)
                bitmap = new Bitmap(GameResource.body);
            else if(CurrentDirection == Direction.LEFT
                    || CurrentDirection == Direction.RIGHT)
                bitmap = new Bitmap(GameResource.body);
            else if (CurrentDirection == Direction.UP
                    || CurrentDirection == Direction.DOWN)
                bitmap = new Bitmap(GameResource.body);
            else
                bitmap = new Bitmap(GameResource.snake_angle);

            bitmap.MakeTransparent();

            switch (CurrentDirection)
            {

                case Direction.RIGHT:
                case Direction.LEFT:
                case Direction.HORIZONTAL:
                    bitmap = ImageAction.Rotate(bitmap, 0);
                    break;
                case Direction.UP:
                case Direction.DOWN:
                case Direction.VERTICAL:
                    bitmap = ImageAction.Rotate(bitmap, 90);
                    break;
                case Direction.RIGHTUP:
                    bitmap = ImageAction.Rotate(bitmap, 90);
                    break;
                case Direction.LEFTUP:
                    bitmap = ImageAction.Rotate(bitmap, 0);
                    break;
                case Direction.RIGHTDOWN:
                    bitmap = ImageAction.Rotate(bitmap, 180);
                    break;
                case Direction.LEFTDOWN:
                    bitmap = ImageAction.Rotate(bitmap, 270);
                    break;
            }
            graphics.DrawImage(bitmap, new Rectangle(this.X - Radius, this.Y - Radius, this.Radius * 2, this.Radius * 2));

        }
    }
}
