using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Estructura
{
    public class Parte
    {
        public Dictionary<string, Poligono> poligonos { get; set; }
        public Vector3 Centro { get; private set; }

        public Parte(Vector3 centro)
        {
            poligonos = new Dictionary<string, Poligono>();
            this.Centro = centro;
        }

        public void AgregarPoligono(string nombre, Poligono poligono)
        {
            poligonos.Add(nombre, poligono);
        }

        public void Dibujar(Shader shader, Vector3 objetoCentro)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Dibujar(shader, objetoCentro + Centro); 
            }
        }
       
    }
}
