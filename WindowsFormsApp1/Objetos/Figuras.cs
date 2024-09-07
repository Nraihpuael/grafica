using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Objetos
{
    public class Figuras
    {
        public static Objeto CrearMonitor()
        {
            var monitor = new Objeto(new Vector3(0f, -0.3f, 0.5f));
            var parteMonitor = new Parte(new Vector3(0f, 0f, 0f));

            // Definir las Poligonos del monitor
            parteMonitor.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.4f, 0.6f,  0.0f, 0.0f, 0.0f, 1.0f,
                 0.4f, 0.6f,  0.0f, 1.0f, 1.0f, 0.0f,

                -0.4f, 0.3f,  0.0f, 0.0f, 1.0f, 0.0f,
                 0.4f, 0.3f,  0.0f, 1.0f, 0.0f, 0.0f
            }));


            parteMonitor.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.4f, 0.6f, -0.05f, 0.0f, 0.0f, 0.0f,
                 0.4f, 0.6f, -0.05f, 0.0f, 0.0f, 0.0f,
                -0.4f, 0.3f, -0.05f, 0.0f, 0.0f, 0.0f,
                 0.4f, 0.3f, -0.05f, 0.0f, 0.0f, 0.0f
            }));

            parteMonitor.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -0.4f, 0.6f,  0.0f,  0.0f, 0.0f, 0.0f,
                 0.4f, 0.6f,  0.0f,  0.0f, 0.0f, 0.0f,
                -0.4f, 0.6f, -0.05f, 0.0f, 0.0f, 0.0f,
                 0.4f, 0.6f, -0.05f, 0.0f, 0.0f, 0.0f
            }));

            parteMonitor.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -0.4f, 0.3f,  0.0f,  0.0f, 0.0f, 0.0f,
                 0.4f, 0.3f,  0.0f,  0.0f, 0.0f, 0.0f,
                -0.4f, 0.3f, -0.05f, 0.0f, 0.0f, 0.0f,
                 0.4f, 0.3f, -0.05f, 0.0f, 0.0f, 0.0f
            }));

            parteMonitor.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.4f, 0.6f,  0.0f,  0.5f, 0.5f, 0.5f,
                -0.4f, 0.6f, -0.05f, 0.5f, 0.5f, 0.5f,
                -0.4f, 0.3f,  0.0f,  0.5f, 0.5f, 0.5f,
                -0.4f, 0.3f, -0.05f, 0.5f, 0.5f, 0.5f
            }));

            parteMonitor.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                 0.4f, 0.6f,  0.0f,  0.5f, 0.5f, 0.5f,
                 0.4f, 0.6f, -0.05f, 0.5f, 0.5f, 0.5f,
                 0.4f, 0.3f,  0.0f,  0.5f, 0.5f, 0.5f,
                 0.4f, 0.3f, -0.05f, 0.5f, 0.5f, 0.5f
            }));

            // Agregar parte del monitor al objeto monitor
            monitor.AgregarParte("Pantalla", parteMonitor);

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Crear parte del soporte
            var parteSoporte = new Parte(new Vector3(0f, 0f, 0f));

            // Definir las Poligonos del soporte
            parteSoporte.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.05f, 0.3f,  0.0f, 0.54f, 0.27f, 0.07f,
                 0.05f, 0.3f,  0.0f, 0.54f, 0.27f, 0.07f,
                -0.1f,  0.1f,  0.0f, 0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f,  0.0f, 0.54f, 0.27f, 0.07f
            }));

            parteSoporte.AgregarPoligono("Trasera", new Poligono(
           new float[]
           {
                -0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f,
                 0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f,
                -0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f
           }));

            parteSoporte.AgregarPoligono("Superior", new Poligono(
           new float[]
           {
                -0.05f, 0.3f,  0.0f,  0.54f, 0.27f, 0.07f,
                 0.05f, 0.3f,  0.0f,  0.54f, 0.27f, 0.07f,
                -0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f,
                 0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f
           }));

            parteSoporte.AgregarPoligono("Inferior", new Poligono(
           new float[]
           {
                -0.1f,  0.1f,   0.0f, 0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f,   0.0f, 0.54f, 0.27f, 0.07f,
                -0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f
           }));

            parteSoporte.AgregarPoligono("Izquierda", new Poligono(
           new float[]
           {
                -0.05f, 0.3f,  0.0f,  0.54f, 0.27f, 0.07f,
                -0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f,
                -0.1f,  0.1f,  0.0f,  0.54f, 0.27f, 0.07f,
                -0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f
           }));

            parteSoporte.AgregarPoligono("Derecha", new Poligono(
           new float[]
           {
                 0.05f, 0.3f,  0.0f,  0.54f, 0.27f, 0.07f,
                 0.05f, 0.3f, -0.05f, 0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f,  0.0f,  0.54f, 0.27f, 0.07f,
                 0.1f,  0.1f, -0.05f, 0.54f, 0.27f, 0.07f
           }));

            // Agregar parte del soporte al objeto monitor
            monitor.AgregarParte("Soporte", parteSoporte);


            return monitor;
        }


        public static Objeto CrearMesa()
        {
            var mesa = new Objeto(new Vector3(0f, -0.705f, 0.5f));

/////////////////////////////////Tablon//////////////////////////////////////////////////////////////////////////          
            var parteTablon = new Parte(new Vector3(0f, 0f, 0f));
            parteTablon.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.45f, 0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f, 0.3f, 0.8f, 0.5f, 0.3f
            }));
            parteTablon.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f
            }));
            parteTablon.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f
            }));
            parteTablon.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -1f,  0.45f,  0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f,  0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f
            }));
            parteTablon.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.45f,  0.3f, 0.8f, 0.5f, 0.3f,
                -1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f
            }));
            parteTablon.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                 1f,  0.5f,  0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.5f, -0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f,  0.3f, 0.8f, 0.5f, 0.3f,
                 1f,  0.45f, -0.3f, 0.8f, 0.5f, 0.3f
            }));

///////////////////////Pata 1 (Frontal Izquierda)//////////////////////////////////////////////////////////////////////////
            var parte1 = new Parte(new Vector3(0f, 0f, 0f));
            parte1.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
            }));
            parte1.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte1.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte1.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -0.95f, 0.0f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f, 0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte1.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte1.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                -0.9f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));


            ///////////////////////Pata 2 (Frontal Derecha)////////////////////////////////////////////////////////////////////////////
            var parte2 = new Parte(new Vector3(0f, 0f, 0f));
            parte2.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
            }));
            parte2.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte2.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte2.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                0.95f, 0.0f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f, 0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte2.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                0.95f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte2.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                0.9f, 0.45f, 0.3f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.45f, 0.25f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.0f,  0.3f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.0f,  0.25f, 0.6f, 0.4f, 0.2f,
            }));

            ///////////////////////Pata 3 (Trasera Izquierda)//////////////////////////////////////////////////////////////////////////
            var parte3 = new Parte(new Vector3(0f, 0f, 0f));
            parte3.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
            }));
            parte3.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte3.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte3.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                -0.95f, 0.0f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f,  0.0f, -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte3.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                -0.95f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte3.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                -0.9f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                -0.9f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));

            ///////////////////////Pata 4 (Trasera Derecha)//////////////////////////////////////////////////////////////////////////
            var parte4 = new Parte(new Vector3(0f, 0f, 0f));
            parte4.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
            }));
            parte4.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte4.AgregarPoligono("Superior", new Poligono(
            new float[]
            {
                0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte4.AgregarPoligono("Inferior", new Poligono(
            new float[]
            {
                0.95f, 0.0f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.9f,  0.0f, -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte4.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                0.95f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                0.95f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));
            parte4.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                0.9f, 0.45f, -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.45f, -0.25f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.0f,  -0.3f, 0.6f, 0.4f, 0.2f,
                0.9f, 0.0f,  -0.25f, 0.6f, 0.4f, 0.2f,
            }));

            // Agregar parte de la mesa al objeto mesa
            mesa.AgregarParte("Tablon", parteTablon);
            mesa.AgregarParte("FrontalIzquierda", parte1);
            mesa.AgregarParte("FrontalDerecha", parte2);
            mesa.AgregarParte("TraseraIzquierda", parte3);
            mesa.AgregarParte("TraseraDerecha", parte4);

            return mesa;
        }

        public static Objeto CrearJarron()
        {
            var jarron = new Objeto(new Vector3(-0.7f, -0.2f, 0.6f));
            var cuerpoJarron = new Parte(new Vector3(0f, 0f, 0f));
            cuerpoJarron.AgregarPoligono("Frontal", new Poligono(
            new float[]
            {
                -0.07f, 0.3f,  0.07f, 0.0f, 0.0f, 1.0f,
                 0.07f, 0.3f,  0.07f, 0.0f, 0.0f, 1.0f,
                -0.1f,  0.0f,  0.07f, 0.0f, 0.0f, 1.0f,
                 0.1f,  0.0f,  0.07f, 0.0f, 0.0f, 1.0f
            }));
            cuerpoJarron.AgregarPoligono("Trasera", new Poligono(
            new float[]
            {
                -0.07f, 0.3f, -0.07f, 0.0f, 0.0f, 1.0f,
                 0.07f, 0.3f, -0.07f, 0.0f, 0.0f, 1.0f,
                -0.1f,  0.0f, -0.07f, 0.0f, 0.0f, 1.0f,
                 0.1f,  0.0f, -0.07f, 0.0f, 0.0f, 1.0f
            }));
           
            cuerpoJarron.AgregarPoligono("Izquierda", new Poligono(
            new float[]
            {
                -0.07f, 0.3f, -0.07f, 0.0f, 0.0f, 1.0f,
                -0.07f, 0.3f,  0.07f, 0.0f, 0.0f, 1.0f,
                -0.1f,  0.0f, -0.07f, 0.0f, 0.0f, 1.0f,
                -0.1f,  0.0f,  0.07f, 0.0f, 0.0f, 1.0f
            }));

            cuerpoJarron.AgregarPoligono("Derecha", new Poligono(
            new float[]
            {
                 0.07f, 0.3f, -0.07f, 0.0f, 0.0f, 1.0f,
                 0.07f, 0.3f,  0.07f, 0.0f, 0.0f, 1.0f,
                 0.1f,  0.0f, -0.07f, 0.0f, 0.0f, 1.0f,
                 0.1f,  0.0f,  0.07f, 0.0f, 0.0f, 1.0f
            }));



            // Agregar parte del monitor al objeto monitor
            jarron.AgregarParte("Cuerpo", cuerpoJarron);


            return jarron;
        }

        


    }
}
