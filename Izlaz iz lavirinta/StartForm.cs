using System;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            ((MainForm)Application.OpenForms[0]).BringToFront();
            if (Astar_radio.Checked)
            {

                ((MainForm)Application.OpenForms[0]).lavirint.AStar(pravca4.Checked, ((MainForm)Application.OpenForms[0]).g);

            }
            else
            {
                //((MainForm)Application.OpenForms[0]).lavirin.Dijkstra(pravca4.Checked);
            }

            this.Close();
        }
    }
}
