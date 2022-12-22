using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Demo_many2many2.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DemoEFDapper
{
    public class GetDapperData
    {
        public static void Hämta_kategorier()
        {
            //string connString = "data source=.\\Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";
            
            //var sql = "SELECT * FROM Kategorier";

            //var kategorier = new List<Kategori>();

            using (var db = new MyDBContext())
            {
                var List = db.Kategorier;
                foreach (var x in List)
                {
                    Console.Write(x.Id);
                    if (x.Namn.Length > 25)
                    {
                        Console.CursorLeft = x.Namn.Length + 10;
                        Console.Write(x.Namn);
                    }
                    else
                    {
                        Console.CursorLeft = 10;
                        Console.Write(x.Namn);
                    }
                }
            }

        }
    }
}

