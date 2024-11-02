using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Animacion
{
    public class Transformacion
    {
        public string TipoTransformacion { get; set; }
        public Punto3D Valor { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public int Duracion { get; set; } // Duración en milisegundos

        public Transformacion(string tipo, Punto3D valor, int duracion)
        {
            TipoTransformacion = tipo;
            Valor = valor;
            Duracion = duracion;
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;

        }



        public void Ejecutar(Parte parte, float incrementoX, float incrementoY, float incrementoZ)
        {

            switch (TipoTransformacion)
            {
                case "Rotacion":
                    parte.Rotate(parte.Centro + parte.ObjetoPadre.Centro, incrementoX, incrementoY, incrementoZ);
                    break;
                case "Traslacion":
                    parte.Trasladar(incrementoX, incrementoY, incrementoZ);
                    break;
                case "Escala":
                    parte.Escalar(incrementoX, incrementoY, incrementoZ);
                    break;
                default:
                    Console.WriteLine($"Tipo de transformación '{TipoTransformacion}' no reconocido.");
                    break;
            }
        }

        public void Ejecutar(Objeto objeto, float incrementoX, float incrementoY, float incrementoZ)
        {

            switch (TipoTransformacion)
            {
                case "Rotacion":
                    objeto.Rotate(objeto.Escenario.Centro, incrementoX, incrementoY, incrementoZ);
                    break;
                case "Traslacion":
                    objeto.Trasladar(incrementoX, incrementoY, incrementoZ);
                    break;
                case "Escala":
                    objeto.Escalar(incrementoX, incrementoY, incrementoZ);
                    break;
                default:
                    Console.WriteLine($"Tipo de transformación '{TipoTransformacion}' no reconocido.");
                    break;
            }
        }
    }

}
