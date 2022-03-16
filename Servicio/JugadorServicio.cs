using SnakesAndLadder.Data;
using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakesAndLadder.Servicio
{
    public class JugadorServicio : IJugador
    {
        ILogging _logging;

        public JugadorServicio(ILogging logging)
        {
            _logging = logging;
        }

        public List<Jugador> Jugadores { get; set; } = new List<Jugador>();
        public int TotalJugadores => Jugadores != null ? Jugadores.Count : 0;
        public void AsignarJugadores(Jugador jugador)
        {
            _logging.ImprimirLog("Adding a new player");
            if (jugador != null)
            {
                jugador.IdJugador = TotalJugadores + 1;
                Jugadores.Add(jugador);

                _logging.ImprimirLog("New Player is Added");
            }


        }

        public void AsignarDadoJugador(int numeroJugador, int dado)
        {
            Jugador jugador = Jugadores.Where(p => p.IdJugador == numeroJugador).FirstOrDefault();
            if (jugador != null)
            {
                jugador.Dado = dado;
            }
        }

        public bool DadoValor()
        {
            int valor = Jugadores.GroupBy(p => p.Dado).Select(l => new { l.Key, Num = l.Count() }).Where(a => a.Num > 1).Count();
            return valor > 1;
        }

        public bool OrdenJugador()
        {
            bool vct = false;

            if (!DadoValor() && Jugadores.Count < 4)
            {
                Jugadores = Jugadores.OrderByDescending(p => p.Dado).ToList();

                int indice = 0;
                foreach (Jugador j in Jugadores)
                {
                    j.IdJugador = indice + 1;
                    indice++;
                }

                vct = true;
            }

            return vct;
        }
    }
}
