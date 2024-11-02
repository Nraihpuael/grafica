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

    public class Accion
    {
        public string Nombre { get; set; }
        public List<Transformacion> Transformaciones { get; set; }
        public int Tiempo { get; set; } // Duración de la acción en milisegundos
        public int TiempoInicio { get; set; } // Tiempo en que debe iniciar la acción

        private double tiempoAcumulado; // Lleva el tiempo acumulado para controlar cuándo iniciar

        public Accion(string nombre, int tiempo, int tiempoInicio)
        {
            Nombre = nombre;
            Transformaciones = new List<Transformacion>();
            Tiempo = tiempo;
            TiempoInicio = tiempoInicio;
            tiempoAcumulado = 0; // Inicia el tiempo acumulado en cero
        }

        public void AgregarTransformacion(Transformacion transformacion)
        {
            Transformaciones.Add(transformacion);
        }

        public void Ejecutar(Escenario escenario, ref double time)
        {
            // Verificar si el tiempo acumulado ha alcanzado el tiempo de inicio de esta acción
            if (tiempoAcumulado >= TiempoInicio && tiempoAcumulado <= TiempoInicio + Tiempo)
            {
               
                // Ejecutar las transformaciones en el objeto correspondiente si el tiempo es adecuado
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
            }

            tiempoAcumulado += time;
        }

        private void EjecutarTransformaciones(dynamic objeto, ref double time)
        {
            double tiempoRestante = Tiempo - tiempoAcumulado + TiempoInicio; // Tiempo restante para la transformación actual


            foreach (var transformacion in Transformaciones)
            {
                if (tiempoRestante > 0)
                {
                    // Calcula el incremento para cada eje, considerando la duración de la transformación
                    float incrementoX = (float)(transformacion.Valor.X * (time / transformacion.Duracion));
                    float incrementoY = (float)(transformacion.Valor.Y * (time / transformacion.Duracion));
                    float incrementoZ = (float)(transformacion.Valor.Z * (time / transformacion.Duracion));

                    // Ajusta la transformación si supera el valor final, teniendo en cuenta el signo
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

                    Console.WriteLine(transformacion.z);
                }


            }
        }

        public void Reiniciar()
        {
            // Reiniciar el tiempo acumulado y las transformaciones
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
