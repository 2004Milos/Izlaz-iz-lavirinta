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

        public Polje(Lavirint roditeljskiLavirint, Point pozicija, StanjePolja stanje = StanjePolja.zid)
        {
            this.Pozicija = pozicija;
            this.stanje = stanje;

            pb = new PictureBox();
            pb.Width = roditeljskiLavirint.stranicaPolja;
            pb.Height = roditeljskiLavirint.stranicaPolja;
            pb.Parent = roditeljskiLavirint.panel;
            pb.Location = new Point((roditeljskiLavirint.stranicaPolja+2) * pozicija.X, (roditeljskiLavirint.stranicaPolja+2) * pozicija.Y);
            pb.BackColor = stanje == StanjePolja.zid ? Boje.boja_Zid : Boje.boja_Slobodno;
        }


    }
    public enum StanjePolja { zid, slobodno }
    public static class Boje
    {
        public static readonly Color boja_Slobodno = Color.White;
        public static readonly Color boja_Zid = Color.Gray;
    }
}
