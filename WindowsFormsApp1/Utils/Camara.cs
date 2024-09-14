using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Utils
{
    public class Camara
    {
        public Vector3 Posicion { get; private set; }
        public Vector3 Objetivo { get; private set; }
        public Vector3 Arriba { get; private set; }
        private float speed = 1.5f;

        public Camara(Vector3 posicionInicial, Vector3 objetivoInicial, Vector3 arribaInicial)
        {
            Posicion = posicionInicial;
            Objetivo = objetivoInicial;
            Arriba = arribaInicial;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Posicion, Posicion + Objetivo, Arriba);
        }

        public void ProcessKeyboard(Keys key)
        {
            switch (key)
            {
                case Keys.W:
                    Posicion += Objetivo * speed;
                    break;
                case Keys.S:
                    Posicion -= Objetivo * speed;
                    break;
                case Keys.A:
                    Posicion -= Vector3.Cross(Objetivo, Arriba).Normalized() * speed;
                    break;
                case Keys.D:
                    Posicion += Vector3.Cross(Objetivo, Arriba).Normalized() * speed;
                    break;
                case Keys.Q:
                    Posicion += Arriba * speed;
                    break;
                case Keys.E:
                    Posicion -= Arriba * speed;
                    break;
            }
        }

        public void ProcessMouseMovement(float deltaX, float deltaY, float sensitivity = 0.002f)
        {
            // Calcular la nueva dirección del objetivo
            Vector3 right = Vector3.Normalize(Vector3.Cross(Objetivo, Arriba));
            Objetivo = Vector3.Transform(Objetivo, Matrix3.CreateFromAxisAngle(Arriba, -deltaX * sensitivity));
            Objetivo = Vector3.Transform(Objetivo, Matrix3.CreateFromAxisAngle(right, deltaY * sensitivity));
        }
    }
}
