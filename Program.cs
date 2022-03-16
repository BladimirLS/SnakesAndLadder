using Microsoft.Extensions.DependencyInjection;
using SnakesAndLadder.Data;
using SnakesAndLadder.Servicio;
using SnakesAndLadders.Modelo;
using System;

namespace SnakesAndLadder
{
    class Program
    {
        static ITablero _tablero;
        static IDado _dado;
        static IJuegoServicio _juego;
        static ILogging _logging;
        static IJugador _jugador;
        static int _tableroSize = 100;
        static int _njugador = 2;
        static void Main(string[] args)
        {
            

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ITablero, TableroServicio>()
                .AddSingleton<IDado, DadoServicio>()
                .AddSingleton<IJuegoServicio, JuegoServicio>()
                .AddSingleton<ILogging, Logging>()
                .AddSingleton<IJugador, JugadorServicio>()
                .BuildServiceProvider();

            _logging = new Logging();
            _dado = serviceProvider.GetService<IDado>();

            _tablero = serviceProvider.GetService<ITablero>();
            _tablero.CrearTablero(_tableroSize);
            _tablero.AgregarEscaleras(2, 38);
            _tablero.AgregarEscaleras(7, 14);
            _tablero.AgregarEscaleras(8, 31);
            _tablero.AgregarEscaleras(15, 26);
            _tablero.AgregarEscaleras(28, 84);
            _tablero.AgregarEscaleras(21, 42);
            _tablero.AgregarEscaleras(36, 44);
            _tablero.AgregarEscaleras(51, 67);
            _tablero.AgregarEscaleras(71, 91);
            _tablero.AgregarEscaleras(78, 98);
            _tablero.AgregarEscaleras(87, 94);

            _tablero.AgregarSerpiente(16, 6);
            _tablero.AgregarSerpiente(46, 25);
            _tablero.AgregarSerpiente(49, 11);
            _tablero.AgregarSerpiente(64, 60);
            _tablero.AgregarSerpiente(62, 19);
            _tablero.AgregarSerpiente(74, 53);
            _tablero.AgregarSerpiente(89, 68);
            _tablero.AgregarSerpiente(92, 88);
            _tablero.AgregarSerpiente(95, 75);
            _tablero.AgregarSerpiente(99, 80);

            _jugador = serviceProvider.GetService<IJugador>();
            _jugador.AsignarJugadores(new Jugador() { NombreJugador = "One" });
            _jugador.AsignarJugadores(new Jugador() { NombreJugador = "Two" });

            if (_jugador.TotalJugadores > 0)
            {
                _juego = serviceProvider.GetService<IJuegoServicio>();
                _juego.Play();
            }

            Console.ReadKey();
        }
    }
}
