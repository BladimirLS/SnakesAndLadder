using SnakesAndLadder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadder
{
    public class Logging : ILogging
    {
        public void ImprimirError(string mensaje)
        {
            ConsoleColor ccForeground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ForegroundColor = ccForeground;

        }
        public void ImprimirLog(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        
    }
}
