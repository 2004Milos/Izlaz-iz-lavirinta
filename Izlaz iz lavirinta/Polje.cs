using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Windows.ApplicationModel.Appointments;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Izlaz_iz_lavirinta
{
    public class Polje
    {
        public StanjePolja stanje;
        public Point Pozicija;
        SolidBrush sb;
        
        public int str;
        public int xstart, ystart;

        public int G, H;
        public Polje parent;


        public Polje(int str, Point pozicija, int xstart, int ystart, StanjePolja stanje = StanjePolja.zid)
        {
            this.Pozicija = pozicija;
            this.stanje = stanje;
            this.str = str;

            this.xstart = xstart;
            this.ystart = ystart;

            sb = new SolidBrush((stanje == StanjePolja.zid) ? Boje.boja_Zid : Boje.boja_Slobodno);
        }

        public void Crtaj(Graphics g)
        {
            g.FillRectangle(sb, xstart+Pozicija.X * (str + 2), ystart+Pozicija.Y * (str + 2), str, str);

            if (stanje == StanjePolja.start)
                using (Image startImage = Properties.Resources.start)
                {
                    g.DrawImage(startImage, xstart + Pozicija.X * (str + 2), ystart + Pozicija.Y * (str + 2), str, str);
                    G = 0;
                }
            else if (stanje == StanjePolja.cilj)
                using (Image finishImage = Properties.Resources.finish)
                {
                    g.DrawImage(finishImage, xstart + Pozicija.X * (str + 2), ystart + Pozicija.Y * (str + 2), str, str);
                }
        }

        public void Click(Graphics g, int StartOrCilj)
        {
            if (StartOrCilj == 0)
            {
                stanje = (stanje == StanjePolja.zid) ? StanjePolja.slobodno : StanjePolja.zid;
                sb = new SolidBrush((stanje == StanjePolja.zid) ? Boje.boja_Zid : Boje.boja_Slobodno);
            }
            else
            {
                sb = new SolidBrush(Boje.boja_Slobodno);

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

        public void MarkOtvoren(Graphics g)
        {
            sb.Color = Boje.boja_Otvoren;
            Crtaj(g);
        }

        public void CrtajPutanju(Graphics g)
        {
            sb.Color = Boje.boja_Putanja;
            this.Crtaj(g);
            Thread.Sleep(80);
            Console.Beep();
            if (stanje != StanjePolja.start)
                this.parent.CrtajPutanju(g);
        }

        public void Resize(int stranica, int xstart, int ystart)
        {
            this.str = stranica;
            this.xstart = xstart;
            this.ystart = ystart;
        }


    }
    public enum StanjePolja { zid, slobodno, start, cilj }
    public static class Boje
    {
        public static readonly Color boja_Slobodno = Color.White;
        public static readonly Color boja_Zid = Color.Gray;
        public static readonly Color boja_Putanja = Color.Yellow;
        public static readonly Color boja_Otvoren = Color.LightPink;
    }
}
