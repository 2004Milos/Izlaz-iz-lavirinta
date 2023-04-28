using System;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    public partial class StartForm : Form
    {
        MainForm mf;
        public StartForm(bool smeStart)
        {
            mf = ((MainForm)Application.OpenForms[0]);
            InitializeComponent();
            if (!smeStart) pretraga_GB.Enabled = false;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            mf.BringToFront();
            mf.lavirint.RemovePaths(mf.g);

            if (Astar_radio.Checked)
            {

                mf.lavirint.AStar(pravca4.Checked, mf.g);

            }
            else if (Dijkstra_radio.Checked)
            {
                mf.lavirint.Dijkstra(pravca4.Checked, mf.g);

            }
            else if (bfs_radio.Checked)
            {
                mf.lavirint.BFS(pravca4.Checked, mf.g);
            }
            else if(dfs_radio.Checked)
            {
                mf.lavirint.DFS(pravca4.Checked, mf.g);
            }
            else if (BestFS_radio.Checked)
            {
                mf.lavirint.BestFS(pravca4.Checked, mf.g);
            }


            this.Close();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            mf.lavirint.Clear(checkBox1.Checked, mf.g);
        }
    }
}
