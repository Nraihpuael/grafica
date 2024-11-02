using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp1.Estructura
{
    public class Parte
    {
        public Dictionary<string, Poligono> poligonos { get; set; }
        public Punto3D Centro { get; private set; }
        public Objeto ObjetoPadre { get; set; }

        public Parte(Punto3D centro)
        {
            poligonos = new Dictionary<string, Poligono>();
            this.Centro = centro;
        }

        public void AgregarPoligono(string nombre, Poligono poligono)
        {
            poligonos.Add(nombre, poligono);
        }

        public void Dibujar(Shader shader, Punto3D objetoCentro)
        {

            foreach (Poligono poligono in poligonos.Values)
            {
                // Busca la clave (nombre) correspondiente al polígono actual
                string nombrePoligono = poligonos.FirstOrDefault(entry => entry.Value == poligono).Key;
                poligono.Dibujar(shader, objetoCentro + Centro, nombrePoligono);
            }
        }

        public void Rotate(Punto3D objetoCentro, float x, float y, float z)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Rotate(objetoCentro, x, y, z);
            }
        }

        public void Trasladar(float x, float y, float z)
        {

            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Trasladar(x,y,z);
            }
        }

        public void Escalar(float x, float y, float z)
        {

            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.Escalar(x, y, z);
            }
        }

        public void ReiniciarTransformaciones()
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.ReiniciarTransformaciones();
            }
        }

    }
}
