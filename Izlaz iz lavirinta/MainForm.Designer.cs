namespace Izlaz_iz_lavirinta
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.Move = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dijkstra_radio = new System.Windows.Forms.RadioButton();
            this.Astar_radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pravca8 = new System.Windows.Forms.RadioButton();
            this.pravca4 = new System.Windows.Forms.RadioButton();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Move)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.White;
            this.ControlPanel.Controls.Add(this.Move);
            this.ControlPanel.Controls.Add(this.Start);
            this.ControlPanel.Controls.Add(this.groupBox2);
            this.ControlPanel.Controls.Add(this.groupBox1);
            this.ControlPanel.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ControlPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ControlPanel.Location = new System.Drawing.Point(75, 50);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(181, 169);
            this.ControlPanel.TabIndex = 0;
            // 
            // Move
            // 
            this.Move.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Move.ErrorImage")));
            this.Move.Image = ((System.Drawing.Image)(resources.GetObject("Move.Image")));
            this.Move.Location = new System.Drawing.Point(145, 3);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(33, 31);
            this.Move.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Move.TabIndex = 1;
            this.Move.TabStop = false;
            this.Move.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            this.Move.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_MouseMove);
            this.Move.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_MouseUp);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(117, 59);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(58, 60);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dijkstra_radio);
            this.groupBox2.Controls.Add(this.Astar_radio);
            this.groupBox2.Location = new System.Drawing.Point(3, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritam";
            // 
            // Dijkstra_radio
            // 
            this.Dijkstra_radio.AutoSize = true;
            this.Dijkstra_radio.Location = new System.Drawing.Point(6, 47);
            this.Dijkstra_radio.Name = "Dijkstra_radio";
            this.Dijkstra_radio.Size = new System.Drawing.Size(78, 19);
            this.Dijkstra_radio.TabIndex = 1;
            this.Dijkstra_radio.Text = "Dijkstra";
            this.Dijkstra_radio.UseVisualStyleBackColor = true;
            // 
            // Astar_radio
            // 
            this.Astar_radio.AutoSize = true;
            this.Astar_radio.Checked = true;
            this.Astar_radio.Location = new System.Drawing.Point(6, 22);
            this.Astar_radio.Name = "Astar_radio";
            this.Astar_radio.Size = new System.Drawing.Size(46, 19);
            this.Astar_radio.TabIndex = 0;
            this.Astar_radio.TabStop = true;
            this.Astar_radio.Text = "A *";
            this.Astar_radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pravca8);
            this.groupBox1.Controls.Add(this.pravca4);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kretanje";
            // 
            // pravca8
            // 
            this.pravca8.AutoSize = true;
            this.pravca8.Location = new System.Drawing.Point(6, 47);
            this.pravca8.Name = "pravca8";
            this.pravca8.Size = new System.Drawing.Size(95, 19);
            this.pravca8.TabIndex = 1;
            this.pravca8.Text = "U 8 pravca";
            this.pravca8.UseVisualStyleBackColor = true;
            // 
            // pravca4
            // 
            this.pravca4.AutoSize = true;
            this.pravca4.Checked = true;
            this.pravca4.Location = new System.Drawing.Point(6, 22);
            this.pravca4.Name = "pravca4";
            this.pravca4.Size = new System.Drawing.Size(95, 19);
            this.pravca4.TabIndex = 0;
            this.pravca4.TabStop = true;
            this.pravca4.Text = "U 4 pravca";
            this.pravca4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 420);
            this.Controls.Add(this.ControlPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainForm";
            this.Text = "Ucrtajte slobodna polja u sledećem lavirintu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Move)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox Move;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Dijkstra_radio;
        private System.Windows.Forms.RadioButton Astar_radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pravca8;
        private System.Windows.Forms.RadioButton pravca4;
    }
}

