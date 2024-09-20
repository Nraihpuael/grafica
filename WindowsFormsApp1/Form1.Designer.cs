namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reiniciar = new System.Windows.Forms.Button();
            this.EjeZ = new System.Windows.Forms.Label();
            this.EjeY = new System.Windows.Forms.Label();
            this.EjeX = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.NumericUpDown();
            this.y = new System.Windows.Forms.NumericUpDown();
            this.x = new System.Windows.Forms.NumericUpDown();
            this.escalar = new System.Windows.Forms.Button();
            this.trasladar = new System.Windows.Forms.Button();
            this.rotar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serializadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 704);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reiniciar);
            this.groupBox1.Controls.Add(this.EjeZ);
            this.groupBox1.Controls.Add(this.EjeY);
            this.groupBox1.Controls.Add(this.EjeX);
            this.groupBox1.Controls.Add(this.z);
            this.groupBox1.Controls.Add(this.y);
            this.groupBox1.Controls.Add(this.x);
            this.groupBox1.Controls.Add(this.escalar);
            this.groupBox1.Controls.Add(this.trasladar);
            this.groupBox1.Controls.Add(this.rotar);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 543);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // reiniciar
            // 
            this.reiniciar.Location = new System.Drawing.Point(133, 384);
            this.reiniciar.Name = "reiniciar";
            this.reiniciar.Size = new System.Drawing.Size(75, 23);
            this.reiniciar.TabIndex = 10;
            this.reiniciar.Text = "Reiniciar";
            this.reiniciar.UseVisualStyleBackColor = true;
            this.reiniciar.Click += new System.EventHandler(this.reiniciar_Click);
            // 
            // EjeZ
            // 
            this.EjeZ.AutoSize = true;
            this.EjeZ.Location = new System.Drawing.Point(256, 267);
            this.EjeZ.Name = "EjeZ";
            this.EjeZ.Size = new System.Drawing.Size(29, 13);
            this.EjeZ.TabIndex = 9;
            this.EjeZ.Text = "EjeZ";
            // 
            // EjeY
            // 
            this.EjeY.AutoSize = true;
            this.EjeY.Location = new System.Drawing.Point(157, 267);
            this.EjeY.Name = "EjeY";
            this.EjeY.Size = new System.Drawing.Size(29, 13);
            this.EjeY.TabIndex = 8;
            this.EjeY.Text = "EjeY";
            // 
            // EjeX
            // 
            this.EjeX.AutoSize = true;
            this.EjeX.Location = new System.Drawing.Point(41, 267);
            this.EjeX.Name = "EjeX";
            this.EjeX.Size = new System.Drawing.Size(29, 13);
            this.EjeX.TabIndex = 7;
            this.EjeX.Text = "EjeX";
            this.EjeX.Click += new System.EventHandler(this.label1_Click);
            // 
            // z
            // 
            this.z.DecimalPlaces = 1;
            this.z.Location = new System.Drawing.Point(250, 283);
            this.z.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(49, 20);
            this.z.TabIndex = 6;
            // 
            // y
            // 
            this.y.DecimalPlaces = 1;
            this.y.Location = new System.Drawing.Point(149, 283);
            this.y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(49, 20);
            this.y.TabIndex = 5;
            // 
            // x
            // 
            this.x.DecimalPlaces = 1;
            this.x.Location = new System.Drawing.Point(35, 283);
            this.x.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(49, 20);
            this.x.TabIndex = 4;
            // 
            // escalar
            // 
            this.escalar.Location = new System.Drawing.Point(239, 213);
            this.escalar.Name = "escalar";
            this.escalar.Size = new System.Drawing.Size(75, 23);
            this.escalar.TabIndex = 3;
            this.escalar.Text = "Escalar";
            this.escalar.UseVisualStyleBackColor = true;
            this.escalar.Click += new System.EventHandler(this.escalar_Click);
            // 
            // trasladar
            // 
            this.trasladar.Location = new System.Drawing.Point(133, 213);
            this.trasladar.Name = "trasladar";
            this.trasladar.Size = new System.Drawing.Size(75, 23);
            this.trasladar.TabIndex = 2;
            this.trasladar.Text = "Trasladar";
            this.trasladar.UseVisualStyleBackColor = true;
            this.trasladar.Click += new System.EventHandler(this.button1_Click);
            // 
            // rotar
            // 
            this.rotar.Location = new System.Drawing.Point(23, 213);
            this.rotar.Name = "rotar";
            this.rotar.Size = new System.Drawing.Size(75, 23);
            this.rotar.TabIndex = 1;
            this.rotar.Text = "Rotar";
            this.rotar.UseVisualStyleBackColor = true;
            this.rotar.Click += new System.EventHandler(this.rotar_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(54, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(231, 174);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializadorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1359, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // serializadorToolStripMenuItem
            // 
            this.serializadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.serializadorToolStripMenuItem.Name = "serializadorToolStripMenuItem";
            this.serializadorToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.serializadorToolStripMenuItem.Text = "Serializador";
            this.serializadorToolStripMenuItem.Click += new System.EventHandler(this.serializadorToolStripMenuItem_Click);
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 665);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem serializadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Button rotar;
        private System.Windows.Forms.Button trasladar;
        private System.Windows.Forms.Button escalar;
        private System.Windows.Forms.NumericUpDown z;
        private System.Windows.Forms.NumericUpDown y;
        private System.Windows.Forms.NumericUpDown x;
        private System.Windows.Forms.Label EjeX;
        private System.Windows.Forms.Label EjeZ;
        private System.Windows.Forms.Label EjeY;
        private System.Windows.Forms.Button reiniciar;
    }
}

