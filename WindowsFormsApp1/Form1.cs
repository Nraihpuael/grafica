﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WindowsFormsApp1.Objetos;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        GLControl lienzoControl;
        private Vector3 Posicion;
        private Vector3 Objetivo;
        private Vector3 Arriba;
        private Matrix4 view;
        private Matrix4 projection;

        Timer timer;

        Shader shader;
        T t = new T();
        private float rotationAngle = 0.0f;

        private bool isDragging = false;
        private Point lastMousePosition;
        private float speed = 1.5f;

        public Form1()
        {
            InitializeComponent();
            lienzoControl = new GLControl(new GraphicsMode(32, 24, 0, 4));
            timer = new Timer { Interval = 16 };
            timer.Tick += Timer_Tick;
            timer.Start();
            this.Focus();

            this.KeyPreview = true; // Habilitar la vista previa de teclas en el formulario
            lienzoControl.Focus(); // Establecer el foco en el control GLControl

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lienzoControl = new GLControl
            {
                BackColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(350, 37),
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
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            Posicion = new Vector3(0.0f, 0.0f, 3.0f);
            Objetivo = new Vector3(0.0f, 0.0f, -1.0f);
            Arriba = new Vector3(0.0f, 1.0f, 0.0f);

            shader = new Shader("../../shaders/shader.vert", "../../shaders/shader.frag");           

            view = Matrix4.LookAt(Posicion, Posicion + Objetivo, Arriba);
            projection = ConfigurarMatrizProyeccion();

        }

        private void GlControlRender(object sender, PaintEventArgs e)
        {
            Vector3 centroDeMasa = new Vector3(0.1f, 0.5f, 0.7f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            shader.Use();
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projection);
            Matrix4 model;
            model = Matrix4.CreateTranslation(-centroDeMasa);
            model *= Matrix4.CreateRotationX(rotationAngle); // Rotate around Z-axis
            model *= Matrix4.CreateTranslation(centroDeMasa);

            shader.SetMatrix4("model", model);            

            t.Dibujar(centroDeMasa);


            lienzoControl.SwapBuffers();
        }

        private void GlControlResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, lienzoControl.Width, lienzoControl.Height);
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rotationAngle += 0.02f; 
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
                float sensitivity = 0.002f; // Sensibilidad del mouse
                float deltaX = (e.X - lastMousePosition.X) * sensitivity;
                float deltaY = (e.Y - lastMousePosition.Y) * sensitivity;

                // Calcular la nueva dirección del objetivo
                Vector3 right = Vector3.Normalize(Vector3.Cross(Objetivo, Arriba));
                Objetivo = Vector3.Transform(Objetivo, Matrix3.CreateFromAxisAngle(Arriba, -deltaX));
                Objetivo = Vector3.Transform(Objetivo, Matrix3.CreateFromAxisAngle(right, deltaY));

                // Actualizar la vista
                view = Matrix4.LookAt(Posicion, Posicion + Objetivo, Arriba);

                // Guardar la posición actual del mouse
                lastMousePosition = e.Location;

                // Redibujar el control
                lienzoControl.Invalidate();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(" ho");
            switch (e.KeyCode)
            {
                case Keys.W:
                    Console.WriteLine(" hola");
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
            view = Matrix4.LookAt(Posicion, Posicion + Objetivo, Arriba);
        }

        private void lienzoControl_Enter(object sender, EventArgs e)
        {
            lienzoControl.Focus();
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

        

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

       
        

    }
}
