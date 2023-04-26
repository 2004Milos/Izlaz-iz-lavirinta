using System;
using System.Drawing;
using System.Windows.Forms;


namespace Izlaz_iz_lavirinta
{
    public partial class MainForm : Form
    {
        private Tuple<int, int> dimenzije;
        public Lavirint lavirint;
        public Graphics g;
        bool crtaj = false;

        public Tuple<int, int> Dimenzije
        {
            get
            {
                return dimenzije;
            }
            set
            {
                if (value.Item1 > 50 || value.Item1 < 2 || value.Item2 > 50 || value.Item2 < 2)
                    throw new Exception("Dimaznzije lavirina moraju biti izmedju 2 i 50");
                dimenzije = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm())
            {
                this.Hide();
                DialogResult dr = inputForm.ShowDialog();
                if (dimenzije == null)
                {
                    Environment.Exit(0);
                    return;
                }
                this.Show();
                inputForm.Close();
            }

            g = CreateGraphics();
            lavirint = new Lavirint(this.ClientSize.Width, ClientSize.Height, dimenzije);
            crtaj = true;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (crtaj)
            {
                lavirint.Crtaj(g);
                crtaj = false;
            }
        }

        bool down = false;
        bool moving = false;
        Point prethodniPt = new Point(-5, -5);

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            moving = false;

        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                moving = true;
                Point pt = lavirint.Polje_by_XY(e.X, e.Y);
                if (prethodniPt.X != pt.X || prethodniPt.Y != pt.Y)
                {
                    lavirint.polja[pt.Y, pt.X].Click(g, 0, lavirint.sveZazeto_onStart);
                    prethodniPt = pt;
                }
            }

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (moving) return;

            Point pt = lavirint.Polje_by_XY(e.X, e.Y);
            lavirint.polja[pt.Y,pt.X].Click(g, 0, lavirint.sveZazeto_onStart);
        }


        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point pt = lavirint.Polje_by_XY(e.X,e.Y);
            if (e.Button == MouseButtons.Left)
                lavirint.SetStartFinish(g, pt.X, pt.Y, true);
            else
                lavirint.SetStartFinish(g, pt.X, pt.Y, false);

        }


        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (StartForm sf = new StartForm(lavirint.Start.X != -1 && lavirint.Finish.X != -1))
                {
                    sf.ShowDialog();
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            g.Clear(BackColor);
            g.Dispose();
            g = CreateGraphics();
            lavirint.Resize(ClientRectangle.Width, ClientRectangle.Height);
            crtaj = true;
            Refresh();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            g.Clear(BackColor);
            g.Dispose();
            g = CreateGraphics();
            lavirint.Resize(ClientRectangle.Width, ClientRectangle.Height);
            crtaj = true;
            Refresh();
        }
    }
}
