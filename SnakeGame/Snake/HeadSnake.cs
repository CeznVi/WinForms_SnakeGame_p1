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
        private Direction _direction;

        public Direction CurrentDirection
        {
            get { return _direction; }

            private set 
            { 
                ///Validation!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                _direction = value; 
            }
        }

        public HeadSnake(int x, int y, int radius, Direction direction) : base(x, y, radius)
        {
            CurrentDirection = direction;
        }

        public void Draw(Graphics graphics)
        {

            Bitmap bitmap = new Bitmap(GameResource.snake_head);

            bitmap.MakeTransparent();

            switch(CurrentDirection)
            {
                case Direction.UP:
                    bitmap = RotateImage(bitmap, 180);
                    break;
                case Direction.DOWN:
                    bitmap = RotateImage(bitmap, 0);
                    break;
                case Direction.LEFT:
                    bitmap = RotateImage(bitmap, 90);
                    break;
                case Direction.RIGHT:
                    bitmap = RotateImage(bitmap, 270);
                    break;
            }


            graphics.DrawImage(bitmap,new Rectangle(this.X - Radius, this.Y - Radius, this.Radius *2, this.Radius*2));
        
        }

        private Bitmap RotateImage(Bitmap bitmap, int angle)
        {
            Bitmap rotatedImage = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics gdi = Graphics.FromImage(rotatedImage);
            gdi.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
            gdi.RotateTransform(angle);

            gdi.TranslateTransform(-bitmap.Width / 2, -bitmap.Height / 2);
            gdi.DrawImage(bitmap, new Point(0,0));
            
            gdi.Dispose();

            return rotatedImage;
            
        }
    }
}
