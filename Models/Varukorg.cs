using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Varukorg
    {
        public int Id { get; set; }
        public int KundId { get; set; }
        public int ProduktId { get; set; }
        public int ProduktAntal { get; set; }
        public string ProduktStorlek { get; set; }
        public float Summa { get; set; }

        
    }
}
