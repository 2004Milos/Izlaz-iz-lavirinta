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
            this.pretraga_GB = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BestFS_radio = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pretraga_GB.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(8, 164);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(352, 80);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BestFS_radio);
            this.groupBox2.Controls.Add(this.dfs_radio);
            this.groupBox2.Controls.Add(this.bfs_radio);
            this.groupBox2.Controls.Add(this.Dijkstra_radio);
            this.groupBox2.Controls.Add(this.Astar_radio);
            this.groupBox2.Location = new System.Drawing.Point(186, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(173, 127);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritam";
            // 
            // dfs_radio
            // 
            this.dfs_radio.AutoSize = true;
            this.dfs_radio.Checked = true;
            this.dfs_radio.Location = new System.Drawing.Point(6, 28);
            this.dfs_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dfs_radio.Name = "dfs_radio";
            this.dfs_radio.Size = new System.Drawing.Size(56, 24);
            this.dfs_radio.TabIndex = 3;
            this.dfs_radio.TabStop = true;
            this.dfs_radio.Text = "DFS";
            this.dfs_radio.UseVisualStyleBackColor = true;
            // 
            // bfs_radio
            // 
            this.bfs_radio.AutoSize = true;
            this.bfs_radio.Location = new System.Drawing.Point(6, 62);
            this.bfs_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bfs_radio.Name = "bfs_radio";
            this.bfs_radio.Size = new System.Drawing.Size(54, 24);
            this.bfs_radio.TabIndex = 2;
            this.bfs_radio.Text = "BFS";
            this.bfs_radio.UseVisualStyleBackColor = true;
            // 
            // Dijkstra_radio
            // 
            this.Dijkstra_radio.AutoSize = true;
            this.Dijkstra_radio.Location = new System.Drawing.Point(87, 29);
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
            this.Astar_radio.Location = new System.Drawing.Point(87, 93);
            this.Astar_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Astar_radio.Name = "Astar_radio";
            this.Astar_radio.Size = new System.Drawing.Size(50, 24);
            this.Astar_radio.TabIndex = 0;
            this.Astar_radio.Text = "A *";
            this.Astar_radio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pravca8);
            this.groupBox1.Controls.Add(this.pravca4);
            this.groupBox1.Location = new System.Drawing.Point(8, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(173, 127);
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
            this.clear_btn.Location = new System.Drawing.Point(202, 29);
            this.clear_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(157, 61);
            this.clear_btn.TabIndex = 7;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(188, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Prepreke na svako polje";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pretraga_GB
            // 
            this.pretraga_GB.Controls.Add(this.groupBox1);
            this.pretraga_GB.Controls.Add(this.groupBox2);
            this.pretraga_GB.Controls.Add(this.Start);
            this.pretraga_GB.Location = new System.Drawing.Point(14, 13);
            this.pretraga_GB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pretraga_GB.Name = "pretraga_GB";
            this.pretraga_GB.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pretraga_GB.Size = new System.Drawing.Size(373, 254);
            this.pretraga_GB.TabIndex = 9;
            this.pretraga_GB.TabStop = false;
            this.pretraga_GB.Text = "Pretraga";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.clear_btn);
            this.groupBox4.Location = new System.Drawing.Point(14, 275);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(375, 105);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Brisanje";
            // 
            // BestFS_radio
            // 
            this.BestFS_radio.AutoSize = true;
            this.BestFS_radio.Location = new System.Drawing.Point(87, 61);
            this.BestFS_radio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BestFS_radio.Name = "BestFS_radio";
            this.BestFS_radio.Size = new System.Drawing.Size(77, 24);
            this.BestFS_radio.TabIndex = 4;
            this.BestFS_radio.Text = "Best FS";
            this.BestFS_radio.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 389);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pretraga_GB);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartForm";
            this.Text = "Start";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pretraga_GB.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox pretraga_GB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton BestFS_radio;
    }
}