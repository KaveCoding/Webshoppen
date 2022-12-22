using EF_Demo_many2many2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Metoder
{
    internal class CRUD
    {
        public static void InsertKund(string namn, string gatuNamn, string stad, string land, string personNummer, string telefonNummer, string email)
        {

            using (var db = new MyDBContext()) // insert
            {
                var newKund = new Kund
                {
                    Namn = namn,
                    GatuNamn = gatuNamn,
                    Stad = stad,
                    Land = land,
                    PersonNummer = personNummer,
                    TelefonNummer = telefonNummer,
                    Email = email
                };
                var KundList = db.Kunder;
                KundList.Add(newKund);
                db.SaveChanges();
            }


            using (var db = new MyDBContext()) // DELETE
            {
                var deleteTodoListID = (from TDL in db.Kunder
                                        where TDL.Id == 1
                                        select TDL).SingleOrDefault();
                if (deleteTodoListID != null)
                {
                    db.Kunder.Remove((Kund)deleteTodoListID);
                    db.SaveChanges();
                }
            }
        }
        public static void InsertLagerStatus()
        {
            using (var db = new MyDBContext()) // insert
            {
                var newLagerstatus = new LagerStatus
                {
                    Saldo = 20,
                    Tillgänglig = true,
                    ProduktId = 2

                };
                var LagerstatusList = db.LagerStatusar;
                LagerstatusList.Add(newLagerstatus);
                db.SaveChanges();
            }
        }
        public static void InsertBeställningar()
        {
            using (var db = new MyDBContext()) // insert
            {
                var newBeställningar = new Beställning
                {
                    Antal = 2,
                    Summa = 99,
                    Datum = DateTime.Now,
                    BetalsättId = 1,
                    KundId = 2,
                    ProduktId = 2
                };
                var BeställningList = db.Beställningar;
                BeställningList.Add(newBeställningar);
                db.SaveChanges();
            }
        }
        public static void InsertBetalsätt()
        {
            using (var db = new MyDBContext()) // insert
            {
                var newBetalsätt = new Betalsätt()
                {
                    Namn = "Kreditkort"
                };
                var BetalsättList = db.Betalsätter;
                BetalsättList.Add(newBetalsätt);
                db.SaveChanges();
            }
        }
        public static void InsertKategori()
        {
            using (var db = new MyDBContext()) 
            {
                var newKategori = new Kategori()
                {
                    Namn = "Skor"
                };
                var KategoriList = db.Kategorier;
                KategoriList.Add(newKategori);
                db.SaveChanges();
            }
        }
        public static void InsertLeverantör()
        {
            using (var db = new MyDBContext())
            {
                var newLeverantör = new Leverantör()
                {
                    Namn = "Post Nord",
                    Pris = 50,
                    LeveransTid = 48
                };
                var LeverantörList = db.Leverantörer;
                LeverantörList.Add(newLeverantör);
                db.SaveChanges();
            }
        }
        public static void InsertProdukt()
        {
            using (var db = new MyDBContext())
            {
                var newProdukt = new Produkt()
                {
                    Namn = "Sneakers",
                    Storlek = "42",
                    Pris = 499.95F,
                    Info = "Feta sneakers",
                    UtvaldProdukt = false,
                    LeverantörId = 2,
                    KategoriId = 2
                };
                var ProduktList = db.Produkter;
                ProduktList.Add(newProdukt);
                db.SaveChanges();
            }
        }
        public static void Kund()
        {
            Console.WriteLine("Namn: ");
            var namn = Console.ReadLine();
            Console.WriteLine("Gatunamn: ");
            var gatuNamn = Console.ReadLine();
            Console.WriteLine("Stad: ");
            var stad = Console.ReadLine();
            Console.WriteLine("Land: ");
            var land = Console.ReadLine();
            Console.WriteLine("Personnummer: ");
            var personNummer = Console.ReadLine();
            Console.WriteLine("Telefonnummer: ");
            var telefonNummer = Console.ReadLine();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            InsertKund(namn, gatuNamn, stad, land, personNummer, telefonNummer, email);


        }
        public static void Köp()
        {

            Console.WriteLine("Vad vill du köpa?");
            var köp = Console.ReadLine();


            Console.WriteLine("Vilken storlek?");
            var storlek = Console.ReadLine();

            Console.WriteLine("Antal?");
            var antal = Console.ReadLine();

            Console.WriteLine("Vad vill du ha för leveranssätt?");
            var leveransSätt = Console.ReadLine();

            Console.WriteLine("Hur vill du betala?");
            var betalning = Console.ReadLine();




        }
    }
}
