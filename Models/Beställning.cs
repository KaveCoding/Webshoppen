using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Beställning
    {
        public int Id { get; set; }
        public int Antal { get; set; }
        public float Summa { get; set; }
        public DateTime Datum { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
        public ICollection<Kund> Kunder { get; set; }

    }
}
