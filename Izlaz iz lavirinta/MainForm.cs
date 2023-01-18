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
            InputForm inputForm = new InputForm();
            this.Hide();
            inputForm.ShowDialog();
            this.Show();
            inputForm.Close();

            int stranica_polja = (int) (this.Width * 0.9) / dimenzije.Item1;

            for (int i = 0; i < dimenzije.Item2; i++)
            {
                for (int j = 0; j < dimenzije.Item1; j++)
                {
                    PictureBox polje = new PictureBox();
                    polje.Parent = panel1;
                    polje.Width = stranica_polja;
                    polje.Height = stranica_polja;

                    polje.Location = new Point(i * (stranica_polja+2), j * (stranica_polja+2));

                    polje.BackColor = Color.Green;
                }
            }

        }
    }
}
