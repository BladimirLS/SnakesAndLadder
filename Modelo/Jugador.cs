using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadders.Modelo
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string NombreJugador { get; set; }
        public int PosicionJugador { get; set; } = 1;
        public bool Ganador { get; set; } = false;
        public int Dado { get; set; } = 0;
    }
}
