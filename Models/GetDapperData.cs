using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Demo_many2many2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DemoEFDapper
{
    public class GetDapperData
    {
        public static void Hämta_kategorier()
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = "SELECT * FROM Kategorier";

            var kategorier = new List<Kategori>();

            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    kategorier = connection.Query<Kategori>(sql).ToList();
                    connection.Close();
                }

                foreach (var x in kategorier)
                {
                        Console.Write(x.Namn + " ");
                        Console.WriteLine(x.Id);
                }
            }
        }


        public static void Deletevarukorgar(int kundId)
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = $"delete from Varukorgar where KundId = {kundId} ";
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    connection.Execute(sql);
                    connection.Close();
                }

            }
        }
    }
}

