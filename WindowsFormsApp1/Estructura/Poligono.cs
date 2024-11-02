using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using Newtonsoft.Json;

namespace WindowsFormsApp1.Estructura
{
    public class Poligono
    {
        public float[] Vertices { get; private set; }
        [JsonIgnore]
        private Matrix4 transformacionMX = Matrix4.Identity;
        private Matrix4 rotacionMX = Matrix4.Identity;
        private Matrix4 traslacionMX = Matrix4.Identity;
        private Matrix4 escalaionMX = Matrix4.Identity;
        [JsonIgnore]
        int VertexBufferObject;
        [JsonIgnore]
        int ElementBufferObject;
        [JsonIgnore]
        int VertexArrayObject;



        public Poligono(float[] vertices)
        {
            Vertices = vertices;
        }

        public void Dibujar(Shader shader, Punto3D center, string nombre)
        {


            int[] indices;

            if (nombre == "Pelota")
            {
                int numSegmentos = 7;
                int numAnillos = 7;
                indices = new int[numAnillos * numSegmentos * 6];
                int indexIndex = 0;

                for (int i = 0; i < numAnillos; i++)
                {
                    for (int j = 0; j < numSegmentos; j++)
                    {
                        int primero = i * (numSegmentos + 1) + j;
                        int segundo = primero + numSegmentos + 1;
                        indices[indexIndex++] = primero;
                        indices[indexIndex++] = segundo;
                        indices[indexIndex++] = primero + 1;
                        indices[indexIndex++] = segundo;
                        indices[indexIndex++] = segundo + 1;
                        indices[indexIndex++] = primero + 1;
                    }
                }
            }
            else
            {
                indices = new int[] { 0, 1, 2, 2, 3, 0 };

                
            }

            float[] vertices2 = new float[Vertices.Length];

            for (int i = 0; i < Vertices.Length; i += 6)
            {
                vertices2[i] = Vertices[i] + center.X;
                vertices2[i + 1] = Vertices[i + 1] + center.Y;
                vertices2[i + 2] = Vertices[i + 2] + center.Z;
                vertices2[i + 3] = Vertices[i + 3];
                vertices2[i + 4] = Vertices[i + 4];
                vertices2[i + 5] = Vertices[i + 5];
            }

            if (VertexArrayObject == 0)
            {
                VertexArrayObject = GL.GenVertexArray();
                GL.BindVertexArray(VertexArrayObject);

                VertexBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
                GL.BufferData(BufferTarget.ArrayBuffer, vertices2.Length * sizeof(float), vertices2, BufferUsageHint.StaticDraw);

                ElementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(1);
            }
            Matrix4 trans1 = Matrix4.CreateTranslation(-center.X, -center.Y, -center.Z);
            Matrix4 trans2 = Matrix4.CreateTranslation(center.X, center.Y, center.Z);
            transformacionMX = trans1 *  trans2 * transformacionMX; 
            shader.SetMatrix4("model", transformacionMX);

            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.TriangleFan, indices.Length, DrawElementsType.UnsignedInt, 0);
        }       


        public void Rotate(Punto3D center, float x, float y, float z)
        {

            float radiansX = MathHelper.DegreesToRadians(x);
            float radiansY = MathHelper.DegreesToRadians(y);
            float radiansZ = MathHelper.DegreesToRadians(z);

            Matrix4 trans1 = Matrix4.CreateTranslation(-center.X, -center.Y, -center.Z);
            Matrix4 rot = Matrix4.CreateRotationZ(radiansZ) * Matrix4.CreateRotationY(radiansY) * Matrix4.CreateRotationX(radiansX);
            Matrix4 trans2 = Matrix4.CreateTranslation(center.X, center.Y, center.Z);

            transformacionMX = trans1 * rot * trans2* transformacionMX;
        }

        public void Trasladar(float x = 0, float y = 0, float z = 0)
        {
            traslacionMX = Matrix4.CreateTranslation(x, y, z);
            transformacionMX = traslacionMX * transformacionMX;

        }

        public void Escalar(float x, float y, float z)
        {
            escalaionMX = Matrix4.CreateScale(x, y, z);
            transformacionMX = escalaionMX * transformacionMX;
        }

        public void ReiniciarTransformaciones()
        {
            transformacionMX = Matrix4.Identity;
            rotacionMX = Matrix4.Identity;
            traslacionMX = Matrix4.Identity;
            escalaionMX = Matrix4.Identity;
        }
    }

}

