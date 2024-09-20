using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Objetos
{
    internal class T
    {

        public static Objeto CrearT(Punto3D centro)
        {
           var t = new Objeto(centro);
           var parteVertical = new Parte(new Punto3D(0f, 0f, 0f));

           parteVertical.AgregarPoligono("Frontal", new Poligono(
           new float[]
           {
                -0.1f, 0.4f, 0.1f, 2.0f, 2.0f, 2.0f,
                 0.1f, 0.4f, 0.1f, 2.0f, 2.0f, 2.0f,
                 0.1f, -0.3f, 0.1f, 2.0f, 2.0f, 2.0f,
                -0.1f, -0.3f, 0.1f, 2.0f, 2.0f, 2.0f,
           }));

            parteVertical.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.1f, 0.4f, -0.1f, 0.0f, 1.0f, 0.0f,
                 0.1f, 0.4f, -0.1f, 0.0f, 1.0f, 0.0f,
                 0.1f, -0.3f, -0.1f, 0.0f, 1.0f, 0.0f,
                -0.1f, -0.3f, -0.1f, 0.0f, 1.0f, 0.0f,
            }));

            parteVertical.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.1f, 0.4f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.1f, 0.4f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.1f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.1f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));

            parteVertical.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                 0.1f, 0.4f, -0.1f, 1.0f, 1.0f, 0.0f,
                 0.1f, 0.4f, 0.1f, 1.0f, 1.0f, 0.0f,
                 0.1f, -0.3f, 0.1f, 1.0f, 1.0f, 0.0f,
                 0.1f, -0.3f, -0.1f, 1.0f, 1.0f, 0.0f,
            }));

            parteVertical.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -0.1f, 0.4f, 0.1f, 1.0f, 0.5f, 0.0f,
                 0.1f, 0.4f, 0.1f, 1.0f, 0.5f, 0.0f,
                 0.1f, 0.4f, -0.1f, 1.0f, 0.5f, 0.0f,
                -0.1f, 0.4f, -0.1f, 1.0f, 0.5f, 0.0f,
            }));

            parteVertical.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -0.1f, -0.3f, 0.1f, 0.5f, 1.0f, 1.0f,
                 0.1f, -0.3f, 0.1f, 0.5f, 1.0f, 1.0f,
                 0.1f, -0.3f, -0.1f, 0.5f, 1.0f, 1.0f,
                -0.1f, -0.3f, -0.1f, 0.5f, 1.0f, 1.0f,
            }));

            t.AgregarParte("Vertical", parteVertical);


            ////////////////////////////////////////////////////////////////
            
            var parteHorizontal = new Parte(new Punto3D(0f, 0.5f, 0f));

            parteHorizontal.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.5f, 0.1f, 0.1f, 1.0f, 0.0f, 1.0f,
                 0.5f, 0.1f, 0.1f, 1.0f, 0.0f, 1.0f,
                 0.5f, -0.1f, 0.1f, 1.0f, 0.0f, 1.0f,
                -0.5f, -0.1f, 0.1f, 1.0f, 0.0f, 1.0f,
            }));

            parteHorizontal.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.5f, 0.1f, -0.1f, 0.5f, 0.5f, 1.0f,
                 0.5f, 0.1f, -0.1f, 0.5f, 0.5f, 1.0f,
                 0.5f, -0.1f, -0.1f, 0.5f, 0.5f, 1.0f,
                -0.5f, -0.1f, -0.1f, 0.5f, 0.5f, 1.0f,
            }));

            parteHorizontal.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.5f, 0.1f, -0.1f, 0.7f, 0.3f, 0.3f,
                -0.5f, 0.1f, 0.1f, 0.7f, 0.3f, 0.3f,
                -0.5f, -0.1f, 0.1f, 0.7f, 0.3f, 0.3f,
                -0.5f, -0.1f, -0.1f, 0.7f, 0.3f, 0.3f,
            }));

            parteHorizontal.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                 0.5f, 0.1f, -0.1f, 0.3f, 0.7f, 0.3f,
                 0.5f, 0.1f, 0.1f, 0.3f, 0.7f, 0.3f,
                 0.5f, -0.1f, 0.1f, 0.3f, 0.7f, 0.3f,
                 0.5f, -0.1f, -0.1f, 0.3f, 0.7f, 0.3f,
            }));

            parteHorizontal.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -0.5f, 0.1f, 0.1f, 0.5f, 0.7f, 0.5f,
                 0.5f, 0.1f, 0.1f, 0.5f, 0.7f, 0.5f,
                 0.5f, 0.1f, -0.1f, 0.5f, 0.7f, 0.5f,
                -0.5f, 0.1f, -0.1f, 0.5f, 0.7f, 0.5f,
            }));

            parteHorizontal.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -0.5f, -0.1f, 0.1f, 0.9f, 0.8f, 0.2f,
                 0.5f, -0.1f, 0.1f, 0.9f, 0.8f, 0.2f,
                 0.5f, -0.1f, -0.1f, 0.9f, 0.8f, 0.2f,
                -0.5f, -0.1f, -0.1f, 0.9f, 0.8f, 0.2f,
            }));

            t.AgregarParte("Horizontal", parteHorizontal);


            return t;

        }

    }
   
}
