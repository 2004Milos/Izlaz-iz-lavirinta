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
            this.PausePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PausePanel
            // 
            this.PausePanel.Location = new System.Drawing.Point(-8, -5);
            this.PausePanel.Name = "PausePanel";
            this.PausePanel.Size = new System.Drawing.Size(530, 429);
            this.PausePanel.TabIndex = 0;
            this.PausePanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 420);
            this.Controls.Add(this.PausePanel);
            this.Name = "MainForm";
            this.Text = "Ucrtajte slobodna polja u sledećem lavirintu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PausePanel;
    }
}

