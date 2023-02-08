using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaVendingMachine
{
    internal class Soda
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int InStock; 
        public int Id { get; private set; }

        public Soda(string name, int cost, int count, int id)
        {
            Name = name;
            Cost = cost;
            InStock = count;
            Id = id;
        }
    }
}
