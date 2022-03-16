using SnakesAndLadder.Data;
using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakesAndLadder.Servicio
{
    public class JuegoServicio : IJuegoServicio
    {

        ITablero _tablero;
        IDado _dado;
        ILogging _logging;
        IJugador _jugador;

        Jugador cJugador;

        public JuegoServicio(ITablero tablero, IDado dado, ILogging logging, IJugador jugador)
        {
            _tablero = tablero;
            _dado = dado;
            _logging = logging;
            _jugador = jugador;

            _logging.ImprimirLog("Set bew game");
        }

        public void CalcularPosicionJugador(Jugador cJugador, int dadoNumro)
        {
            _logging.ImprimirLog($"{cJugador.NombreJugador}: your dice shows {dadoNumro}");

            int moverUbicacion = cJugador.PosicionJugador;
            if ((moverUbicacion + dadoNumro) <= _tablero.Tablero.Length)
            {
                moverUbicacion = moverUbicacion + dadoNumro;
                _logging.ImprimirLog($"{cJugador.NombreJugador}: moved to {moverUbicacion}");
            }
            else
            {
                _logging.ImprimirLog($"{cJugador.NombreJugador}: stays at {moverUbicacion}");
            }

            while (_tablero.Tablero[moverUbicacion - 1].GetType() == typeof(CeldasSerpientes) || _tablero.Tablero[moverUbicacion - 1].GetType() == typeof(CeldasEscaleras))
            {
                if (_tablero.Tablero[moverUbicacion - 1].GetType() == typeof(CeldasSerpientes))
                {
                    moverUbicacion = (_tablero.Tablero[moverUbicacion - 1] as CeldasSerpientes).Bajadas;
                    _logging.ImprimirLog($"{cJugador.NombreJugador}: snake bite moving to {moverUbicacion}");
                }
                if (_tablero.Tablero[moverUbicacion - 1].GetType() == typeof(CeldasEscaleras))
                {
                    moverUbicacion = (_tablero.Tablero[moverUbicacion - 1] as CeldasEscaleras).CeldaAvance;
                    _logging.ImprimirLog($"{cJugador.NombreJugador}: found ladder moving to {moverUbicacion}");
                }
            }

            cJugador.PosicionJugador = moverUbicacion;

            if (cJugador.PosicionJugador == _tablero.Tablero.Length)
                cJugador.Ganador = true;
        }

        public Jugador ProximaJugada(Jugador jugador)
        {
            Jugador rvc;
            _logging.ImprimirLog("NextChange");

            if (jugador.IdJugador < _jugador.TotalJugadores)
                rvc = _jugador.Jugadores.Skip(jugador.IdJugador).First();
            else
                rvc = _jugador.Jugadores.First();

            return rvc;
        }

        public void Play()
        {
            _logging.ImprimirLog("Start the Game");

            bool primerMovimiento = true;
            cJugador = _jugador.Jugadores.First();

            while (cJugador.PosicionJugador != _tablero.Tablero.Length)
            {
                if (!primerMovimiento)
                    cJugador = ProximaJugada(cJugador);
                primerMovimiento = false;
                CalcularPosicionJugador(cJugador, _dado.ArrojarDado());
            }

            _logging.ImprimirLog($"{cJugador.NombreJugador} Wins!");

            foreach (Jugador p in _jugador.Jugadores)
                _logging.ImprimirLog($"{p.NombreJugador} is at {p.PosicionJugador}");
            _logging.ImprimirLog("Game Over!");
        }
    }
}
