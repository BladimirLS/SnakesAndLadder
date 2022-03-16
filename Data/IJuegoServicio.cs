using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Data
{
    public interface IJuegoServicio
    {
        void CalcularPosicionJugador(Jugador jugador, int numeroDado);
        Jugador ProximaJugada(Jugador jugador);
        void Play();
    }
}
