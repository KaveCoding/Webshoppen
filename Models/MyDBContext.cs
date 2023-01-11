using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Demo_many2many2.Models
{
    public class MyDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<Produkt> Produkter { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Leverantör> Leverantörer { get; set; }
        public DbSet<Kund> Kunder { get; set; }
        public DbSet<LagerStatus> LagerStatusar { get; set; }
        public DbSet<Beställning> Beställningar { get; set; }
        public DbSet<Betalsätt> Betalsätter { get; set; }
        public DbSet<Varukorg> Varukorgar { get; set; }

    }
}
