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
            int i = (int)((x - xstart) / (stranicaPolja+2));
            int j = (int)((y - ystart) / (stranicaPolja+2));
            return new Point(i > (Dimenzije.Item1 - 1) ? (Dimenzije.Item1 - 1) : i, j > (Dimenzije.Item2 - 1) ? (Dimenzije.Item2 - 1) : j);
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

        public void AStar(bool strane4, Graphics g)
        {
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));//25 : 50 = X : P, P-povrsina pravougaonika odredjena start i finish tackama
            HashSet<Polje> openList = new HashSet<Polje>();
            HashSet<Polje> closedList = new HashSet<Polje>();

            // Calculate the heuristic values (H) for each node
            CalculateH(strane4);

            // Add the start node to the open list
            openList.Add(polja[Start.Y, Start.X]);

            // Loop until there are no more nodes to explore
            while (openList.Count > 0)
            {
                // Get the node with the lowest F value from the open list
                Polje trenutno = MinimumF(openList);

                // Mark the trenutno node as visited
                trenutno.MarkOtvoren(g);
                Thread.Sleep(simulator_delta_t);

                // Remove the trenutno node from the open list and add it to the closed list
                openList.Remove(trenutno);
                closedList.Add(trenutno);

                // Check if the trenutno node is the goal node
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g, 2*simulator_delta_t);
                    return;
                }

                // Iterate through the neighboring nodes
                foreach (Polje neighbor in SusednaPolja(trenutno, strane4))
                {
                    // Skip nodes that are already in the closed list
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    // Calculate the tentative G value (the cost to get to this node from the start node)
                    double tentativeG = trenutno.G + (neighbor.Pozicija.X != trenutno.Pozicija.X && neighbor.Pozicija.Y != trenutno.Pozicija.Y ? Math.Sqrt(2) : 1);

                    // Check if the neighbor is already in the open list
                    if (openList.Contains(neighbor))
                    {
                        // Skip this neighbor if it already has a lower G value
                        if (tentativeG >= neighbor.G)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        // Add the neighbor to the open list if it's not already there
                        openList.Add(neighbor);
                    }

                    // Update the G and parent values for the neighbor
                    neighbor.G = tentativeG;
                    neighbor.parent = trenutno;
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
                        polja[i, j].H = dY + dX; //Manhetan calc
                    else
                        polja[i, j].H = (Math.Sqrt(2) * Math.Min(dY, dX) + Math.Abs(dY - dX)); //Octile calc
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


        public void BestFS(bool strane4, Graphics g)
        {
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X) + 1) * (Math.Abs(Start.Y - Finish.Y) + 1))); //25 : 50 = X : P, P-povrsina pravougaonika odredjena start i finish tackama
            HashSet<Polje> openList = new HashSet<Polje>();
            HashSet<Polje> closedList = new HashSet<Polje>();
            CalculateH(strane4);

            openList.Add(polja[Start.Y, Start.X]);

            while (openList.Count > 0)
            {
                Polje trenutno = MinimumH(openList);
                openList.Remove(trenutno);
                closedList.Add(trenutno);
                Thread.Sleep(simulator_delta_t);
                trenutno.MarkOtvoren(g);

                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    if (closedList.Contains(sused))
                    {
                        continue;
                    }

                    if (!openList.Contains(sused))
                    {
                        openList.Add(sused);
                    }
                    sused.parent = trenutno;

                    if (sused.Pozicija.X == Finish.X && sused.Pozicija.Y == Finish.Y)
                    {
                        sused.CrtajPutanju(g, 2 * simulator_delta_t);
                        return;
                    }
                }
            }
        }


        public void Dijkstra(bool strane4, Graphics g)
        {
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));//25 : 50 = X : P, P-povrsina pravougaonika odredjena start i finish tackama
            HashSet<Polje> openList = new HashSet<Polje>();
            HashSet<Polje> closedList = new HashSet<Polje>();

            // Initialize start node
            Polje startNode = polja[Start.Y, Start.X];
            startNode.G = 0;
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                // Find the node with the lowest cost in the open list
                Polje trenutno = openList.OrderBy(n => n.G).First();


                openList.Remove(trenutno);
                closedList.Add(trenutno);

                // Iterate over the neighbor nodes
                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    if (closedList.Contains(sused))
                        continue;


                    double tentativeG = trenutno.G + 1;
                    if (sused.Pozicija.X != trenutno.Pozicija.X && sused.Pozicija.Y != trenutno.Pozicija.Y)
                        tentativeG += Math.Sqrt(2) - 1; 
                                                                       
                    if (!openList.Contains(sused) || tentativeG < sused.G)
                    {
                        sused.G = tentativeG;
                        sused.parent = trenutno;

                        if (!openList.Contains(sused))
                        {
                            openList.Add(sused);
                            sused.MarkOtvoren(g);
                            Thread.Sleep(simulator_delta_t);
                        }
                    }

                    // If the current node is the goal node, we have found the shortest path
                    if (sused.Pozicija.X == Finish.X && sused.Pozicija.Y == Finish.Y)
                    {
                        // Reconstruct the path by following the parent pointers
                        sused.CrtajPutanju(g, 2*simulator_delta_t);

                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Algoritam pretrage u dubinu
        /// </summary>
        /// <param name="strane4"> Logička promenljiva, pokazuje da li je dozvoljeno dijagonalno kretanje ili ne</param>
        /// <param name="g"> Grafika korisničkog interfejsak po kojoj se iscrtava prolaz kroz lavirint </param>
        public void BFS(bool strane4, Graphics g)
        {
            //Izračunava se vreme potrebno da bi se algoritam uspori radi bolje preglednosti
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));//25 : 50 = X : P, P-povrsina pravougaonika odredjena start i finish tackama
            Queue<Polje> Polja_za_proveru = new Queue<Polje>();
            HashSet<Polje> poseceno = new HashSet<Polje>();

            Polje startno_polje = polja[Start.Y, Start.X];
            Polja_za_proveru.Enqueue(startno_polje); //dodaje se polje u red

            while (Polja_za_proveru.Count > 0)
            {
                Polje trenutno = Polja_za_proveru.Dequeue();

                //Proveriti da li je trenutno poqe traženo polje - cilj
                if (trenutno.Pozicija.X == Finish.X && trenutno.Pozicija.Y == Finish.Y)
                {
                    trenutno.CrtajPutanju(g, 2*simulator_delta_t); //Grafički prikaz rekonstruisane putanje na lavirintu
                    return;
                }

                //Trenutno poqe se označava kao posećeno, kako se ne bi ponovilo
                poseceno.Add(trenutno);
                trenutno.MarkOtvoren(g); //Grafiički prikaz otvorenog i proverenog polja
                Thread.Sleep(simulator_delta_t); //Usporavanje algortma radi bolje vidljivosti 

                // Prolazak kroz sva susedna polja trenutnog polja, susedna poqa se određuju i na osnovu toga da li je dozvoljeno dijagnalno kretanje
                foreach (Polje sused in SusednaPolja(trenutno, strane4))
                {
                    if (poseceno.Contains(sused) || Polja_za_proveru.Contains(sused)) //ako je već posećeno ili dodato u red, preskače se
                        continue;

                    //Trenutno polje se postavlja kao prethodničko susednom polju
                    sused.parent = trenutno;
                    //susedno polje se dodaje na kraj reda kako bi bilo provereno tokom iteracije
                    Polja_za_proveru.Enqueue(sused);
                }
            }
        }



        public void DFS(bool strane4, Graphics g)
        {
            simulator_delta_t = (int)(25 * 40 / ((Math.Abs(Start.X - Finish.X)+1) * (Math.Abs(Start.Y - Finish.Y)+1)));//25 : 50 = X : P, P-povrsina pravougaonika odredjena start i finish tackama
            Stack<Polje> stack = new Stack<Polje>();
            HashSet<Polje> visited = new HashSet<Polje>();
            Polje startNode = polja[Start.Y, Start.X];
            stack.Push(startNode);

            while (stack.Count > 0)
            {
                Polje currentNode = stack.Pop();
                visited.Add(currentNode);
                currentNode.MarkOtvoren(g);
                Thread.Sleep(simulator_delta_t);

                if (currentNode.Pozicija.X == Finish.X && currentNode.Pozicija.Y == Finish.Y)
                {
                    currentNode.CrtajPutanju(g, 2*simulator_delta_t);
                    return;
                }

                foreach (Polje neighbor in SusednaPolja(currentNode, strane4))
                {
                    if (!visited.Contains(neighbor))
                    {
                        neighbor.parent = currentNode;
                        stack.Push(neighbor);
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
