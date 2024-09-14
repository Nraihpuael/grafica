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
        private Matrix4 _trans = Matrix4.Identity;
        private Matrix4 _rotationMatrix = Matrix4.Identity;
        private Matrix4 _translationMatrix = Matrix4.Identity;
        private Matrix4 _scaleMatrix = Matrix4.Identity;
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

        public void Dibujar(Shader shader, Punto3D center)
        {

            int[] indices = new int[] { 0, 1, 2, 2, 3, 0 };

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

                // Configurar los atributos de los vértices
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
                GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(1);
            }

            shader.SetMatrix4("model", _trans);

            // Dibujar el polígono
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawElements(PrimitiveType.TriangleFan, indices.Length, DrawElementsType.UnsignedInt, 0);
        }



        


        public void RotateX(Punto3D center, float angle)
        {

            float radiansX = MathHelper.DegreesToRadians(0.0f);
            float radiansY = MathHelper.DegreesToRadians(angle);
            float radiansZ = MathHelper.DegreesToRadians(0.0f);
            Matrix4 trans1 = Matrix4.CreateTranslation(-center.X, -center.Y, -center.Z);
            Matrix4 rot = Matrix4.CreateRotationZ(radiansZ) * Matrix4.CreateRotationY(radiansY) * Matrix4.CreateRotationX(radiansX);
            Matrix4 trans2 = Matrix4.CreateTranslation(center.X, center.Y, center.Z);

            _trans = trans1 * rot * trans2* _trans;
        }

        public void Trasladar(Punto3D center, float x = 0, float y = 0, float z = 0)
        {
            _translationMatrix = Matrix4.CreateTranslation(x + center.X, y + center.Y, z + center.Z);
            _trans = _translationMatrix * _trans;

        }


    }

}

