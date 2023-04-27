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
                Polje current = MinimumF(openList);

                // Mark the current node as visited
                current.MarkOtvoren(g);
                Thread.Sleep(100);

                // Remove the current node from the open list and add it to the closed list
                openList.Remove(current);
                closedList.Add(current);

                // Check if the current node is the goal node
                if (current.Pozicija.X == Finish.X && current.Pozicija.Y == Finish.Y)
                {
                    current.CrtajPutanju(g);
                    return;
                }

                // Iterate through the neighboring nodes
                foreach (Polje neighbor in SusednaPolja(current, strane4))
                {
                    // Skip nodes that are already in the closed list
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    // Calculate the tentative G value (the cost to get to this node from the start node)
                    double tentativeG = current.G + (neighbor.Pozicija.X != current.Pozicija.X && neighbor.Pozicija.Y != current.Pozicija.Y ? Math.Sqrt(2) : 1);

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
                    neighbor.parent = current;
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
                        polja[i, j].H = (Math.Sqrt(2) * Math.Min(dY, dX) + Math.Abs(dY - dX)); //Pitagora calc
                }
        }

        public Polje MinimumF(HashSet<Polje> nodes)
        {
            return  nodes.OrderBy(n => n.G + n.H).First();
        }


        public void Dijkstra(bool strane4, Graphics g)
        {
            HashSet<Polje> openList = new HashSet<Polje>();
            HashSet<Polje> closedList = new HashSet<Polje>();

            // Initialize start node
            Polje startNode = polja[Start.Y, Start.X];
            startNode.G = 0;
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                // Find the node with the lowest cost in the open list
                Polje currentNode = openList.OrderBy(n => n.G).First();


                openList.Remove(currentNode);
                closedList.Add(currentNode);

                // Iterate over the neighbor nodes
                foreach (Polje neighbor in SusednaPolja(currentNode, strane4))
                {
                    if (closedList.Contains(neighbor))
                        continue;


                    double tentativeG = currentNode.G + 1;
                    if (neighbor.Pozicija.X != currentNode.Pozicija.X && neighbor.Pozicija.Y != currentNode.Pozicija.Y)
                        tentativeG += Math.Sqrt(2) - 1; 
                                                                       
                    if (!openList.Contains(neighbor) || tentativeG < neighbor.G)
                    {
                        neighbor.G = tentativeG;
                        neighbor.parent = currentNode;

                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                            neighbor.MarkOtvoren(g);
                            Thread.Sleep(50);
                        }
                    }

                    // If the current node is the goal node, we have found the shortest path
                    if (neighbor.Pozicija.X == Finish.X && neighbor.Pozicija.Y == Finish.Y)
                    {
                        // Reconstruct the path by following the parent pointers
                        neighbor.CrtajPutanju(g);

                        return;
                    }
                }
            }
        }

        public void BFS(bool strane4, Graphics g)
        {
            Queue<Polje> queue = new Queue<Polje>();
            HashSet<Polje> visited = new HashSet<Polje>();

            Polje startNode = polja[Start.Y, Start.X];
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                Polje currentNode = queue.Dequeue();

                // Check if the current node is the goal node
                if (currentNode.Pozicija.X == Finish.X && currentNode.Pozicija.Y == Finish.Y)
                {
                    currentNode.CrtajPutanju(g);
                    return;
                }

                // Mark the current node as visited
                visited.Add(currentNode);
                currentNode.MarkOtvoren(g);
                Thread.Sleep(50);

                // Iterate through the neighboring nodes
                foreach (Polje neighbor in SusednaPolja(currentNode, strane4))
                {
                    if (visited.Contains(neighbor) || queue.Contains(neighbor))
                    {
                        continue;
                    }

                    // Set the parent of the neighbor to the current node
                    neighbor.parent = currentNode;

                    // Add the neighbor to the queue
                    queue.Enqueue(neighbor);
                }
            }
        }



        public void DFS(bool strane4, Graphics g)
        {
            Stack<Polje> stack = new Stack<Polje>();
            HashSet<Polje> visited = new HashSet<Polje>();
            Polje startNode = polja[Start.Y, Start.X];
            stack.Push(startNode);

            while (stack.Count > 0)
            {
                Polje currentNode = stack.Pop();
                visited.Add(currentNode);
                currentNode.MarkOtvoren(g);
                Thread.Sleep(100);

                if (currentNode.Pozicija.X == Finish.X && currentNode.Pozicija.Y == Finish.Y)
                {
                    currentNode.CrtajPutanju(g);
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
