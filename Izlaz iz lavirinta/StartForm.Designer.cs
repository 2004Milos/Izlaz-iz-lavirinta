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
            this.clear_btn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(143, 100);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(99, 63);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dijkstra_radio);
            this.groupBox2.Controls.Add(this.Astar_radio);
            this.groupBox2.Location = new System.Drawing.Point(14, 128);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(123, 104);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritam";
            // 
            // Dijkstra_radio
            // 
            this.Dijkstra_radio.AutoSize = true;
            this.Dijkstra_radio.Location = new System.Drawing.Point(7, 63);
            this.Dijkstra_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dijkstra_radio.Name = "Dijkstra_radio";
            this.Dijkstra_radio.Size = new System.Drawing.Size(80, 24);
            this.Dijkstra_radio.TabIndex = 1;
            this.Dijkstra_radio.Text = "Dijkstra";
            this.Dijkstra_radio.UseVisualStyleBackColor = true;
            // 
            // Astar_radio
            // 
            this.Astar_radio.AutoSize = true;
            this.Astar_radio.Checked = true;
            this.Astar_radio.Location = new System.Drawing.Point(7, 29);
            this.Astar_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Astar_radio.Name = "Astar_radio";
            this.Astar_radio.Size = new System.Drawing.Size(50, 24);
            this.Astar_radio.TabIndex = 0;
            this.Astar_radio.TabStop = true;
            this.Astar_radio.Text = "A *";
            this.Astar_radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pravca8);
            this.groupBox1.Controls.Add(this.pravca4);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(123, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kretanje";
            // 
            // pravca8
            // 
            this.pravca8.AutoSize = true;
            this.pravca8.Location = new System.Drawing.Point(7, 63);
            this.pravca8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pravca8.Name = "pravca8";
            this.pravca8.Size = new System.Drawing.Size(100, 24);
            this.pravca8.TabIndex = 1;
            this.pravca8.Text = "U 8 pravca";
            this.pravca8.UseVisualStyleBackColor = true;
            // 
            // pravca4
            // 
            this.pravca4.AutoSize = true;
            this.pravca4.Checked = true;
            this.pravca4.Location = new System.Drawing.Point(7, 29);
            this.pravca4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pravca4.Name = "pravca4";
            this.pravca4.Size = new System.Drawing.Size(100, 24);
            this.pravca4.TabIndex = 0;
            this.pravca4.TabStop = true;
            this.pravca4.Text = "U 4 pravca";
            this.pravca4.UseVisualStyleBackColor = true;
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clear_btn.Location = new System.Drawing.Point(143, 229);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(99, 63);
            this.clear_btn.TabIndex = 7;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 249);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Sve zauzeto";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 305);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartForm";
            this.Text = "Start";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Dijkstra_radio;
        private System.Windows.Forms.RadioButton Astar_radio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton pravca8;
        private System.Windows.Forms.RadioButton pravca4;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}