﻿using System;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    public partial class StartForm : Form
    {
        MainForm mf;
        public StartForm()
        {
            mf = ((MainForm)Application.OpenForms[0]);
            InitializeComponent();
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
            else
            {
                mf.lavirint.Dijkstra(pravca4.Checked, mf.g);

            }

            this.Close();
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            mf.lavirint.Clear(checkBox1.Checked, mf.g);
        }
    }
}
