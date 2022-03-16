using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Data
{
    public interface ITablero
    {
        Celdas[] Tablero { get; set; }
        void AgregarEscaleras(int numeroCelda, int AvanceCelda);
        void AgregarEscaleras(CeldasEscaleras celdasEscaleras);
        void AgregarSerpiente(int numeroCelda, int bajada);
        void AgregarSerpiente(CeldasSerpientes celdasSerpientes);
        void CrearTablero(int tableroSize);
    }
}
