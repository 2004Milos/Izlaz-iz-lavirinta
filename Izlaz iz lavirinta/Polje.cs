using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Izlaz_iz_lavirinta
{
    internal class Polje
    {
        StanjePolja stanje;
        Point Pozicija;
        public PictureBox pb;

        public Polje(Panel panel, int str, Point pozicija, StanjePolja stanje = StanjePolja.zid)
        {
            this.Pozicija = pozicija;
            this.stanje = stanje;

            pb = new PictureBox();

            Update(str);
            pb.Parent = panel;
            pb.BackColor = stanje == StanjePolja.zid ? Boje.boja_Zid : Boje.boja_Slobodno;
        }

        public void Update(int str)
        {
            pb.Width = str;
            pb.Height = str;
            pb.Location = new Point((str + 2) * Pozicija.X, (str + 2) * Pozicija.Y);
        }

    }
    public enum StanjePolja { zid, slobodno }
    public static class Boje
    {
        public static readonly Color boja_Slobodno = Color.White;
        public static readonly Color boja_Zid = Color.Gray;
    }
}
