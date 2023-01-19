using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Demo_many2many2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DemoEFDapper
{
    public class GetDapperData
    {
       
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
        public static void LagerStatusQuery()
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = $"SELECT * FROM LagerStatusar ORDER BY Saldo desc ";
            var lagerProdukter = new List<LagerStatus>();
            {

                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    lagerProdukter = connection.Query<LagerStatus>(sql).ToList();
                    connection.Close();
                }
                Console.WriteLine("Nuvarande lagerstatus:");
                foreach (var x in lagerProdukter)
                {
                    Console.WriteLine($"ProduktId: {x.ProduktId} Saldo: {x.Saldo}");
                }
            }
        }
        
    }
}

