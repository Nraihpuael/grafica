using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Estructura
{
    public class Escenario
    {
        public Dictionary<string, Objeto> objetos { get; set; }
        public Vector3 Centro { get; private set; }

        public Escenario()
        {
            objetos = new Dictionary<string, Objeto>();
            Centro = Vector3.Zero;
        }

        public void AgregarObjeto(string nombre, Objeto objeto)
        {
            objetos[nombre] = objeto;
        }

        public void Dibujar(Shader shader)
        {

            foreach (Objeto obj in objetos.Values)
            {
                obj.Dibujar(shader, Centro);
            }
        }

        

        public Objeto Get(string key)
        {
            return this.objetos[key];
        }
    }
}
