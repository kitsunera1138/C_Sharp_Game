using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    public enum COLORS
    {
        Red,
        Yellow,
        Blue,
        Green,
        Cyan,
        Magenta,
        White,
        Gray,
        DarkGray,
        DarkRed,
        DarkYellow,
        DarkBlue,
        DarkGreen,
        DarkCyan,
        DarkMagenta,
        Black
    }

    public static class ConsoleColors
    {
        private static readonly ConsoleColor OriginColor = Console.ForegroundColor;

        public static void ChangeColor(COLORS color)
        {
            if (Enum.IsDefined(typeof(COLORS), color))
            {
                //COLORS enum형을 변형
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString(), true);
            }
        }

        public static void ResetColor()
        {
            Console.ForegroundColor = OriginColor;
        }
    }
}
