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
        public Vector3 Centro { get; private set; }


        public Objeto(Vector3 centro)
        {
            partes = new Dictionary<string, Parte>();
            this.Centro = centro;
        }

        public void AgregarParte(string nombre, Parte parte)
        {
            partes.Add(nombre, parte);
        }

        public void Dibujar(Shader shader, Vector3 escenarioCentro)
        {
            foreach (Parte parte in partes.Values)
            {
                parte.Dibujar(shader, this.Centro);
            }

        }
        
    }
}
