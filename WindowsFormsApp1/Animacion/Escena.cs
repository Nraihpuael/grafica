using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Animacion
{
    public class Escena
    {
        public List<Accion> Acciones { get;  set; }
        public double TiempoTotal { get;  set; }

        public Escena()
        {
            Acciones = new List<Accion>();
            TiempoTotal = 0;
        }

        public void AgregarAccion(Accion accion)
        {
            Acciones.Add(accion);
            TiempoTotal += accion.Tiempo; // Sumar tiempo de cada acción
        }

        public void Ejecutar(Escenario escenario, ref double time)
        {
            foreach (var accion in Acciones)
            {
                accion.Ejecutar(escenario, ref time); // Ejecutar la acción
            }
        }

        public void Reiniciar()
        {
            foreach (var accion in Acciones)
            {
                accion.Reiniciar(); // Ejecutar la acción
            }
        }

    }
}
