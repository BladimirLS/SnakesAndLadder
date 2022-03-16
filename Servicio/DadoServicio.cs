using SnakesAndLadder.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Servicio
{
    public class DadoServicio : IDado
    {
        ILogging _logging;

        public DadoServicio(ILogging logging)
        {
            _logging = logging;
        }

        public int ArrojarDado()
        {
            _logging.ImprimirLog("Roll Dice");

            Random rnd = new Random();
            return rnd.Next(1, 6);
        }
    }
}
