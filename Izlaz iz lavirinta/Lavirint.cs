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
using Windows.UI.Composition.Interactions;

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

        public bool sveZazeto_onStart = true;
        int simulator_delta_t = 50;

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
            int i = Math.Clamp((int)((x - xstart) / (stranicaPolja+2)), 0, Dimenzije.Item1-1);
            int j = Math.Clamp((int)((y - ystart) / (stranicaPolja+2)), 0, Dimenzije.Item2-1);
            return new Point(i, j);
        }

        public void SetStartFinish(Graphics g, int x, int y, bool start)
        {
            if (start)
            {
                if(Start.X != -1)
                    polja[Start.Y, Start.X].Clear(g,sveZazeto_onStart);
                Start = new Point(x, y);
                polja[y, x].Click(g, 1, false);
            }
            else
            {
                if(Finish.X != -1)
                    polja[Finish.Y, Finish.X].Clear(g, sveZazeto_onStart);
                Finish = new Point(x, y);
                polja[y, x].Click(g, 2, false);
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

        /// <summary>
        /// Pohlepni algoritam pretrage po najboljem svojstvu
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        
        public void AStar(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam usporio radi bolje preglednosti, prema proporciji
            //25 : P = X : 40, P-povrsina pravougaonika odredjena start i finish tackama - obrnuta proporcija dobijena testriranjem
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X) + 1) * (Math.Abs(Start.Y - Finish.Y) + 1))); 
            HashSet<Polje> open = new HashSet<Polje>();
            HashSet<Polje> closed = new HashSet<Polje>();

            // Izračunavaju se predviđene razdawine između polja lavirinta i cilja, heurističkom metodom
            CalculateH(strane4);

            // Početno poqe se dodaje u skup otvorenih polja
            open.Add(polja[Start.Y, Start.X]);

            // Iteracija traje dok ima mogućnosti dalje pretrage ili do trenutka kada je prektinuta pronalaskom cilja
            while (open.Count > 0)
            {
                // Za trenutno polje se uzima polje iz open skupa sa najmanjom F vrednošću
                Polje trenutno = MinimumF(open);

                Thread.Sleep(simulator_delta_t);

                // Trenutno polje se uklanja iz skupa otvorenih i stavlja u skup zatvorenih polja
                open.Remove(trenutno);
                closed.Add(trenutno);

                // Ako je cilj pronđen, pretraga je gotova i putanja može da se iscrta
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g, 2*simulator_delta_t);
                    return;
                }

                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    // Posećena polja ne treba ponovo da se obilaze, pa se preskaču
                    if (closed.Contains(sused))
                    {
                        continue;
                    }

                    // Razdaljina od starnog polja do suseda (moguceG) je jednaka zbiru razdaljina startnog od trenutnog i trenutnog od susednog
                    // Razdaljina trenutnog od susednog je 1 ako dele stranicu, a sqrt(2) ako su susedni dijagonalno
                    double moguceG = trenutno.G + (sused.Pozicija.X != trenutno.Pozicija.X && sused.Pozicija.Y != trenutno.Pozicija.Y ? Math.Sqrt(2) : 1);

                    // a) Ako je polje neotvoreno to znaci da mu nikad nije dodeljena G vrednost, pa u tom slucaju svakako treba postaviti G vrednost prvi put
                    // b) G vrednost treba izmeniti kada je nova manja (bolja) od G vrednosti koja je izračunata ranije na drugi način (iz druge putanje)
                    // Kada se postavlja nova G vrednost, treba postaviti i novog prethodnika polja, jer je pronadjen novi optimalniji put
                    if (!open.Contains(sused) || moguceG < sused.G)
                    {
                        sused.G = moguceG;
                        sused.parent = trenutno;

                        // Ako polje već nije, treba da dodati u skup otvorenih polja, i grafički ga označiti kao otvoreno
                        if (!open.Contains(sused))
                        {
                            open.Add(sused);

                            // susedno polje se označava kao otvoreno u GKI
                            sused.MarkOtvoren(g);

                            // Usporavanje izvršavanja radi preglednosti
                            Thread.Sleep(simulator_delta_t);
                        }
                    }
                }
            }
        }


        public void CalculateH(bool strane4)
        {
            for (int i = 0; i < Dimenzije.Item2; i++)
                for (int j = 0; j < Dimenzije.Item1; j++)
                {
                    double dY = Math.Abs(Finish.Y - i);
                    double dX = Math.Abs(Finish.X - j);

                    if (strane4)
                        //Manhetn rastojanje
                        polja[i, j].H = dY + dX; 
                    else
                        //Oktilno rastojanje
                        polja[i, j].H = (Math.Sqrt(2) * Math.Min(dY, dX) + Math.Abs(dY - dX)); 
                }
        }

        public Polje MinimumF(HashSet<Polje> nodes)
        {
            return nodes.OrderBy(n => n.G + n.H).ThenBy(n => n.H).First();
        }

        public Polje MinimumH(HashSet<Polje> nodes)
        {
            return nodes.OrderBy(n => n.H).First();
        }

        public Polje MinimumG(HashSet<Polje> nodes)
        {
            return nodes.OrderBy(n => n.G).First();
        }

        /// <summary>
        /// Pohlepni algoritam pretrage po najboljem svojstvu
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        public void BestFS(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam usporio radi bolje preglednosti, prema proporciji
            //25 : P = X : 40, P-povrsina pravougaonika odredjena start i finish tackama - obrnuta proporcija dobijena testriranjem
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X) + 1) * (Math.Abs(Start.Y - Finish.Y) + 1)));

            HashSet<Polje> open = new HashSet<Polje>();
            HashSet<Polje> closed = new HashSet<Polje>();
            CalculateH(strane4);

            // Po;etno polje se oyna;ava kao otvoreno, dodavanjem u skup
            open.Add(polja[Start.Y, Start.X]);

            while (open.Count > 0)
            {
                //Za trenutno polje se uzima ono koje trenutno ima najbolju H vrednost u skupu otvorenih polja
                Polje trenutno = MinimumH(open);

                //Trenutno polje se uklanja iz otvorenih, a dodaje u zatvorena polja
                open.Remove(trenutno);
                closed.Add(trenutno);

                //Usporavanje izvršavanja radi preglednosti
                Thread.Sleep(simulator_delta_t);

                //Grafički prikaz otvorenog polja na GKI 
                trenutno.MarkOtvoren(g);

                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    //Ako je sused zatvoren, preskače se kako se ne bi ponavljao
                    if (closed.Contains(sused))
                    {
                        continue;
                    }

                    //Ako već nije sused se dodaje u skup otvorenih polja
                    if (!open.Contains(sused))
                    {
                        open.Add(sused);
                    }

                    //Trenutno polje se postavlja kao prethodnik susednom u hijerarhiji putanje
                    sused.parent = trenutno;

                    //Ako je sused traženo polje, pretraga je uspešno završena, i putanja se iscrtava
                    if (sused.Pozicija.X == Finish.X && sused.Pozicija.Y == Finish.Y)
                    {
                        sused.CrtajPutanju(g, 2 * simulator_delta_t);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Dajkstrin algoritam pretrage najkraće putanje
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        public void Dijkstra(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam usporio radi bolje preglednosti, prema proporciji
            //25 : P = X : 40, P-povrsina pravougaonika odredjena start i finish tackama - obrnuta proporcija dobijena testriranjem
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));

            HashSet<Polje> open = new HashSet<Polje>();
            HashSet<Polje> closed = new HashSet<Polje>();

            Polje StartnoPolje = polja[Start.Y, Start.X];

            // Startno polje je za 0 odaljeno samo od sebe
            StartnoPolje.G = 0;

            // Startno polje se dodaje u open listu radi dalje provere
            open.Add(StartnoPolje);

            while (open.Count > 0)
            {
                // Za trenutno polje se uzima polje iz open liste koje je je najbliže startnom polju - minimalan G faktor
                // Ovaj korak se može izbeći korišćenjem priority queue-a, što u ovom slučaju nije bilo potpuno adekvatno
                Polje trenutno = MinimumG(open);

                // Odabrano trenutno polje se uklanja iz skupa otvorenih i stavlja u skup zatvorenih polja, kako se ne bi ponovilo
                open.Remove(trenutno);
                closed.Add(trenutno);

                // Prolazak kroz sva susedna polja, po dijagonali ili ne, što je određeno sa strane4
                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    // Ako je polje već proverno, preskače se
                    if (closed.Contains(sused))
                        continue;

                    // Razdaljina od starnog polja do suseda (moguceG) je jednaka zbiru razdaljina startnog od trenutnog i trenutnog od susednog
                    // Razdaljina trenutnog od susednog je 1 ako dele stranicu, a sqrt(2) ako su susedni dijagonalno
                    double moguceG = trenutno.G + 1;
                    if (sused.Pozicija.X != trenutno.Pozicija.X && sused.Pozicija.Y != trenutno.Pozicija.Y)
                        moguceG += Math.Sqrt(2) - 1; 

                    // a) Ako je polje neotvoreno to znaci da mu nikad nije dodeljena G vrednost, pa u tom slucaju svakako treba postaviti G vrednost prvi put
                    // b) G vrednost treba izmeniti kada je nova manja (bolja) od G vrednosti koja je izračunata ranije na drugi način (iz druge putanje)
                    // Kada se postavlja nova G vrednost, treba postaviti i novog prethodnika polja, jer je pronadjen novi optimalniji put
                    if (!open.Contains(sused) || moguceG < sused.G)
                    {
                        sused.G = moguceG;
                        sused.parent = trenutno;

                        // Ako polje već nije, treba da dodati u skup otvorenih polja, i grafički ga označiti kao otvoreno
                        if (!open.Contains(sused))
                        {
                            open.Add(sused);
                            sused.MarkOtvoren(g);

                            // Usporavanje izvršavanja radi preglednosti
                            Thread.Sleep(simulator_delta_t);
                        }
                    }

                    //Ako je traženo polje pronađeno, pretraga je gotova i putanja se može iscrtati pomoću pokazivača na roditeljska polja
                    if (sused.Pozicija.X == Finish.X && sused.Pozicija.Y == Finish.Y)
                    {
                        sused.CrtajPutanju(g, 2*simulator_delta_t);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Algoritam pretrage u širinu
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        public void BFS(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam usporio radi bolje preglednosti, prema proporciji
            //25 : P = X : 40, P-povrsina pravougaonika odredjena start i finish tackama - obrnuta proporcija dobijena testriranjem
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));
            
            Queue<Polje> Polja_za_proveru = new Queue<Polje>();
            HashSet<Polje> poseceno = new HashSet<Polje>();
            Polje startno_polje = polja[Start.Y, Start.X];

            //Startno polje se dodaje polje u red za proveru
            Polja_za_proveru.Enqueue(startno_polje);

            //Iteracija se ponavlja sve dok ima mogućnosti za proveru
            while (Polja_za_proveru.Count > 0)
            {
                //Trenutno polje se skida sa početka reda, to je polje koje je najduže bilo u redu (FIFO)
                Polje trenutno = Polja_za_proveru.Dequeue();

                //Ako je trenutno polje traženo, pretraga je uspešno završena, a rekosnstruisana putanja se iscrtava
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g, 2*simulator_delta_t); //Grafički prikaz rekonstruisane putanje na lavirintu
                    return;
                }

                //Trenutno polje se dodaje u skup posećenih polja, da se ne bi ponavljalo
                poseceno.Add(trenutno);


                // Prolazak kroz sva susedna polja trenutnog polja, susedna polja se određuju i na osnovu toga da li je dozvoljeno dijagnalno kretanje
                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    //Ako je već posećeno ili dodato u red, preskače se
                    if (poseceno.Contains(sused) || Polja_za_proveru.Contains(sused))
                        continue;

                    //Trenutno polje se postavlja kao prethodničko susednom polju
                    sused.parent = trenutno;
                    //Susedno polje se dodaje na kraj reda kako bi bilo provereno tokom dalje iteracije
                    Polja_za_proveru.Enqueue(sused);

                    //Usporavanje algortma radi bolje preglednosti 
                    Thread.Sleep(simulator_delta_t);

                    //Grafiički prikaz otvorenog polja
                    sused.MarkOtvoren(g);
                }
            }
        }


        /// <summary>
        /// Algoritam pretrage u dubinu - DFS
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        public void DFS(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam uspori radi bolje preglednosti, prema proporciji 
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));
            
            Stack<Polje> Polja_za_proveru = new Stack<Polje>();
            HashSet<Polje> poseceno = new HashSet<Polje>();
            Polje startNode = polja[Start.Y, Start.X];

            //Početno polje se dodaje u stek polja za proveru
            Polja_za_proveru.Push(startNode);

            //Iteracija se ponavlja sve dok ima mogućnosti za proveru
            while (Polja_za_proveru.Count > 0)
            {
                //Za trenutno polje u ovom momentu se skida polje sa kraja steka
                Polje trenutno = Polja_za_proveru.Pop();

                //Ako je trenutno polje traženo, pretraga je uspešno završena, a rekosnstruisana putanja se iscrtava
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g, 2 * simulator_delta_t);
                    return;
                }

                //trenutno polje se dodaje u skup posećenih polja, da se ne bi ponavljalo
                poseceno.Add(trenutno);

                //Grafički prikaz prolaza kroz polje
                trenutno.MarkOtvoren(g);

                //Usporavanje algoitma radi bolje preglednosti
                Thread.Sleep(simulator_delta_t);

                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    if (!poseceno.Contains(sused))
                    {
                        //Neposećeni sused se dodaje na kraj hijerarhije u dosadašnjoj putanji (pomoću pokazivača na prethodnika)
                        sused.parent = trenutno;

                        //Taj sused se dodaje na kraj steka, kako bi bio proveren
                        Polja_za_proveru.Push(sused);
                    }
                }
            }
        }


        public void Clear(bool svezauzeto, Graphics g)
        {
            Start = new Point(-1,-1);
            Finish = new Point(-1,-1);
            sveZazeto_onStart = svezauzeto;

            for (int i = 0; i < Dimenzije.Item2; i++)
                for (int j = 0; j < Dimenzije.Item1; j++)
                    polja[i, j].Restart(svezauzeto,g);
        }

        public void RemovePaths(Graphics g) {
            for (int i = 0; i < Dimenzije.Item2; i++)
                for (int j = 0; j < Dimenzije.Item1; j++)
                {
                    polja[i,j].sb.Color = (polja[i,j].stanje == StanjePolja.zid) ? Boje.boja_Zid : Boje.boja_Slobodno;
                    polja[i, j].Crtaj(g);
                }
        }
    }
}
