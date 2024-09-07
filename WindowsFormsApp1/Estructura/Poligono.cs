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
        public Matrix4 TransformMatrix { get; set; }
        [JsonIgnore]
        int VertexBufferObject;
        [JsonIgnore]
        int ElementBufferObject;
        [JsonIgnore]
        int VertexArrayObject;



        public Poligono(float[] vertices)
        {
            Vertices = vertices;
            TransformMatrix = Matrix4.Identity;
        }

        public void Dibujar(Shader shader, Vector3 parteCentro)
        {

            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

            float[] vertices2 = new float[Vertices.Length];

            for (int i = 0; i < Vertices.Length; i += 6)
            {
                vertices2[i] = Vertices[i] + parteCentro.X;
                vertices2[i + 1] = Vertices[i + 1] + parteCentro.Y;
                vertices2[i + 2] = Vertices[i + 2] + parteCentro.Z;
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

                // Configurar los atributos de los vértices
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(1);
            }

            // Aplicar la transformación del modelo
            Matrix4 model = Matrix4.CreateTranslation(parteCentro) * TransformMatrix;
            shader.SetMatrix4("model", model);

            // Dibujar el polígono
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.Polygon, indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }

}

