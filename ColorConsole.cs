using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_HotelCalculations
{
    internal static class ColorConsole
    {
        #region Methods
        /// <summary>
        /// Console.Write renkli versiyon.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Console.WriteLine renkli versiyon.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}
