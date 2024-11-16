using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WindowsFormsApp1.Animacion;
using WindowsFormsApp1.Estructura;
using WindowsFormsApp1.Objetos;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        GLControl lienzoControl;
        Camara camara;
        private Matrix4 projection;
        Escenario escenario;
        Libreto libreto;
        System.Windows.Forms.Timer timer;
        Shader shader;

        private ManualResetEvent pausaEvento = new ManualResetEvent(true);
        private bool isDragging = false;
        private Point lastMousePosition;
        private bool isAnimating = false;

        public Form1()
        {
            InitializeComponent();

            lienzoControl = new GLControl(new GraphicsMode(32, 24, 0, 4));
            timer = new System.Windows.Forms.Timer { Interval = 16 };
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Focus();



            this.KeyPreview = true;
            lienzoControl.Focus(); 

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            lienzoControl.MouseDown += GlControlMouseDown;
            lienzoControl.MouseUp += GlControlMouseUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lienzoControl = new GLControl
            {
                BackColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(400, 37),
                Name = "miglControl",
                Size = new System.Drawing.Size(930, 600),
                TabIndex = 2,
                VSync = false
            };
            this.lienzoControl.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControlRender);
            this.lienzoControl.Resize += new System.EventHandler(this.GlControlResize);
            this.lienzoControl.Load += new System.EventHandler(this.GlControlLoad);
            this.lienzoControl.MouseDown += new MouseEventHandler(this.GlControlMouseDown);
            this.lienzoControl.MouseUp += new MouseEventHandler(this.GlControlMouseUp);
            this.lienzoControl.MouseMove += new MouseEventHandler(this.GlControlMouseMove);
            this.lienzoControl.Enter += new EventHandler(lienzoControl_Enter);
            this.panel1.Controls.Add(lienzoControl);

        }

        private void GlControlLoad(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            camara = new Camara(
             new Vector3(0.0f, 0.0f, 9.0f),
             new Vector3(0.0f, 0.0f, -1.0f),
             new Vector3(0.0f, 1.0f, 0.0f)
            );

            shader = new Shader("../../shaders/shader.vert", "../../shaders/shader.frag");           

            projection = ConfigurarMatrizProyeccion();
            escenario = new Escenario();

            /*
                Objeto t = T.CrearT(new Punto3D(2.0f, 0.1f, 0.2f));
                escenario.AgregarObjeto("T", t);

                Objeto robot = Robot.CrearRobot(new Punto3D(-4.0f, 0.1f, 0.2f));
                escenario.AgregarObjeto("Robot", robot);

                Objeto pelota2 = Pelota.CrearPelota(new Punto3D(0.8f, 2.6f, 0.0f));
                escenario.AgregarObjeto("Pelota", pelota2);
            */

            /*
            Accion girarRobot = new Accion("Robot", 500, 0);
            Transformacion girarRobot1 = new Transformacion("Rotacion", new Punto3D(0.0f, 90.0f, 0), 500); // Mover hacia adelante
            girarRobot.AgregarTransformacion(girarRobot1);


            //// PASO 1///
            Accion accionarPiernaDerechaSuperior = new Accion("PiernaDerechaSuperior", 5000, 1000);
            Transformacion rotarPiernaDerechaSuperior = new Transformacion("Rotacion", new Punto3D(-15.0f, 0, 0), 5000); 
            Transformacion moverPiernaDerechaSuperior = new Transformacion("Traslacion", new Punto3D(0, -0.03f, 0.2f), 5000); 
            accionarPiernaDerechaSuperior.AgregarTransformacion(rotarPiernaDerechaSuperior);
            accionarPiernaDerechaSuperior.AgregarTransformacion(moverPiernaDerechaSuperior);

            Accion accionarPiernaDerechaInferior = new Accion("PiernaDerechaInferior", 5000, 1000);
            Transformacion moverPiernaDerechaInferiory = new Transformacion("Traslacion", new Punto3D(0, 0.1f, 0), 5000);
            Transformacion moverPiernaDerechaInferiorz = new Transformacion("Traslacion", new Punto3D(0, 0, 0.3f), 5000);
            accionarPiernaDerechaInferior.AgregarTransformacion(moverPiernaDerechaInferiory);
            accionarPiernaDerechaInferior.AgregarTransformacion(moverPiernaDerechaInferiorz);           

            Accion BrazoIzquierdoSuperior0 = new Accion("BrazoIzquierdoSuperior", 8000, 1000);
            Transformacion rotarBrazoIzquierdoSuperior0 = new Transformacion("Rotacion", new Punto3D(-45.0f, 0, 0), 8000);
            Transformacion moverBrazoIzquierdoSuperior0 = new Transformacion("Traslacion", new Punto3D(0, -0.03f, 0.1f), 8000);
            BrazoIzquierdoSuperior0.AgregarTransformacion(rotarBrazoIzquierdoSuperior0);
            BrazoIzquierdoSuperior0.AgregarTransformacion(moverBrazoIzquierdoSuperior0);


            Accion BrazoIzquierdoInferior0 = new Accion("BrazoIzquierdoInferior", 8000, 1000);
            Transformacion rotarBrazoIzquierdoInferior0 = new Transformacion("Rotacion", new Punto3D(-60.0f, 0, 0), 8000);
            Transformacion moverBrazoIzquierdoInferior0 = new Transformacion("Traslacion", new Punto3D(0, -0.05f, 0.65f), 8000);
            BrazoIzquierdoInferior0.AgregarTransformacion(rotarBrazoIzquierdoInferior0);
            BrazoIzquierdoInferior0.AgregarTransformacion(moverBrazoIzquierdoInferior0);

            Accion BrazoDerechoSuperior0 = new Accion("BrazoDerechoSuperior", 8000, 1000);
            Transformacion rotarBrazoDerechoSuperior0 = new Transformacion("Rotacion", new Punto3D(30.0f, 0, 0), 8000);
            Transformacion moverBrazoDerechoSuperior0 = new Transformacion("Traslacion", new Punto3D(0, -0.03f, -0.05f), 8000);
            BrazoDerechoSuperior0.AgregarTransformacion(moverBrazoDerechoSuperior0);
            BrazoDerechoSuperior0.AgregarTransformacion(rotarBrazoDerechoSuperior0);


            Accion BrazoDerechoInferior0 = new Accion("BrazoDerechoInferior", 8000, 1000);
            Transformacion rotarBrazoDerechoInferior0 = new Transformacion("Rotacion", new Punto3D(30.0f, 0, 0), 8000);
            Transformacion moverBrazoDerechoInferior0 = new Transformacion("Traslacion", new Punto3D(0, -0.03f, -0.35f), 8000);
            BrazoDerechoInferior0.AgregarTransformacion(moverBrazoDerechoInferior0);
            BrazoDerechoInferior0.AgregarTransformacion(rotarBrazoDerechoInferior0);

            
            Accion accionarPiernaDerechaInferior2 = new Accion("PiernaDerechaInferior", 5000, 6000);
            Transformacion rotarPiernaDerechaInferior = new Transformacion("Rotacion", new Punto3D(-12.0f, 0, 0), 5000);
            Transformacion moverPiernaDerechaInferior2 = new Transformacion("Traslacion", new Punto3D(0, -0.13f, 0.05f), 5000);
            accionarPiernaDerechaInferior.AgregarTransformacion(rotarPiernaDerechaInferior);
            accionarPiernaDerechaInferior.AgregarTransformacion(moverPiernaDerechaInferior2);
            
            Accion accionarPiernaDerechaSuperior2 = new Accion("PiernaDerechaSuperior", 5000, 11000);
            Transformacion rotarPiernaDerechaSuperior2 = new Transformacion("Rotacion", new Punto3D(15, 0, 0), 5000); 
            Transformacion moverPiernaDerechaSuperior2 = new Transformacion("Traslacion", new Punto3D(0, -0.02f, 0.3f), 5000); 
            accionarPiernaDerechaSuperior2.AgregarTransformacion(rotarPiernaDerechaSuperior2);
            accionarPiernaDerechaSuperior2.AgregarTransformacion(moverPiernaDerechaSuperior2);

            Accion accionarPiernaDerechaInferior3 = new Accion("PiernaDerechaInferior", 5000, 11000);
            Transformacion rotarPiernaDerechaInferior3 = new Transformacion("Rotacion", new Punto3D(10, 0, 0), 5000); 
            Transformacion moverPiernaDerechaInferior3 = new Transformacion("Traslacion", new Punto3D(0, -0.02f, 0.15f), 5000); 
            accionarPiernaDerechaInferior3.AgregarTransformacion(rotarPiernaDerechaInferior3);
            accionarPiernaDerechaInferior3.AgregarTransformacion(moverPiernaDerechaInferior3);

            Accion torso = new Accion("Torso", 5000, 11000);
            Transformacion movertorso = new Transformacion("Traslacion", new Punto3D(0, 0, 0.5f), 5000); 
            torso.AgregarTransformacion(movertorso);

            Accion cabeza = new Accion("Cabeza", 5000, 11000);
            Transformacion movercabeza = new Transformacion("Traslacion", new Punto3D(0, 0, 0.5f), 5000);
            cabeza.AgregarTransformacion(movercabeza);

            Accion BrazoIzquierdoSuperior = new Accion("BrazoIzquierdoSuperior", 5000, 11000);
            Transformacion rotarBrazoIzquierdoSuperior = new Transformacion("Rotacion", new Punto3D(25.0f, 0, 0), 5000);
            Transformacion moverBrazoIzquierdoSuperior = new Transformacion("Traslacion", new Punto3D(0, -0.28f, 0.35f), 5000);
            BrazoIzquierdoSuperior.AgregarTransformacion(moverBrazoIzquierdoSuperior);
            BrazoIzquierdoSuperior.AgregarTransformacion(rotarBrazoIzquierdoSuperior);


            Accion BrazoIzquierdoInferior = new Accion("BrazoIzquierdoInferior", 5000, 11000);
            Transformacion rotarBrazoIzquierdoInferior = new Transformacion("Rotacion", new Punto3D(40.0f, 0, 0), 5000);
            Transformacion moverBrazoIzquierdoInferior = new Transformacion("Traslacion", new Punto3D(0, -0.28f, -0.03f), 5000);
            BrazoIzquierdoInferior.AgregarTransformacion(moverBrazoIzquierdoInferior);
            BrazoIzquierdoInferior.AgregarTransformacion(rotarBrazoIzquierdoInferior);


            Accion BrazoDerechoSuperior = new Accion("BrazoDerechoSuperior", 5000, 11000);
            Transformacion rotarBrazoDerechoSuperior = new Transformacion("Rotacion", new Punto3D(-10.0f, 0, 0), 5000);            
            Transformacion moverBrazoDerechoSuperior = new Transformacion("Traslacion", new Punto3D(0, 0.25f, 0.5f), 5000); 
            BrazoDerechoSuperior.AgregarTransformacion(moverBrazoDerechoSuperior);
            BrazoDerechoSuperior.AgregarTransformacion(rotarBrazoDerechoSuperior);

            Accion BrazoDerechoInferior = new Accion("BrazoDerechoInferior", 5000, 11000);
            Transformacion rotarBrazoDerechoInferior = new Transformacion("Rotacion", new Punto3D(-15.0f, 0, 0), 5000);
            Transformacion moverBrazoDerechoInferior = new Transformacion("Traslacion", new Punto3D(0, 0.22f, 0.63f), 5000); 
            BrazoDerechoInferior.AgregarTransformacion(moverBrazoDerechoInferior);
            BrazoDerechoInferior.AgregarTransformacion(rotarBrazoDerechoInferior);

            Accion PiernaIzquierdaSuperior = new Accion("PiernaIzquierdaSuperior", 5000, 11000);
            Transformacion rotarPiernaIzquierdaSuperior = new Transformacion("Rotacion", new Punto3D(20, 0, 0), 5000); 
            Transformacion moverPiernaIzquierdaSuperior = new Transformacion("Traslacion", new Punto3D(0, 0.1f, 0.45f), 5000); 
            PiernaIzquierdaSuperior.AgregarTransformacion(rotarPiernaIzquierdaSuperior);
            PiernaIzquierdaSuperior.AgregarTransformacion(moverPiernaIzquierdaSuperior);

            Accion PiernaIzquierdaInferior = new Accion("PiernaIzquierdaInferior", 5000, 11000);
            Transformacion rotarPiernaIzquierdaInferior = new Transformacion("Rotacion", new Punto3D(20, 0, 0), 5000); 
            Transformacion moverPiernaIzquierdaInferior = new Transformacion("Traslacion", new Punto3D(0, 0.1f, 0.2f), 5000);
            PiernaIzquierdaInferior.AgregarTransformacion(rotarPiernaIzquierdaInferior);
            PiernaIzquierdaInferior.AgregarTransformacion(moverPiernaIzquierdaInferior);

            
            //// PASO 2///
            Accion PiernaIzquierdaSuperior2 = new Accion("PiernaIzquierdaSuperior", 5000, 16000);
            Transformacion rotarPiernaIzquierdaSuperior2 = new Transformacion("Rotacion", new Punto3D(-40, 0, 0), 5000); 
            Transformacion moverPiernaIzquierdaSuperior2 = new Transformacion("Traslacion", new Punto3D(0, -0.03f, 0.3f), 5000); 

            PiernaIzquierdaSuperior2.AgregarTransformacion(rotarPiernaIzquierdaSuperior2);
            PiernaIzquierdaSuperior2.AgregarTransformacion(moverPiernaIzquierdaSuperior2);

            Accion PiernaIzquierdaInferior2 = new Accion("PiernaIzquierdaInferior", 5000, 16000);
            Transformacion rotarPiernaIzquierdaInferior2 = new Transformacion("Rotacion", new Punto3D(-40, 0, 0), 5000); 
            Transformacion moverPiernaIzquierdaInferior2 = new Transformacion("Traslacion", new Punto3D(0, -0.03f, 0.75f), 5000); 

            PiernaIzquierdaInferior2.AgregarTransformacion(rotarPiernaIzquierdaInferior2);
            PiernaIzquierdaInferior2.AgregarTransformacion(moverPiernaIzquierdaInferior2);

            Accion torso2 = new Accion("Torso", 10000, 21000);
            Transformacion movertorso2 = new Transformacion("Traslacion", new Punto3D(0, 0, 0.5f), 10000);
            torso2.AgregarTransformacion(movertorso2);

            Accion cabeza2 = new Accion("Cabeza", 10000, 21000);
            Transformacion movercabeza2 = new Transformacion("Traslacion", new Punto3D(0, 0, 0.5f), 10000); 
            cabeza2.AgregarTransformacion(movercabeza2);

            Accion BrazoIzquierdoSuperior2 = new Accion("BrazoIzquierdoSuperior", 10000, 21000);
            Transformacion rotarBrazoIzquierdoSuperior2 = new Transformacion("Rotacion", new Punto3D(45, 0, 0), 10000); 
            Transformacion moverBrazoIzquierdoSuperior2 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, 0.4f), 10000);
            BrazoIzquierdoSuperior2.AgregarTransformacion(moverBrazoIzquierdoSuperior2);
            BrazoIzquierdoSuperior2.AgregarTransformacion(rotarBrazoIzquierdoSuperior2);

            Accion BrazoIzquierdoInferior2 = new Accion("BrazoIzquierdoInferior", 10000, 21000);
            Transformacion rotarBrazoIzquierdoInferior2 = new Transformacion("Rotacion", new Punto3D(45, 0, 0), 10000);
            Transformacion moverBrazoIzquierdoInferior2 = new Transformacion("Traslacion", new Punto3D(0, -0.05f, -0.05f), 10000);
            BrazoIzquierdoInferior2.AgregarTransformacion(moverBrazoIzquierdoInferior2);
            BrazoIzquierdoInferior2.AgregarTransformacion(rotarBrazoIzquierdoInferior2);

            Accion BrazoDerechoSuperior2 = new Accion("BrazoDerechoSuperior", 10000, 21000);
            Transformacion rotarBrazoDerechoSuperior2 = new Transformacion("Rotacion", new Punto3D(-50.0f, 0, 0), 10000);
            Transformacion moverBrazoDerechoSuperior2 = new Transformacion("Traslacion", new Punto3D(0, -0.09f, 0.6f), 10000);
            BrazoDerechoSuperior2.AgregarTransformacion(rotarBrazoDerechoSuperior2);
            BrazoDerechoSuperior2.AgregarTransformacion(moverBrazoDerechoSuperior2);                       

            Accion BrazoDerechoInferior2 = new Accion("BrazoDerechoInferior", 10000, 21000);
            Transformacion rotarBrazoDerechoInferior2 = new Transformacion("Rotacion", new Punto3D(-50.0f, 0, 0), 10000);
            Transformacion moverBrazoDerechoInferior2 = new Transformacion("Traslacion", new Punto3D(0, -0.1f, 1.13f), 10000);
            BrazoDerechoInferior2.AgregarTransformacion(moverBrazoDerechoInferior2);
            BrazoDerechoInferior2.AgregarTransformacion(rotarBrazoDerechoInferior2);

            Accion PiernaIzquierdaSuperior3 = new Accion("PiernaIzquierdaSuperior", 10000, 21000);
            Transformacion rotarPiernaIzquierdaSuperior3 = new Transformacion("Rotacion", new Punto3D(20, 0, 0), 10000); 
            Transformacion moverPiernaIzquierdaSuperior3 = new Transformacion("Traslacion", new Punto3D(0, -0.05f, 0.40f), 10000); 
            Transformacion moverPiernaIzquierdaSuperior33 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, -0.1f), 10000); 
            PiernaIzquierdaSuperior3.AgregarTransformacion(rotarPiernaIzquierdaSuperior3);
            PiernaIzquierdaSuperior3.AgregarTransformacion(moverPiernaIzquierdaSuperior3);
            PiernaIzquierdaSuperior3.AgregarTransformacion(moverPiernaIzquierdaSuperior33);

            Accion PiernaIzquierdaInferior3 = new Accion("PiernaIzquierdaInferior", 10000, 21000);
            Transformacion rotarPiernaIzquierdaInferior3 = new Transformacion("Rotacion", new Punto3D(20, 0, 0), 10000);
            Transformacion moverPiernaIzquierdaInferior3 = new Transformacion("Traslacion", new Punto3D(0, -0.05f, 0.2f), 10000); 
            Transformacion moverPiernaIzquierdaInferior33 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, -0.1f), 10000); 
            PiernaIzquierdaInferior3.AgregarTransformacion(rotarPiernaIzquierdaInferior3);
            PiernaIzquierdaInferior3.AgregarTransformacion(moverPiernaIzquierdaInferior3);
            PiernaIzquierdaInferior3.AgregarTransformacion(moverPiernaIzquierdaInferior33);

            Accion accionarPiernaDerechaSuperior3 = new Accion("PiernaDerechaSuperior", 10000, 21000);
            Transformacion rotarPiernaDerechaSuperior3 = new Transformacion("Rotacion", new Punto3D(3.5f, 0, 0), 10000);
            Transformacion moverPiernaDerechaSuperior3 = new Transformacion("Traslacion", new Punto3D(0, 0.05f, 0.6f), 10000);
            Transformacion moverPiernaDerechaSuperior33 = new Transformacion("Traslacion", new Punto3D(0, 0.12f, -0.22f), 10000);            
            accionarPiernaDerechaSuperior3.AgregarTransformacion(rotarPiernaDerechaSuperior3);
            accionarPiernaDerechaSuperior3.AgregarTransformacion(moverPiernaDerechaSuperior3);
            accionarPiernaDerechaSuperior3.AgregarTransformacion(moverPiernaDerechaSuperior33);

            Accion accionarPiernaDerechaInferior4 = new Accion("PiernaDerechaInferior", 10000, 21000);
            Transformacion rotarPiernaDerechaInferior4 = new Transformacion("Rotacion", new Punto3D(4, 0, 0), 10000);
            Transformacion moverPiernaDerechaInferior4 = new Transformacion("Traslacion", new Punto3D(0, 0.05f, 0.6f), 10000);
            Transformacion moverPiernaDerechaInferior44 = new Transformacion("Traslacion", new Punto3D(0, 0.05f, -0.15f), 10000);
            accionarPiernaDerechaInferior4.AgregarTransformacion(rotarPiernaDerechaInferior4);
            accionarPiernaDerechaInferior4.AgregarTransformacion(moverPiernaDerechaInferior4);
            accionarPiernaDerechaInferior4.AgregarTransformacion(moverPiernaDerechaInferior44);


            //SALTO///
            Accion BrazoIzquierdoSuperior3 = new Accion("BrazoIzquierdoSuperior", 1000, 33000);
            Transformacion rotarBrazoIzquierdoSuperior3 = new Transformacion("Rotacion", new Punto3D(-30, 0, 0), 1000);
            BrazoIzquierdoSuperior3.AgregarTransformacion(rotarBrazoIzquierdoSuperior3);

            Accion BrazoIzquierdoInferior3 = new Accion("BrazoIzquierdoInferior", 1000, 33000);
            Transformacion rotarBrazoIzquierdoInferior3 = new Transformacion("Rotacion", new Punto3D(-25f, 0, 0), 1000);
            BrazoIzquierdoInferior3.AgregarTransformacion(rotarBrazoIzquierdoInferior3);

            Accion BrazoDerechoSuperior3 = new Accion("BrazoDerechoSuperior", 1000, 33000);
            Transformacion rotarBrazoDerechoSuperior3 = new Transformacion("Rotacion", new Punto3D(36.0f, 0, 0), 1000);
            BrazoDerechoSuperior3.AgregarTransformacion(rotarBrazoDerechoSuperior3);

            Accion BrazoDerechoInferior3 = new Accion("BrazoDerechoInferior", 1000, 33000);
            Transformacion rotarBrazoDerechoInferior3 = new Transformacion("Rotacion", new Punto3D(36.0f, 0, 0), 1000);
            Transformacion moverBrazoDerechoInferior3 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, -0.1f), 10000);
            BrazoDerechoInferior3.AgregarTransformacion(rotarBrazoDerechoInferior3);
            BrazoDerechoInferior3.AgregarTransformacion(moverBrazoDerechoInferior3);


            Accion salto = new Accion("Robot", 10000, 35000);
            Transformacion salto1 = new Transformacion("Traslacion", new Punto3D(0.0f, 3.5f, 3f), 10000);
            Transformacion bajo = new Transformacion("Traslacion", new Punto3D(0.0f, -0.3f, 0), 10000);
            salto.AgregarTransformacion(salto1);
            salto.AgregarTransformacion(bajo);

            Accion BrazoIzquierdoInferior4 = new Accion("BrazoIzquierdoInferior", 1000, 46000);
            Transformacion moverBrazoIzquierdoInferior4 = new Transformacion("Traslacion", new Punto3D(0.0f, 0.2f, 0), 1000);
            BrazoIzquierdoInferior4.AgregarTransformacion(moverBrazoIzquierdoInferior4);

            Accion BrazoDerechoInferior4 = new Accion("BrazoDerechoInferior", 1000, 46000);
            Transformacion moverBrazoDerechoInferior4 = new Transformacion("Traslacion", new Punto3D(0.0f, -0.35f, -0.03f), 1000);
            BrazoDerechoInferior4.AgregarTransformacion(moverBrazoDerechoInferior4);

            //Patea
            Accion accionarPiernaDerechaSuperior4 = new Accion("PiernaDerechaSuperior", 5000, 45000);
            Transformacion rotarPiernaDerechaSuperior4 = new Transformacion("Rotacion", new Punto3D(-20, 0, 0), 5000); // Mover hacia adelante
            Transformacion moverPiernaDerechaSuperior4 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, 0.1f), 5000); // Mover hacia adelante
            accionarPiernaDerechaSuperior4.AgregarTransformacion(rotarPiernaDerechaSuperior4);
            accionarPiernaDerechaSuperior4.AgregarTransformacion(moverPiernaDerechaSuperior4);


            Accion accionarPiernaDerechaInferior5 = new Accion("PiernaDerechaInferior", 5000, 45000);
            Transformacion rotarPiernaDerechaInferior5 = new Transformacion("Rotacion", new Punto3D(-20, 0, 0), 5000); // Mover hacia adelante
            Transformacion moverPiernaDerechaInferior5 = new Transformacion("Traslacion", new Punto3D(0, 0.0f, 0.3f), 5000); // Mover hacia adelante

            accionarPiernaDerechaInferior5.AgregarTransformacion(rotarPiernaDerechaInferior5);
            accionarPiernaDerechaInferior5.AgregarTransformacion(moverPiernaDerechaInferior5);

            Accion pelota = new Accion("Pelota", 20000, 50000);
            Transformacion rotarpelota = new Transformacion("Rotacion", new Punto3D(90, 90, 90), 20000); // Mover hacia adelante
            Transformacion moverpelota = new Transformacion("Traslacion", new Punto3D(0.0f, 5.0f, 5.0f), 20000);
            pelota.AgregarTransformacion(rotarpelota);
            pelota.AgregarTransformacion(moverpelota);
            
            


            Escena escenaCaminar = new Escena();
            escenaCaminar.AgregarAccion(girarRobot);

            ///PASO 1
            escenaCaminar.AgregarAccion(accionarPiernaDerechaSuperior);
            escenaCaminar.AgregarAccion(accionarPiernaDerechaInferior);

            
            escenaCaminar.AgregarAccion(accionarPiernaDerechaInferior2);
            escenaCaminar.AgregarAccion(BrazoIzquierdoSuperior0);
            escenaCaminar.AgregarAccion(BrazoIzquierdoInferior0);
            escenaCaminar.AgregarAccion(BrazoDerechoSuperior0);
            escenaCaminar.AgregarAccion(BrazoDerechoInferior0);

            
            escenaCaminar.AgregarAccion(accionarPiernaDerechaSuperior2);
            escenaCaminar.AgregarAccion(accionarPiernaDerechaInferior3);
            escenaCaminar.AgregarAccion(torso);
            escenaCaminar.AgregarAccion(cabeza);
            escenaCaminar.AgregarAccion(BrazoIzquierdoSuperior);
            escenaCaminar.AgregarAccion(BrazoIzquierdoInferior);
            escenaCaminar.AgregarAccion(BrazoDerechoSuperior);
            escenaCaminar.AgregarAccion(BrazoDerechoInferior);
            escenaCaminar.AgregarAccion(PiernaIzquierdaSuperior);
            escenaCaminar.AgregarAccion(PiernaIzquierdaInferior);
            
            ///PASO 2
            escenaCaminar.AgregarAccion(PiernaIzquierdaSuperior2);
            escenaCaminar.AgregarAccion(PiernaIzquierdaInferior2);
            escenaCaminar.AgregarAccion(torso2);
            escenaCaminar.AgregarAccion(cabeza2);
            escenaCaminar.AgregarAccion(BrazoDerechoSuperior2);
            escenaCaminar.AgregarAccion(BrazoDerechoInferior2);
            escenaCaminar.AgregarAccion(BrazoIzquierdoSuperior2);
            escenaCaminar.AgregarAccion(BrazoIzquierdoInferior2);          
            escenaCaminar.AgregarAccion(PiernaIzquierdaSuperior3);
            escenaCaminar.AgregarAccion(PiernaIzquierdaInferior3);
            
            escenaCaminar.AgregarAccion(accionarPiernaDerechaSuperior3);
            escenaCaminar.AgregarAccion(accionarPiernaDerechaInferior4);


            //SALTO
            escenaCaminar.AgregarAccion(BrazoDerechoSuperior3);
            escenaCaminar.AgregarAccion(BrazoDerechoInferior3);
            escenaCaminar.AgregarAccion(BrazoIzquierdoSuperior3);
            escenaCaminar.AgregarAccion(BrazoIzquierdoInferior3);
            escenaCaminar.AgregarAccion(salto);

            escenaCaminar.AgregarAccion(BrazoIzquierdoInferior4);
            escenaCaminar.AgregarAccion(BrazoDerechoInferior4);

            escenaCaminar.AgregarAccion(accionarPiernaDerechaSuperior4);
            escenaCaminar.AgregarAccion(accionarPiernaDerechaInferior5);
            //PATEA
            escenaCaminar.AgregarAccion(pelota);
            Console.WriteLine("escenaCaminar" + escenaCaminar.TiempoTotal);
            
            */
            // Agregar la escena al libreto
            libreto = new Libreto();
            //libreto.AgregarEscena(escenaCaminar);
        }

        private void GlControlRender(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            shader.Use();
            shader.SetMatrix4("view", camara.GetViewMatrix());
            shader.SetMatrix4("projection", projection);

            escenario.Dibujar(shader);

            lienzoControl.SwapBuffers();
        }

        private void GlControlResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, lienzoControl.Width, lienzoControl.Height);
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lienzoControl.Invalidate(); // Forzar repaint
        }

        private Matrix4 ConfigurarMatrizProyeccion()
        {
            float width = (float)lienzoControl.Width;
            float height = (float)lienzoControl.Height;
            float aspectRatio = width / (float)height;
            const float fov = MathHelper.PiOver4;
            const float nearClip = 0.1f;
            const float farClip = 1000.0f;

            return Matrix4.CreatePerspectiveFieldOfView(fov, (float)width / (float)height, nearClip, farClip);
        }

        private void GlControlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }

        private void GlControlMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void GlControlMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                float deltaX = (e.X - lastMousePosition.X);
                float deltaY = (e.Y - lastMousePosition.Y);

                camara.ProcessMouseMovement(deltaX, deltaY);

                lastMousePosition = e.Location;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            camara.ProcessKeyboard(e.KeyCode);
        }


        private void lienzoControl_Enter(object sender, EventArgs e)
        {
            lienzoControl.Focus();
        }

        

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Escenario";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    Serializable.Serialize(escenario, rutaArchivo);
                    MessageBox.Show("Escenario guardado exitosamente.");
                }
            }
        }        

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            if (filePath != null)
            {
                escenario = Serializable.Deserialize(filePath);
                CargarTreeViewConEscenario(escenario);
                lienzoControl.Invalidate();                
            }

        }

        private void CargarTreeViewConEscenario(Escenario escenario)
        {
            treeView1.Nodes.Clear();
            TreeNode nodoEscenario = new TreeNode("Escenario") { Tag = escenario };
            foreach (var kvpObjeto in escenario.objetos)
            {
                string nombreObjeto = kvpObjeto.Key;
                Objeto objeto = kvpObjeto.Value;
                objeto.Escenario = escenario;
                TreeNode nodoObjeto = new TreeNode(nombreObjeto) { Tag = objeto };
                foreach (var kvpParte in kvpObjeto.Value.partes)
                {
                    string nombreParte = kvpParte.Key;
                    Parte parte = kvpParte.Value;
                    parte.ObjetoPadre = objeto;
                    TreeNode nodoParte = new TreeNode(nombreParte) { Tag = parte };
                    nodoObjeto.Nodes.Add(nodoParte);
                }
                nodoEscenario.Nodes.Add(nodoObjeto);
            }
            treeView1.Nodes.Add(nodoEscenario);
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode nodoSeleccionado = e.Node;
            if (nodoSeleccionado.Level == 0) 
            {
                string nombreEscenario = nodoSeleccionado.Text;
            }
            else if (nodoSeleccionado.Level == 1) 
            {
                string nombreObjeto = nodoSeleccionado.Text;
            }
            else if (nodoSeleccionado.Level == 2) 
            {
                string nombreObjeto = nodoSeleccionado.Parent.Text;
                string nombreParte = nodoSeleccionado.Text;
            }
        }

       
        private void rotar_Click(object sender, EventArgs e)
        {
            float rotationX = (float)x.Value;
            float rotationY = (float)y.Value;
            float rotationZ = (float)z.Value;

            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            if (nodoSeleccionado != null)
            {
                if (nodoSeleccionado.Tag is Escenario escenario)
                {
                    escenario.Rotate(rotationX, rotationY, rotationZ);
                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    objeto.Rotate(objeto.Escenario.Centro, rotationX, rotationY, rotationZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    parte.Rotate(parte.Centro + parte.ObjetoPadre.Centro, rotationX, rotationY, rotationZ);
                }                
                lienzoControl.Invalidate();
            }
            else
            {
                Console.WriteLine("No se ha seleccionado ningún nodo en el TreeView.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float translationX = (float)x.Value;
            float translationY = (float)y.Value;
            float translationZ = (float)z.Value;

            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            if (nodoSeleccionado != null)
            {
                if (nodoSeleccionado.Tag is Escenario escenario)
                {
                    escenario.Trasladar(translationX, translationY, translationZ);

                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    objeto.Trasladar( translationX, translationY, translationZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    parte.Trasladar(translationX, translationY, translationZ);
                }                
                lienzoControl.Invalidate();
            }
            else
            {
                Console.WriteLine("No se ha seleccionado ningún nodo en el TreeView.");
            }
        }

        private void escalar_Click(object sender, EventArgs e)
        {
            float scaleX = (float)x.Value;
            float scaleY = (float)y.Value;
            float scaleZ = (float)z.Value;

            TreeNode nodoSeleccionado = treeView1.SelectedNode;

            if (nodoSeleccionado != null)
            {
                if (nodoSeleccionado.Tag is Escenario escenario)
                {
                    escenario.Escalar(scaleX, scaleY, scaleZ);

                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    objeto.Escalar(scaleX, scaleY, scaleZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    parte.Escalar(scaleX, scaleY, scaleZ);
                }
                else
                lienzoControl.Invalidate();
            }
            else
            {
                Console.WriteLine("No se ha seleccionado ningún nodo en el TreeView.");
            }
        }

        private void reiniciar_Click(object sender, EventArgs e)
        {
            x.Value = 1.0m;
            y.Value = 1.0m;
            z.Value = 1.0m;
            libreto.tiempoAcumulado = libreto.tiempoTotal;
            escenario.ReiniciarTransformaciones();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (escenario.objetos == null || !escenario.objetos.Any())
            {
                MessageBox.Show("No tienes un escenario cargado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (libreto.Escenas == null || !libreto.Escenas.Any())
            {
                MessageBox.Show("No tienes un libreto cargado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            reiniciar_Click(sender, e);
            pausaEvento.Set();
            libreto.Reiniciar();
            
            double time = 0;
            Task.Run(() =>
            {               
                while (!libreto.IsCompleto())
                {
                    pausaEvento.WaitOne();
                    libreto.EjecutarEscena(escenario, ref time);
                    Thread.Sleep(10); 
                    time += 10;
                }
                Console.WriteLine("Animación completada.");
            });
        }

        private void pausar_Click(object sender, EventArgs e)
        {
            if (pausaEvento.WaitOne(0)) 
            {
                pausaEvento.Reset();

            }
            else
            {
                pausaEvento.Set();
            }
        }


        private void cargarAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            if (filePath != null)
            {
                libreto = Serializable.DeserializeA(filePath);
                libreto.tiempoTotal = 0;

                foreach (var escena in libreto.Escenas)
                {
                    escena.TiempoTotal = 0; 
                    foreach (var accion in escena.Acciones)
                    {
                        escena.TiempoTotal += accion.Tiempo;
                    }
                    libreto.tiempoTotal += escena.TiempoTotal; 
                }
                lienzoControl.Invalidate();
            }
        }

        private void guardarAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.Title = "Guardar Escenario";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    Serializable.SerializeA(libreto, rutaArchivo);
                    MessageBox.Show("Escenario guardado exitosamente.");
                }
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void serializadorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
