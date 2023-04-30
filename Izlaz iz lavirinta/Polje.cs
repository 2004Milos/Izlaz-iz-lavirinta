using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Izlaz_iz_lavirinta
{
    public class Polje
    {
        public StanjePolja stanje;
        public Point Pozicija;
        public SolidBrush sb;
        
        public int stranica;
        public static int xstart, ystart;

        public double G, H;
        public Polje parent;


        public Polje(int str, Point pozicija, int xstart, int ystart, StanjePolja stanje = StanjePolja.zid)
        {
            this.Pozicija = pozicija;
            this.stanje = stanje;
            this.stranica = str;

            Polje.xstart = xstart;
            Polje.ystart = ystart;

            sb = new SolidBrush((stanje == StanjePolja.zid) ? Boje.boja_Zid : Boje.boja_Slobodno);
        }

        public void Crtaj(Graphics g)
        {
            g.FillRectangle(sb, xstart+Pozicija.X * (stranica + 2), ystart+Pozicija.Y * (stranica + 2), stranica, stranica);

            if (stanje == StanjePolja.start)
                using (Image startImage = Properties.Resources.start)
                {
                    g.DrawImage(startImage, xstart + Pozicija.X * (stranica + 2), ystart + Pozicija.Y * (stranica + 2), stranica, stranica);
                    G = 0;
                }
            else if (stanje == StanjePolja.cilj)
                using (Image finishImage = Properties.Resources.finish)
                {
                    g.DrawImage(finishImage, xstart + Pozicija.X * (stranica + 2), ystart + Pozicija.Y * (stranica + 2), stranica, stranica);
                }
        }

        public void Click(Graphics g, int StartOrCilj, bool sveZauzeto)
        {
            if (StartOrCilj == 0)
            {
                stanje = stanje == StanjePolja.slobodno ? StanjePolja.zid : StanjePolja.slobodno;
                sb = new SolidBrush((stanje == StanjePolja.slobodno) ? Boje.boja_Slobodno : Boje.boja_Zid);
            }
            else
            {
                sb = new SolidBrush(sveZauzeto ? Boje.boja_Zid : Boje.boja_Slobodno);

                if (StartOrCilj == 1)
                {
                    ((MainForm)Application.OpenForms[0]).lavirint.Start = Pozicija;
                    stanje = StanjePolja.start;
                }
                else if (StartOrCilj == 2)
                {
                    ((MainForm)Application.OpenForms[0]).lavirint.Finish = Pozicija;
                    stanje = StanjePolja.cilj;
                }
            }
            Crtaj(g);
        }

        public void Clear(Graphics g, bool zid)
        {
            stanje = zid ? StanjePolja.zid : StanjePolja.slobodno;
            sb = new SolidBrush(zid ? Boje.boja_Zid : Boje.boja_Slobodno);
            Crtaj(g);
        }

        public void MarkOtvoren(Graphics g)
        {
            sb.Color = Boje.boja_Otvoren;
            Crtaj(g);
        }

        public void CrtajPutanju(Graphics g, int delta_t)
        {
            sb.Color = Boje.boja_Putanja;
            this.Crtaj(g);
            Thread.Sleep(delta_t);
            Console.Beep();
            if (stanje != StanjePolja.start)
                this.parent.CrtajPutanju(g, delta_t);

        }

        public void Resize(int stranica, int xstart, int ystart)
        {
            this.stranica = stranica;
            Polje.xstart = xstart;
            Polje.ystart = ystart;
        }

        public void Restart(bool zauzeto, Graphics g)
        {
            sb.Color = zauzeto ? Boje.boja_Zid : Boje.boja_Slobodno;
            stanje = zauzeto ? StanjePolja.zid : StanjePolja.slobodno;

            Crtaj(g);
        }

    }
    public enum StanjePolja { zid, slobodno, start, cilj }
    public static class Boje
    {
        public static readonly Color boja_Slobodno = Color.White;
        public static readonly Color boja_Zid = Color.FromArgb(81, 103, 111);
        public static readonly Color boja_Putanja = Color.FromArgb(255, 75, 75);
        public static readonly Color boja_Otvoren = Color.FromArgb(255, 241, 106);
    }
}
