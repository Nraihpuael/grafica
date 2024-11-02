using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Objetos
{
    internal class Pelota
    {
        public static Objeto CrearPelota(Punto3D centro)
        {
            var pelota = new Objeto(centro);
            float[] vertices;

            float radio = 0.5f;
            int numSegmentos = 7;
            int numAnillos = 7;

            vertices = new float[(numAnillos + 1) * (numSegmentos + 1) * 6];
            int vertexIndex = 0;

            int color = 1;
            for (int i = 0; i <= numAnillos; i++)
            {
                float phi = (float)i / numAnillos * MathHelper.Pi;
                for (int j = 0; j <= numSegmentos; j++)
                {
                    
                    float theta = (float)j / numSegmentos * MathHelper.TwoPi;
                    float x = radio * (float)Math.Sin(phi) * (float)Math.Cos(theta);
                    float y = radio * (float)Math.Cos(phi);
                    float z = radio * (float)Math.Sin(phi) * (float)Math.Sin(theta);
                    float r = 0.0f + color; // Componente rojo
                    float g = 0.0f + color; // Componente verde
                    float b = 0.0f + color; // Componente azul
                    vertices[vertexIndex++] = x;
                    vertices[vertexIndex++] = y;
                    vertices[vertexIndex++] = z;
                    vertices[vertexIndex++] = r;
                    vertices[vertexIndex++] = g;
                    vertices[vertexIndex++] = b;
                    color = color * (-1);
                }
            }


            var partePelota = new Parte(new Punto3D(0f, 0f, 0f));

            partePelota.AgregarPoligono("Pelota", new Poligono(vertices));

            pelota.AgregarParte("Pelota", partePelota);

            return pelota;
        }
    }
}
