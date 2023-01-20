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
        Lavirint lavirint;

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
            panel1.Location = new Point(0, 30);
            lavirint = new Lavirint(Width,Height, panel1, dimenzije);

        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            lavirint.Update(Width,Height);
        }
    }
}
