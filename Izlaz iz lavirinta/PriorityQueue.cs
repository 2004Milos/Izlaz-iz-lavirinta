using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace Izlaz_iz_lavirinta
{
    internal class PriorityQueue
    {
        List<Polje> lista; //sortirana po G+H rastuce, pa onda FIFO

        public PriorityQueue()
        {
            lista = new List<Polje>();
        }

        public void Enqueue(Polje p)
        {
            if (lista.Count == 0)
            {
                lista.Add(p);
                return;
            }
            int i = 0;

            while (lista[i].G + lista[i].H < p.G + p.H)
            {
                i++;
                if (i == lista.Count)
                    break;
            }

            lista.Insert(i, p);
        }

        public Polje Dequeue()
        {
            if (lista.Count() == 0)
                return null;
            Polje p = lista[0];
            lista.RemoveAt(0);
            return p;
        }

        public bool Contains(Polje p)
        {
            return lista.Contains(p);
        }
    }
}
