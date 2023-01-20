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
        static int minstranica = 13;

        public Lavirint(int FormWidth, int FormHeight, Panel panel, Tuple<int,int> dimenzije)
        {
            Dimenzije = dimenzije; 
            this.panel = panel;
            stranicaPolja = FormWidth / dimenzije.Item1;

            polja = new Polje[Dimenzije.Item2, Dimenzije.Item1];

            for (int i = 0; i < dimenzije.Item2; i++)
            {
                for (int j = 0; j < dimenzije.Item1; j++)
                {
                    polja[i, j] = new Polje(panel,stranicaPolja,new Point(j,i));
                }
            }
            Update(FormWidth, FormHeight);
        }

        public void Update(int FormWidth, int FormHeight)
        {
            stranicaPolja = FormWidth / Dimenzije.Item1;
            if (stranicaPolja * Dimenzije.Item2 > 550)
                stranicaPolja = FormHeight / Dimenzije.Item2;
            if (stranicaPolja < minstranica) stranicaPolja = minstranica;

            for (int i = 0; i < Dimenzije.Item2; i++)
            {
                for (int j = 0; j < Dimenzije.Item1; j++)
                {
                    polja[i, j].Update(stranicaPolja);
                }
            }

        }
    }
}
