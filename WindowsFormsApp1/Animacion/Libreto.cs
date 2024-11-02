using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1.Animacion
{
    public class Libreto
    {
        public List<Escena> Escenas { get; private set; }
        public int escenaActual;
        public double tiempoAcumulado;
        public double tiempoTotal;

        public Libreto()
        {
            Escenas = new List<Escena>();
            escenaActual = 0;
            tiempoAcumulado = 0;
            tiempoTotal = 0;
        }

        public void AgregarEscena(Escena escena)
        {
            Escenas.Add(escena);
            tiempoTotal += escena.TiempoTotal; // Sumar el tiempo total de cada escena
        }

        public void EjecutarEscena(Escenario escenario, ref double time)
        {
            if (escenaActual < Escenas.Count)
            {
                Escena escena = Escenas[escenaActual];
                escena.Ejecutar(escenario, ref time);

                if (escena.TiempoTotal <= tiempoAcumulado)
                {
                    escenaActual++;
                    tiempoAcumulado = 0;
                }
                else
                {
                   
                    tiempoAcumulado += time;
                }
            }
            else
            {
                escenaActual = 0;
                tiempoAcumulado = 0;
            }
        }

        public bool IsCompleto() => tiempoAcumulado >= tiempoTotal;
        public void Reiniciar()
        {
            escenaActual = 0;
            tiempoAcumulado = 0;
            foreach (var escena in Escenas)
            {
                escena.Reiniciar(); // Ejecutar la acción
            }
        }
    }
}
