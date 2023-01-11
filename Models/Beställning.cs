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
        public int VarukorgId { get; set; }
        public int BetalsättId { get; set; }
        public int KundId { get; set; }
        public int ProduktId { get; set; }

    }
}
