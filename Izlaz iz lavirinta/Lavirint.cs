using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    internal class Lavirint
    {
        public Panel panel;
        public Polje[,] polja;
        public int stranicaPolja;
        public Tuple<int,int> Dimenzije; //U poljima

        public Lavirint(MainForm mf, Panel panel, Tuple<int,int> dimenzije)
        {
            Dimenzije = dimenzije; 
            this.panel = panel;
            stranicaPolja = mf.Width / dimenzije.Item1;
            if(stranicaPolja*Dimenzije.Item2 > 550)
                stranicaPolja = mf.Height / dimenzije.Item2;

            polja = new Polje[Dimenzije.Item2, Dimenzije.Item1];

            for (int i = 0; i < dimenzije.Item2; i++)
            {
                for (int j = 0; j < dimenzije.Item1; j++)
                {
                    polja[i, j] = new Polje(this,new Point(j,i));
                }
            }
            mf.Height = panel.Height+30;
            mf.Width = panel.Width;
        }
    }
}
