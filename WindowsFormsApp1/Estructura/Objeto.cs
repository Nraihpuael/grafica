using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Estructura
{
    public class Objeto
    {
        public Dictionary<string, Parte> partes { get; set; }
        public Punto3D Centro { get; private set; }
        public Escenario Escenario { get; set; }

        public Objeto(Punto3D centro)
        {
            partes = new Dictionary<string, Parte>();
            this.Centro = centro;
        }

        public void AgregarParte(string nombre, Parte parte)
        {
            parte.ObjetoPadre = this;
            partes.Add(nombre, parte);
        }

        public void Dibujar(Shader shader, Punto3D escenarioCentro)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Dibujar(shader, this.Centro);
            }

        }

        public void Rotate(Punto3D escenarioCentro, float x, float y, float z)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Rotate(escenarioCentro + Centro, x, y, z);
            }
        }

        public void Trasladar(Punto3D escenarioCentro, float x, float y, float z)
        {   
            foreach (Parte parte in partes.Values)
            {
                parte.Trasladar(escenarioCentro + Centro,x,y,z);
            }
        }


        public void Escalar(float x, float y, float z)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Escalar(x, y, z);
            }
        }

        public void ReiniciarTransformaciones()
        {
            foreach (Parte parte in partes.Values)
            {
                parte.ReiniciarTransformaciones();
            }
        }
    }
}
