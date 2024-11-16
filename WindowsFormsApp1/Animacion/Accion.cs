using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Animacion
{
    using System.Threading;
    using System.Threading.Tasks;

    public enum EstadoAccion
    {
        Pendiente,
        EnEjecucion,
        Completada
    }

    public class Accion
    {
        public string Nombre { get; set; }
        public List<Transformacion> Transformaciones { get; set; }
        public int Tiempo { get; set; }
        public int TiempoInicio { get; set; } 

        private double tiempoAcumulado;
        public EstadoAccion Estado { get; private set; }


        public Accion(string nombre, int tiempo, int tiempoInicio)
        {
            Nombre = nombre;
            Transformaciones = new List<Transformacion>();
            Tiempo = tiempo;
            TiempoInicio = tiempoInicio;
            tiempoAcumulado = 0;
            Estado = EstadoAccion.Pendiente;
        }

        public void AgregarTransformacion(Transformacion transformacion)
        {
            Transformaciones.Add(transformacion);
        }

        public void Ejecutar(Escenario escenario, ref double time)
        {
            if (tiempoAcumulado >= TiempoInicio && tiempoAcumulado <= TiempoInicio + Tiempo)
            {

                if (Estado == EstadoAccion.Pendiente) { 
                    Estado = EstadoAccion.EnEjecucion;
                }
                
                if (escenario.objetos.TryGetValue(Nombre, out Objeto objeto))
                {
                    EjecutarTransformaciones(objeto, ref time);
                   
                }
                else
                {
                    foreach (var kvp in escenario.objetos)
                    {
                        if (kvp.Value.partes.TryGetValue(Nombre, out Parte parte))
                        {
                            EjecutarTransformaciones(parte, ref time);
                        }
                    }
                }
            }else if (tiempoAcumulado > TiempoInicio + Tiempo && Estado == EstadoAccion.EnEjecucion)
            {
                Estado = EstadoAccion.Completada; 
            }

            tiempoAcumulado += time;
        }

        private void EjecutarTransformaciones(dynamic objeto, ref double time)
        {
            double tiempoRestante = Tiempo - tiempoAcumulado + TiempoInicio; 


            foreach (var transformacion in Transformaciones)
            {
                if (tiempoRestante > 0)
                {
                    // Calcula el incremento para cada eje, considerando la duración de la transformación
                    float incrementoX = (float)(transformacion.Valor.X * (time / transformacion.Duracion));
                    float incrementoY = (float)(transformacion.Valor.Y * (time / transformacion.Duracion));
                    float incrementoZ = (float)(transformacion.Valor.Z * (time / transformacion.Duracion));

                    if (Math.Abs(transformacion.x + incrementoX) > Math.Abs(transformacion.Valor.X) ||
                        Math.Abs(transformacion.y + incrementoY) > Math.Abs(transformacion.Valor.Y) ||
                        Math.Abs(transformacion.z + incrementoZ) > Math.Abs(transformacion.Valor.Z))
                    {
                        incrementoX = (float)(transformacion.Valor.X - transformacion.x);
                        incrementoY = (float)(transformacion.Valor.Y - transformacion.y);
                        incrementoZ = (float)(transformacion.Valor.Z - transformacion.z);
                    }

                    // Ejecuta la transformación en el objeto
                    transformacion.Ejecutar(objeto, incrementoX, incrementoY, incrementoZ);
                    transformacion.x += incrementoX;
                    transformacion.y += incrementoY;
                    transformacion.z += incrementoZ;

                   // Console.WriteLine(transformacion.z);
                }


            }
        }

        public void Reiniciar()
        {
            Estado = EstadoAccion.Pendiente;
            tiempoAcumulado = 0;
            foreach (var transformacion in Transformaciones)
            {
                transformacion.x = 0;
                transformacion.y = 0;
                transformacion.z = 0;
            }
        }


    }

}
