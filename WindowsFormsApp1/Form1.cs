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
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
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
        Timer timer;
        Shader shader;

        private float rotationAngle = 2.0f;
        private bool isDragging = false;
        private Point lastMousePosition;

        public Form1()
        {
            InitializeComponent();

            lienzoControl = new GLControl(new GraphicsMode(32, 24, 0, 4));
            timer = new Timer { Interval = 16 };
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
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            camara = new Camara(
             new Vector3(0.0f, 0.0f, 3.0f),
             new Vector3(0.0f, 0.0f, -1.0f),
             new Vector3(0.0f, 1.0f, 0.0f)
            );

            shader = new Shader("../../shaders/shader.vert", "../../shaders/shader.frag");           

            projection = ConfigurarMatrizProyeccion();
            escenario = new Escenario();
            //Objeto t = T.CrearT();
            //escenario.AgregarObjeto("T", t);
           

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
            rotationAngle += 0.01f; 
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
                    //Serializable.ConvertirDesdeEscenario(escenario);
                    //Serializable.SerializarEscenario(rutaArchivo);                    
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
                //Serializable serializable = Serializable.DeserializeEscenario(filePath);
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
            if (nodoSeleccionado.Level == 0) // Si es un nodo del escenario
            {
                string nombreEscenario = nodoSeleccionado.Text;
                Console.WriteLine($"Escenario seleccionado: {nombreEscenario}");

            }
            else if (nodoSeleccionado.Level == 1) // Si es un nodo de objeto
            {
                string nombreObjeto = nodoSeleccionado.Text;
                Console.WriteLine($"Objeto seleccionado: {nombreObjeto}");
            }
            else if (nodoSeleccionado.Level == 2) // Si es un nodo de parte
            {
                string nombreObjeto = nodoSeleccionado.Parent.Text;
                string nombreParte = nodoSeleccionado.Text;
                Console.WriteLine($"Objeto seleccionado: {nombreObjeto}, Parte seleccionada: {nombreParte}");
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
                    Console.WriteLine($"Escenario seleccionado: {escenario}");
                    escenario.Rotate(rotationX, rotationY, rotationZ);
                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    Console.WriteLine($"Escenario seleccionado: {objeto}");
                    objeto.Rotate(objeto.Escenario.Centro, rotationX, rotationY, rotationZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    Console.WriteLine($"Escenario seleccionado: {parte}");
                    parte.Rotate(parte.ObjetoPadre.Centro, rotationX, rotationY, rotationZ);
                }
                else
                {
                    Console.WriteLine("Tipo de etiqueta no soportado.");
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
                    Console.WriteLine($"Escenario seleccionado: {escenario}");
                    escenario.Trasladar(translationX, translationY, translationZ);

                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    Console.WriteLine($"Escenario seleccionado: {objeto}");
                    objeto.Trasladar(objeto.Escenario.Centro, translationX, translationY, translationZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    Console.WriteLine($"Escenario seleccionado: {parte}");
                    parte.Trasladar(parte.ObjetoPadre.Centro, translationX, translationY, translationZ);
                }
                else
                {
                    Console.WriteLine("Tipo de etiqueta no soportado.");
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
                    Console.WriteLine($"Escenario seleccionado: {escenario}");
                    escenario.Escalar(scaleX, scaleY, scaleZ);

                }
                else if (nodoSeleccionado.Tag is Objeto objeto)
                {
                    Console.WriteLine($"Escenario seleccionado: {objeto}");
                    objeto.Escalar(scaleX, scaleY, scaleZ);
                }
                else if (nodoSeleccionado.Tag is Parte parte)
                {
                    Console.WriteLine($"Escenario seleccionado: {parte}");
                    parte.Escalar(scaleX, scaleY, scaleZ);
                }
                else
                {
                    Console.WriteLine("Tipo de etiqueta no soportado.");
                }

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

            escenario.ReiniciarTransformaciones();
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
