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
            Centro = centro;
        }

        public void AgregarPoligono(string nombre, Poligono poligono)
        {
            poligonos[nombre] = poligono;
        }

        public void Dibujar(Shader shader, Vector3 objetoCentro)
        {
            foreach (var kvp in poligonos)
            {
                string nombreCara = kvp.Key;
                Poligono poligono = kvp.Value;
                poligono.Dibujar(shader, objetoCentro + Centro, nombreCara);  // Pasar el nombre al método Dibujar
            }
        }
       
    }
}
