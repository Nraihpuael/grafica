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
            TiempoTotal = accion.Tiempo + accion.TiempoInicio; 
        }

        public void Ejecutar(Escenario escenario, ref double time)
        {
            var accionesActivas = Acciones.Where(a => a.Estado != EstadoAccion.Completada).ToList();
            foreach (var accion in accionesActivas)
            {
                accion.Ejecutar(escenario, ref time);
            }
        }

        public void Reiniciar()
        {
            foreach (var accion in Acciones)
            {
                accion.Reiniciar(); 
            }
        }

    }
}
