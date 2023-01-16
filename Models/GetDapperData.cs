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
        public static void HämtaBästSäljareProdukt()
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = $"SELECT ProduktId, COUNT(ProduktId) AS Antal " +
                $"\r\nFROM dbo.Beställningar" +
                $"\r\nGroup By ProduktId \r\n" +
                $"ORDER BY Antal desc ";
            var bästSäljareProdukt = new List<Beställning>();
            {

                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    bästSäljareProdukt = connection.Query<Beställning>(sql).ToList();
                    connection.Close();
                }
                Console.WriteLine("Bästsäljare högst upp");
                foreach (var x in bästSäljareProdukt)
                {
                    Console.WriteLine($"ProduktId: {x.ProduktId} Antal: {x.Antal}");
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
        public static void HämtaBästSäljareKategori()
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = $"SELECT KategoriId, COUNT(KategoriId) AS Antal FROM Beställningar b" +
                $" JOIN Produkter p ON p.Id = b.ProduktId " +
                $"GROUP BY KategoriId";
            var bästSäljareKategori = new List<Beställning>();
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    bästSäljareKategori = connection.Query<Beställning>(sql).ToList();
                    connection.Close();
                }
                Console.WriteLine("Bästsäljare högst upp");
                foreach (var x in bästSäljareKategori)
                {
                    Console.WriteLine($"ProduktId: {x.ProduktId} Antal: {x.Antal}"); //Propertierna overloadeas :)
                }
            }
        }
    }
}

