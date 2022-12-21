﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Storlek { get; set; }
        public float Pris { get; set; }
        public string Info { get; set; }
        public bool UtvaldProdukt { get; set; }
        public ICollection<Kategori> Kategorier { get; set; }
        public ICollection<Leverantör> Leverantörer { get; set; }
    }
}
