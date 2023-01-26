using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    public partial class MainForm : Form
    {
        private Tuple<int, int> dimenzije;
        public Lavirint lavirint;
        Graphics g;

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
            g = CreateGraphics();
            InputForm inputForm = new InputForm();
            this.Hide();
            DialogResult dr = inputForm.ShowDialog();
            if (dimenzije == null)
            {
                Environment.Exit(0);
                return;
            }
            this.Show();
            inputForm.Close();
            lavirint = new Lavirint(this.ClientSize.Width, ClientSize.Height, dimenzije);

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            lavirint.Crtaj(g);
        }


        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = lavirint.Polje_by_XY(e.X, e.Y);
            lavirint.polja[pt.Y,pt.X].Click(g, 0);
        }


        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point pt = lavirint.Polje_by_XY(e.X,e.Y);
            if (e.Button == MouseButtons.Left)
                lavirint.SetStartFinish(g, pt.X, pt.Y, true);
            else
                lavirint.SetStartFinish(g, pt.X, pt.Y, false);

        }
    }
}
