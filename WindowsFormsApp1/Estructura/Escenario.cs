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
        public Punto3D Centro { get; private set; }

        public Escenario()
        {
            objetos = new Dictionary<string, Objeto>();
            Centro = new Punto3D(0.0f, 0.0f, 0.0f);
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

        public void Rotate(float x, float y, float z)
        {
            foreach (Objeto obj in objetos.Values)
            {
                obj.Rotate(Centro, x, y, z);
            }
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (Objeto obj in objetos.Values)
            {
                obj.Trasladar(Centro,x, y, z);
            }
        }

        public void Escalar(float x, float y, float z)
        {
            foreach (Objeto obj in objetos.Values)
            {
                obj.Escalar(x, y, z);
            }
        }

        public void ReiniciarTransformaciones()
        {
            foreach (Objeto obj in objetos.Values)
            {
                obj.ReiniciarTransformaciones();
            }
        }
    }
}
