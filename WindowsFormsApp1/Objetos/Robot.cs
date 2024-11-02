using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Estructura;

namespace WindowsFormsApp1.Objetos
{
    internal class Robot
    {
        public static Objeto CrearRobot(Punto3D centro)
        {
            var robot = new Objeto(centro);

///////////// Cabeza (color blanco) /////////////////////////////
            var cabeza = new Parte(new Punto3D(0f, 1.2f, 0f));
            cabeza.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
            }));
            cabeza.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
            }));
            cabeza.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
            }));
            cabeza.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
            }));
            cabeza.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                -0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
            }));
            cabeza.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.2f, 0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, 0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, -0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
                 0.2f, 0.2f, -0.2f, 1.0f, 1.0f, 1.0f,
            }));

            robot.AgregarParte("Cabeza", cabeza);



////////////// Torso (color gris)/////////////////////////////
            var torso = new Parte(new Punto3D(0f, 0.5f, 0f));
            torso.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.4f, 0.5f, 0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, 0.5f, 0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, -0.5f, 0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, -0.5f, 0.2f, 0.5f, 0.5f, 0.5f,
            }));
            torso.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
            }));
            torso.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, 0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, -0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
            }));
            torso.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                0.4f, 0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                0.4f, -0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
            }));

            torso.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, 0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, 0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, 0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
            }));

            torso.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, -0.5f, -0.2f, 0.5f, 0.5f, 0.5f,
                 0.4f, -0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
                -0.4f, -0.5f,  0.2f, 0.5f, 0.5f, 0.5f,
            }));

            robot.AgregarParte("Torso", torso);



////////////// Brazo Izquierdo Superior (color Azul)/////////////////////////////
            var brazoIzquierdoSuperior = new Parte(new Punto3D(-0.6f, 0.7f, 0f));
            brazoIzquierdoSuperior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoIzquierdoSuperior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoIzquierdoSuperior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoIzquierdoSuperior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoIzquierdoSuperior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoIzquierdoSuperior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            robot.AgregarParte("BrazoIzquierdoSuperior", brazoIzquierdoSuperior);



////////////// Brazo Derecho Superior (color Azul)/////////////////////////////
            var brazoDerechoSuperior = new Parte(new Punto3D(0.6f, 0.7f, 0f));
            brazoDerechoSuperior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoDerechoSuperior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoDerechoSuperior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoDerechoSuperior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoDerechoSuperior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            brazoDerechoSuperior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.2f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.2f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            robot.AgregarParte("BrazoDerechoSuperior", brazoDerechoSuperior);



////////////// Brazo Izquierdo Inferior (color Blanco)/////////////////////////////
            var brazoIzquierdoInferior = new Parte(new Punto3D(-0.6f, 0.1f, 0f));
            brazoIzquierdoInferior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoIzquierdoInferior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoIzquierdoInferior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoIzquierdoInferior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoIzquierdoInferior.AgregarPoligono("LateralIzquierda", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoIzquierdoInferior.AgregarPoligono("LateralDerecha", new Poligono(new float[]
            {
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            robot.AgregarParte("BrazoIzquierdoInferior", brazoIzquierdoInferior);




////////////// Brazo Derecho Inferior (color Blanco)/////////////////////////////
            var brazoDerechoInferior = new Parte(new Punto3D(0.6f, 0.1f, 0f));
            brazoDerechoInferior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoDerechoInferior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoDerechoInferior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoDerechoInferior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoDerechoInferior.AgregarPoligono("LateralIzquierda", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            brazoDerechoInferior.AgregarPoligono("LateralDerecha", new Poligono(new float[]
            {
                 0.15f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            robot.AgregarParte("BrazoDerechoInferior", brazoDerechoInferior);




////////////// Pierna Derecho Inferior (color Azul)/////////////////////////////
            var piernaIzquierdaSuperior = new Parte(new Punto3D(-0.2f, -0.3f, 0f));
            piernaIzquierdaSuperior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaIzquierdaSuperior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaIzquierdaSuperior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaIzquierdaSuperior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaIzquierdaSuperior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaIzquierdaSuperior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            robot.AgregarParte("PiernaIzquierdaSuperior", piernaIzquierdaSuperior);



////////////// Pierna Derecho Inferior (color Azul)/////////////////////////////
            var piernaDerechaSuperior = new Parte(new Punto3D(0.2f, -0.3f, 0f));
            piernaDerechaSuperior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaDerechaSuperior.AgregarPoligono("Trasera", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaDerechaSuperior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaDerechaSuperior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaDerechaSuperior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                -0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            piernaDerechaSuperior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.15f, 0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, 0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, 0.1f, 0.0f, 0.0f, 1.0f,
                 0.15f, -0.3f, -0.1f, 0.0f, 0.0f, 1.0f,
            }));
            robot.AgregarParte("PiernaDerechaSuperior", piernaDerechaSuperior);



////////////// Pierna Izquierdo Inferior (color Blanco)/////////////////////////////
            var piernaIzquierdaInferior = new Parte(new Punto3D(-0.2f, -0.9f, 0f));
            piernaIzquierdaInferior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaIzquierdaInferior.AgregarPoligono("Posterior", new Poligono(new float[]
            {
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaIzquierdaInferior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaIzquierdaInferior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaIzquierdaInferior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaIzquierdaInferior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            robot.AgregarParte("PiernaIzquierdaInferior", piernaIzquierdaInferior);



////////////// Pierna Derecho Inferior (color Blanco)/////////////////////////////
            var piernaDerechaInferior = new Parte(new Punto3D(0.2f, -0.9f, 0f));
            piernaDerechaInferior.AgregarPoligono("Frontal", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaDerechaInferior.AgregarPoligono("Posterior", new Poligono(new float[]
            {
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaDerechaInferior.AgregarPoligono("Izquierda", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaDerechaInferior.AgregarPoligono("Derecha", new Poligono(new float[]
            {
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaDerechaInferior.AgregarPoligono("Superior", new Poligono(new float[]
            {
                -0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, 0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            piernaDerechaInferior.AgregarPoligono("Inferior", new Poligono(new float[]
            {
                -0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, 0.1f, 1.0f, 1.0f, 1.0f,
                 0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
                -0.13f, -0.3f, -0.1f, 1.0f, 1.0f, 1.0f,
            }));
            robot.AgregarParte("PiernaDerechaInferior", piernaDerechaInferior);


            return robot;
        }
    }
}
