﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Models
{
    public class Movie  //test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
}
