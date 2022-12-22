using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    
    public class LagerStatus
    {
        public int Id{ get; set; }
        public int Saldo { get; set; }
        public bool Tillgänglig { get; set; }
        public int ProduktId { get; set; }

    }
}
