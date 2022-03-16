using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Data
{
    public interface ILogging
    {
        void ImprimirLog(string mensaje);
        void ImprimirError(string mensaje);
    }
}
