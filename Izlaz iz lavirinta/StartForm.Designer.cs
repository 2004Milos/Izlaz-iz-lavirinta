namespace Izlaz_iz_lavirinta
{
    partial class StartForm
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
            this.Start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dijkstra_radio = new System.Windows.Forms.RadioButton();
            this.Astar_radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pravca8 = new System.Windows.Forms.RadioButton();
            this.pravca4 = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(126, 68);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(58, 60);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dijkstra_radio);
            this.groupBox2.Controls.Add(this.Astar_radio);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritam";
            // 
            // Dijkstra_radio
            // 
            this.Dijkstra_radio.AutoSize = true;
            this.Dijkstra_radio.Location = new System.Drawing.Point(6, 47);
            this.Dijkstra_radio.Name = "Dijkstra_radio";
            this.Dijkstra_radio.Size = new System.Drawing.Size(64, 19);
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
            this.Astar_radio.Size = new System.Drawing.Size(41, 19);
            this.Astar_radio.TabIndex = 0;
            this.Astar_radio.TabStop = true;
            this.Astar_radio.Text = "A *";
            this.Astar_radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pravca8);
            this.groupBox1.Controls.Add(this.pravca4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kretanje";
            // 
            // pravca8
            // 
            this.pravca8.AutoSize = true;
            this.pravca8.Location = new System.Drawing.Point(6, 47);
            this.pravca8.Name = "pravca8";
            this.pravca8.Size = new System.Drawing.Size(80, 19);
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
            this.pravca4.Size = new System.Drawing.Size(80, 19);
            this.pravca4.TabIndex = 0;
            this.pravca4.TabStop = true;
            this.pravca4.Text = "U 4 pravca";
            this.pravca4.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 186);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartForm";
            this.Text = "Start";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Dijkstra_radio;
        private System.Windows.Forms.RadioButton Astar_radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pravca8;
        private System.Windows.Forms.RadioButton pravca4;
    }
}