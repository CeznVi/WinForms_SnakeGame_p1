using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    /// <summary>
    /// Статический клас для работы с картинками
    /// </summary>
    static class ImageAction
    {
        public static Bitmap Rotate(Bitmap bitmap, int angle)
        {
            Bitmap rotatedImage = new Bitmap(bitmap.Width, bitmap.Height);

            Graphics gdi = Graphics.FromImage(rotatedImage);

            gdi.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
            gdi.RotateTransform(angle);

            gdi.TranslateTransform(-bitmap.Width / 2, -bitmap.Height / 2);
            gdi.DrawImage(bitmap, new Point(0, 0));

            gdi.Dispose();

            return rotatedImage;
        }

    }
}
