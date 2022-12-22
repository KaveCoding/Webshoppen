﻿using EF_Demo_many2many2.Models;

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
        public static void Admin()
        {
            Console.WriteLine("PRODUKTER");
            Console.WriteLine("     Lägga till produkter: ");
            Console.WriteLine("     Uppdatera produkter: ");
            Console.WriteLine("     Ta bort produkt: ");

            Console.WriteLine("KUND");
            Console.WriteLine("     Ändra kunduppgifter: ");
            Console.WriteLine("     Se beställningshistorik: ");
        }

        enum MenuList
        {
            Lägga_till_produkter = 1,
            Uppdatera_produkter,
            Ta_bort_produkter,
            Ändra_kunduppgifter,
            Se_beställningshistorik,

            Quit = 9
        }
        public static void AdminDo()
        {
            bool loop = true;
            while (loop)
            {
                foreach (int i in Enum.GetValues(typeof(MenuList)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuList), i).Replace('_', ' ')}"); // samma sak som ovan och lägg till replcae för att få med mellan slag
                }
                int nr;
                MenuList menu = (MenuList)99; // Default
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (MenuList)nr;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");

                }
                switch (menu)
                {
                    case MenuList.Lägga_till_produkter:

                        break;
                    case MenuList.Uppdatera_produkter:

                        break;
                    case MenuList.Ta_bort_produkter:

                        break;
                    case MenuList.Ändra_kunduppgifter:

                        break;
                    case MenuList.Se_beställningshistorik:

                        break;
                }
            }
            static void Köp()
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
}


   
