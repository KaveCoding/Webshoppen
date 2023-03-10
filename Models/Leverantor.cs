using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Leverantör
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public float Pris { get; set; }
        public int LeveransTid { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
        public ICollection<Beställning> Beställningar  { get; set; }
    }
}
