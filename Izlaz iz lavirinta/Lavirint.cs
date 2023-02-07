using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using System.Threading;

namespace Izlaz_iz_lavirinta
{
    public class Lavirint
    {
        public Polje[,] polja;
        public int stranicaPolja;
        public Tuple<int,int> Dimenzije; //U poljima
        public int xstart = 0, ystart = 0;

        public Point Start;
        public Point Finish;

        public Lavirint(int FormWidth, int FormHeight, Tuple<int,int> dimenzije)
        {
            Dimenzije = dimenzije; 
            stranicaPolja = FormWidth / dimenzije.Item1 - 2;
            if(stranicaPolja*dimenzije.Item2 > (FormHeight - dimenzije.Item2 * 2))
                stranicaPolja = FormHeight / dimenzije.Item2 - 2;

            if(dimenzije.Item1 * (stranicaPolja+2) < FormWidth)
                xstart = (FormWidth - dimenzije.Item1 * (stranicaPolja+2)) / 2;
            if (dimenzije.Item2 * (stranicaPolja + 2) < FormHeight)
                ystart = (FormHeight - dimenzije.Item2 * (stranicaPolja+2)) / 2;

            polja = new Polje[Dimenzije.Item2, Dimenzije.Item1];

            Start = new Point(-1,-1);
            Finish= new Point(-1,-1);

            for (int i = 0; i < Dimenzije.Item2; i++)
            {
                for (int j = 0; j < Dimenzije.Item1; j++)
                {
                    polja[i, j] = new Polje(stranicaPolja,new Point(j,i), xstart, ystart);
                }
            }
        }

        public void Resize(int FormWidth, int FormHeight)
        {
            stranicaPolja = FormWidth / Dimenzije.Item1 - 2;
            if (stranicaPolja * Dimenzije.Item2 > (FormHeight - Dimenzije.Item2 * 2))
                stranicaPolja = FormHeight / Dimenzije.Item2 - 2;

            if (Dimenzije.Item1 * (stranicaPolja + 2) < FormWidth)
                xstart = (FormWidth - Dimenzije.Item1 * (stranicaPolja + 2)) / 2;
            if (Dimenzije.Item2 * (stranicaPolja + 2) < FormHeight)
                ystart = (FormHeight - Dimenzije.Item2 * (stranicaPolja + 2)) / 2;

            for (int i = 0; i < Dimenzije.Item2; i++)
                for (int j = 0; j < Dimenzije.Item1; j++)
                    polja[i, j].Resize(stranicaPolja,xstart,ystart);

        }

        public void Crtaj(Graphics g)
        {
            for (int i = 0; i < Dimenzije.Item2; i++)
            {
                for (int j = 0; j < Dimenzije.Item1; j++)
                {
                    polja[i, j].Crtaj(g);
                }
            }
        }

        public Point Polje_by_XY(int x, int y)
        {
            int i = (int)((x - xstart) / (stranicaPolja+2));
            int j = (int)((y - ystart) / (stranicaPolja+2));
            return new Point(i > (Dimenzije.Item1 - 1) ? (Dimenzije.Item1 - 1) : i, j > (Dimenzije.Item2 - 1) ? (Dimenzije.Item2 - 1) : j);
        }

        public void SetStartFinish(Graphics g, int x, int y, bool start)
        {
            if (start)
            {
                if(Start.X != -1)
                    polja[Start.Y, Start.X].Click(g, 0);
                Start = new Point(x, y);
                polja[y, x].Click(g, 1);
            }
            else
            {
                if(Finish.X != -1)
                    polja[Finish.Y, Finish.X].Click(g, 0);
                Finish = new Point(x, y);
                polja[y, x].Click(g, 2);
            }
        }

        IEnumerable<Polje> SusednaPolja(Polje p, bool strane4)
        {
            int i = p.Pozicija.Y;
            int j = p.Pozicija.X;
            for (int i1 = i - 1; i1 <= i + 1; i1++)
            {
                for (int j1 = j - 1; j1 <= j + 1; j1++)
                {
                    if (i1 == i && j1 == j) continue;
                    if (Math.Abs(i1-i)==Math.Abs(j1-j) && strane4) continue;
                    if (i1 < 0 || j1 < 0 || i1 > Dimenzije.Item2 - 1 || j1 > Dimenzije.Item1 - 1) continue;
                    if (polja[i1, j1].stanje == StanjePolja.zid) continue;
                    yield return polja[i1, j1];
                }
            }
        }

        public void AStar(bool strane4, Graphics g)
        {
            List<Polje> path = new List<Polje>();
            List<Polje> openList = new List<Polje>();
            HashSet<Polje> closedList = new HashSet<Polje>();
            CalculateH(strane4);

            openList.Add(polja[Start.Y, Start.X]);

            while (openList.Count > 0)
            {
                Polje trenutno = MinimumF(openList);
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g);
                    break;
                }
                openList.Remove(trenutno);
                closedList.Add(trenutno);

                foreach (Polje sused in SusednaPolja(trenutno,strane4))
                {
                    if (closedList.Contains(sused))
                    {
                        continue;
                    }
                    sused.G = trenutno.G + 1;
                    sused.parent = trenutno;

                    if (!openList.Contains(sused))
                    {
                        openList.Add(sused);
                        sused.MarkOtvoren(g);
                        Thread.Sleep(50);
                    }
                }
            }
        }

        public void CalculateH(bool strane4)
        {
            for (int i = 0; i < Dimenzije.Item2; i++)
                for (int j = 0; j < Dimenzije.Item1; j++)
                    if(strane4)
                        polja[i, j].H = Math.Abs(Finish.Y - i) + Math.Abs(Finish.X - j); //Manhetan calc
                    else
                        polja[i, j].H = (int)Math.Sqrt(Math.Pow(Finish.Y - i,2) + Math.Pow(Finish.X - j,2)); //Pitagora calc
        }

        public Polje MinimumF(List<Polje> list)
        {
            Polje min = list[0];
            foreach (Polje p in list)
                if (p.H + p.G < min.G + min.H)
                    min = p;
            return min;
        }
    }
}
