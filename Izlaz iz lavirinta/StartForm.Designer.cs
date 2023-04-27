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
            this.dfs_radio = new System.Windows.Forms.RadioButton();
            this.bfs_radio = new System.Windows.Forms.RadioButton();
            this.Dijkstra_radio = new System.Windows.Forms.RadioButton();
            this.Astar_radio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pravca8 = new System.Windows.Forms.RadioButton();
            this.pravca4 = new System.Windows.Forms.RadioButton();
            this.clear_btn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(6, 106);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(308, 60);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dfs_radio);
            this.groupBox2.Controls.Add(this.bfs_radio);
            this.groupBox2.Controls.Add(this.Dijkstra_radio);
            this.groupBox2.Controls.Add(this.Astar_radio);
            this.groupBox2.Location = new System.Drawing.Point(163, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritam";
            // 
            // dfs_radio
            // 
            this.dfs_radio.AutoSize = true;
            this.dfs_radio.Location = new System.Drawing.Point(75, 47);
            this.dfs_radio.Name = "dfs_radio";
            this.dfs_radio.Size = new System.Drawing.Size(45, 19);
            this.dfs_radio.TabIndex = 3;
            this.dfs_radio.Text = "DFS";
            this.dfs_radio.UseVisualStyleBackColor = true;
            // 
            // bfs_radio
            // 
            this.bfs_radio.AutoSize = true;
            this.bfs_radio.Location = new System.Drawing.Point(75, 22);
            this.bfs_radio.Name = "bfs_radio";
            this.bfs_radio.Size = new System.Drawing.Size(44, 19);
            this.bfs_radio.TabIndex = 2;
            this.bfs_radio.Text = "BFS";
            this.bfs_radio.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(7, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 78);
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
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clear_btn.Location = new System.Drawing.Point(163, 22);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(151, 46);
            this.clear_btn.TabIndex = 7;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 37);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Prepreke na svako polje";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.Start);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 177);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pretraga";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.clear_btn);
            this.groupBox4.Location = new System.Drawing.Point(12, 195);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 79);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Brisanje";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 284);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "StartForm";
            this.Text = "Start";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton dfs_radio;
        private System.Windows.Forms.RadioButton bfs_radio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}