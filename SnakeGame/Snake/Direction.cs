using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    enum Direction
    {
        UP, 
        DOWN, 
        LEFT, 
        RIGHT,
        VERTICAL,
        HORIZONTAL,
        RD,
        UL,
        RU,
        DL,
        UR,
        LD,
        LU,
        DR,
        NULL
    }

    enum ControlDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    /// <summary>
    /// Статический клас для выполнения операций над Дирекшенами
    /// </summary>
    static class DirectionOperation
    {
        public static bool Check(Direction dir)
        {
            if(dir.GetType() == typeof(Direction))
                return true;
            else
                return false;
        }
    }
}
