using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Kund
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string GatuNamn { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public string PersonNummer { get; set; }
        public string TelefonNummer { get; set; }
        public string Email { get; set; }
        public ICollection<Beställning> Beställningar { get; set; }
        public ICollection<Varukorg> Varukorgar { get; set; }
    }
}
