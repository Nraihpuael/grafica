using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp1.Objetos
{
    internal class T
    {
        int VertexBufferObject;
        int ElementBufferObject;
        int VertexArrayObject;

        float[] vertices = new float[]
        {
            // Palo vertical
            // Cara frontal
            -0.1f, 0.5f, 0.1f, 1.0f, 0.0f, 0.0f,
             0.1f, 0.5f, 0.1f, 1.0f, 0.0f, 0.0f,
             0.1f, -0.2f, 0.1f, 1.0f, 0.0f, 0.0f,
            -0.1f, -0.2f, 0.1f, 1.0f, 0.0f, 0.0f,

            // Cara trasera
            -0.1f, 0.5f, -0.1f, 0.0f, 1.0f, 0.0f,
             0.1f, 0.5f, -0.1f, 0.0f, 1.0f, 0.0f,
             0.1f, -0.2f, -0.1f, 0.0f, 1.0f, 0.0f,
            -0.1f, -0.2f, -0.1f, 0.0f, 1.0f, 0.0f,

            // Cara izquierda
            -0.1f, 0.5f, -0.1f, 0.0f, 0.0f, 1.0f,
            -0.1f, 0.5f, 0.1f, 0.0f, 0.0f, 1.0f,
            -0.1f, -0.2f, 0.1f, 0.0f, 0.0f, 1.0f,
            -0.1f, -0.2f, -0.1f, 0.0f, 0.0f, 1.0f,

            // Cara derecha
             0.1f, 0.5f, -0.1f, 1.0f, 1.0f, 0.0f,
             0.1f, 0.5f, 0.1f, 1.0f, 1.0f, 0.0f,
             0.1f, -0.2f, 0.1f, 1.0f, 1.0f, 0.0f,
             0.1f, -0.2f, -0.1f, 1.0f, 1.0f, 0.0f,

            // Cara superior
            -0.1f, 0.5f, 0.1f, 1.0f, 0.5f, 0.0f,
             0.1f, 0.5f, 0.1f, 1.0f, 0.5f, 0.0f,
             0.1f, 0.5f, -0.1f, 1.0f, 0.5f, 0.0f,
            -0.1f, 0.5f, -0.1f, 1.0f, 0.5f, 0.0f,

            // Cara inferior
            -0.1f, -0.2f, 0.1f, 0.5f, 1.0f, 1.0f,
             0.1f, -0.2f, 0.1f, 0.5f, 1.0f, 1.0f,
             0.1f, -0.2f, -0.1f, 0.5f, 1.0f, 1.0f,
            -0.1f, -0.2f, -0.1f, 0.5f, 1.0f, 1.0f,

            // Palo horizontal
            // Cara frontal
            -0.5f, 0.7f, 0.1f, 1.0f, 0.0f, 1.0f,
             0.5f, 0.7f, 0.1f, 1.0f, 0.0f, 1.0f,
             0.5f, 0.5f, 0.1f, 1.0f, 0.0f, 1.0f,
            -0.5f, 0.5f, 0.1f, 1.0f, 0.0f, 1.0f,

            // Cara trasera
            -0.5f, 0.7f, -0.1f, 0.5f, 0.5f, 1.0f,
             0.5f, 0.7f, -0.1f, 0.5f, 0.5f, 1.0f,
             0.5f, 0.5f, -0.1f, 0.5f, 0.5f, 1.0f,
            -0.5f, 0.5f, -0.1f, 0.5f, 0.5f, 1.0f,

            // Cara izquierda
            -0.5f, 0.7f, -0.1f, 0.7f, 0.3f, 0.3f,
            -0.5f, 0.7f, 0.1f, 0.7f, 0.3f, 0.3f,
            -0.5f, 0.5f, 0.1f, 0.7f, 0.3f, 0.3f,
            -0.5f, 0.5f, -0.1f, 0.7f, 0.3f, 0.3f,

            // Cara derecha
             0.5f, 0.7f, -0.1f, 0.3f, 0.7f, 0.3f,
             0.5f, 0.7f, 0.1f, 0.3f, 0.7f, 0.3f,
             0.5f, 0.5f, 0.1f, 0.3f, 0.7f, 0.3f,
             0.5f, 0.5f, -0.1f, 0.3f, 0.7f, 0.3f,

            // Cara superior
            -0.5f, 0.7f, 0.1f, 0.5f, 0.7f, 0.5f,
             0.5f, 0.7f, 0.1f, 0.5f, 0.7f, 0.5f,
             0.5f, 0.7f, -0.1f, 0.5f, 0.7f, 0.5f,
            -0.5f, 0.7f, -0.1f, 0.5f, 0.7f, 0.5f,

            // Cara inferior
            -0.5f, 0.5f, 0.1f, 0.9f, 0.8f, 0.2f,
             0.5f, 0.5f, 0.1f, 0.9f, 0.8f, 0.2f,
             0.5f, 0.5f, -0.1f, 0.9f, 0.8f, 0.2f,
            -0.5f, 0.5f, -0.1f, 0.9f, 0.8f, 0.2f,
        };


        int[] indices = new int[]
        {
        // Vertical part of the "T"
        // Front face
        0, 1, 2,
        2, 3, 0,

        // Back face
        4, 5, 6,
        6, 7, 4,

        // Top face
        8, 9, 10,
        10, 11, 8,

        // Bottom face
        12, 13, 14,
        14, 15, 12,

        // Left face
        16, 17, 18,
        18, 19, 16,

        // Right face
        20, 21, 22,
        22, 23, 20,

        // Horizontal part of the "T"
        // Front face
        24, 25, 26,
        26, 27, 24,

        // Back face
        28, 29, 30,
        30, 31, 28,

        // Top face
        32, 33, 34,
        34, 35, 32,

        // Bottom face
        36, 37, 38,
        38, 39, 36,

        // Left face
        40, 41, 42,
        42, 43, 40,

        // Right face
        44, 45, 46,
        46, 47, 44
        };

        public void Dibujar()
        {      

            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);

            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

    }


    /*
     GL.Begin(PrimitiveType.Polygon);

            // Palo vertical de la "T"

            // Cara frontal
            GL.Vertex3(-0.1f, 0.5f, 0.1f);
            GL.Vertex3(0.1f, 0.5f, 0.1f);
            GL.Vertex3(0.1f, -0.5f, 0.1f);
            GL.Vertex3(-0.1f, -0.5f, 0.1f);

            // Cara trasera
            GL.Vertex3(-0.1f, 0.5f, -0.1f);
            GL.Vertex3(0.1f, 0.5f, -0.1f);
            GL.Vertex3(0.1f, -0.5f, -0.1f);
            GL.Vertex3(-0.1f, -0.5f, -0.1f);

            // Cara izquierda
            GL.Vertex3(-0.1f, 0.5f, -0.1f);
            GL.Vertex3(-0.1f, 0.5f, 0.1f);
            GL.Vertex3(-0.1f, -0.5f, 0.1f);
            GL.Vertex3(-0.1f, -0.5f, -0.1f);

            // Cara derecha
            GL.Vertex3(0.1f, 0.5f, -0.1f);
            GL.Vertex3(0.1f, 0.5f, 0.1f);
            GL.Vertex3(0.1f, -0.5f, 0.1f);
            GL.Vertex3(0.1f, -0.5f, -0.1f);

            // Cara superior
            GL.Vertex3(-0.1f, 0.5f, 0.1f);
            GL.Vertex3(0.1f, 0.5f, 0.1f);
            GL.Vertex3(0.1f, 0.5f, -0.1f);
            GL.Vertex3(-0.1f, 0.5f, -0.1f);

            // Cara inferior
            GL.Vertex3(-0.1f, -0.5f, 0.1f);
            GL.Vertex3(0.1f, -0.5f, 0.1f);
            GL.Vertex3(0.1f, -0.5f, -0.1f);
            GL.Vertex3(-0.1f, -0.5f, -0.1f);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);

            // Palo horizontal de la "T"

            // Cara frontal
            GL.Vertex3(-0.5f, 0.7f, 0.1f);
            GL.Vertex3(0.5f, 0.7f, 0.1f);
            GL.Vertex3(0.5f, 0.5f, 0.1f);
            GL.Vertex3(-0.5f, 0.5f, 0.1f);

            // Cara trasera
            GL.Vertex3(-0.5f, 0.7f, -0.1f);
            GL.Vertex3(0.5f, 0.7f, -0.1f);
            GL.Vertex3(0.5f, 0.5f, -0.1f);
            GL.Vertex3(-0.5f, 0.5f, -0.1f);

            // Cara izquierda
            GL.Vertex3(-0.5f, 0.7f, -0.1f);
            GL.Vertex3(-0.5f, 0.7f, 0.1f);
            GL.Vertex3(-0.5f, 0.5f, 0.1f);
            GL.Vertex3(-0.5f, 0.5f, -0.1f);

            // Cara derecha
            GL.Vertex3(0.5f, 0.7f, -0.1f);
            GL.Vertex3(0.5f, 0.7f, 0.1f);
            GL.Vertex3(0.5f, 0.5f, 0.1f);
            GL.Vertex3(0.5f, 0.5f, -0.1f);

            // Cara superior
            GL.Vertex3(-0.5f, 0.7f, 0.1f);
            GL.Vertex3(0.5f, 0.7f, 0.1f);
            GL.Vertex3(0.5f, 0.7f, -0.1f);
            GL.Vertex3(-0.5f, 0.7f, -0.1f);

            // Cara inferior
            GL.Vertex3(-0.5f, 0.5f, 0.1f);
            GL.Vertex3(0.5f, 0.5f, 0.1f);
            GL.Vertex3(0.5f, 0.5f, -0.1f);
            GL.Vertex3(-0.5f, 0.5f, -0.1f);

            GL.End();
     */
}
