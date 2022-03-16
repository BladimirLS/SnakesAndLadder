using SnakesAndLadder.Data;
using SnakesAndLadders.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesAndLadder.Servicio
{
    public class TableroServicio : ITablero
    {
        ILogging _logging;

        public TableroServicio(ILogging logging)
        {
            _logging = logging;
        }

        public Celdas[] Tablero { get; set; }

        public void CrearTablero(int tableroSize)
        {
            _logging.ImprimirLog("Create a new board");

            Tablero = new Celdas[tableroSize];
            for (int i = 0; i < tableroSize; i++)
            {
                Celdas c = new Celdas();
                c.NumeroCeldas = i + 1;
                Tablero[i] = c;
            }
        }

        public void AgregarEscaleras(int numeroCelda, int avanceCelda)
        {
            AgregarEscaleras(new CeldasEscaleras() { CeldaAvance = avanceCelda, NumeroCeldas = numeroCelda });
        }

        public void AgregarEscaleras(CeldasEscaleras celdasEscaleras)
        {
            if (celdasEscaleras != null)
                if (celdasEscaleras.NumeroCeldas < celdasEscaleras.CeldaAvance)
                    Tablero[celdasEscaleras.NumeroCeldas - 1] = celdasEscaleras;
                else
                    throw new Exception("The ladder must start in a cell in a lower position of the advantage cell");

            _logging.ImprimirLog("Added a new ladder");
        }

        public void AgregarSerpiente(int numeroCelda, int bajada)
        {
            AgregarSerpiente(new CeldasSerpientes() { NumeroCeldas = numeroCelda, Bajadas = bajada });
        }

        public void AgregarSerpiente(CeldasSerpientes celdaSerpiente)
        {
            if (celdaSerpiente != null)
                if (celdaSerpiente.NumeroCeldas > celdaSerpiente.Bajadas)
                    Tablero[celdaSerpiente.NumeroCeldas - 1] = celdaSerpiente;
                else
                    throw new Exception("The snake must start in a cell in a higer position of the penality cell");

            _logging.ImprimirLog("Added a new snake");
        }
    }
}
