using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    internal class Kund
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string GatuNamn { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public int PersonNummer { get; set; }
        public int TelefonNummer { get; set; }
        public string Email { get; set; }
    }
}
