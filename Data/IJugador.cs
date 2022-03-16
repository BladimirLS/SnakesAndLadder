using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Data
{
    public interface IJugador
    {
        List<Jugador> Jugadores { get; set; }
        int TotalJugadores { get; }
        void AsignarDadoJugador(int numeroJugador, int dado);
        bool DadoValor();
        bool OrdenJugador();
        void AsignarJugadores(Jugador jugador);
    }
}
