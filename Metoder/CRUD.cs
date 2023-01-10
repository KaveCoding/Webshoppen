using EF_Demo_many2many2.Models;

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
        public static void InsertLagerStatus(int saldo, int produktId)
        {
            using (var db = new MyDBContext()) // insert
            {
                var newLagerstatus = new LagerStatus
                {
                    Saldo = saldo,
                    Tillgänglig = true,
                    ProduktId = produktId

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
        public static void InsertBetalsätt(string namn)
        {
            using (var db = new MyDBContext()) // insert
            {
                var newBetalsätt = new Betalsätt()
                {
                    Namn = namn
                };
                var BetalsättList = db.Betalsätter;
                BetalsättList.Add(newBetalsätt);
                db.SaveChanges();
            }
        }
        public static void InsertKategori(string namn)
        {
            using (var db = new MyDBContext())
            {
                var newKategori = new Kategori()
                {
                    Namn = namn
                };
                var KategoriList = db.Kategorier;
                KategoriList.Add(newKategori);
                db.SaveChanges();
            }
        }
        public static void InsertLeverantör(string namn, float pris, int leveransTid)
        {
            using (var db = new MyDBContext())
            {
                var newLeverantör = new Leverantör()
                {
                    Namn = namn,
                    Pris = pris,
                    LeveransTid = leveransTid
                };
                var LeverantörList = db.Leverantörer;
                LeverantörList.Add(newLeverantör);
                db.SaveChanges();
            }
        }
        public static void InsertProdukt(string namn, string storlek, float pris, string info, int leverantörId, int kategoriId)
        {
            using (var db = new MyDBContext())
            {
                var newProdukt = new Produkt()
                {
                    Namn = namn,
                    Storlek = storlek,
                    Pris = pris,
                    Info = info,
                    UtvaldProdukt = false,
                    LeverantörId = leverantörId,
                    KategoriId = kategoriId
                };
                var ProduktList = db.Produkter;
                ProduktList.Add(newProdukt);
                db.SaveChanges();
            }
        }
        public static void LagerStatus()
        {
            Console.WriteLine("Saldo: ");
            var saldo = int.Parse(Console.ReadLine());
            Console.WriteLine("ProduktId: ");
            var produktId = int.Parse(Console.ReadLine());

            InsertLagerStatus(saldo, produktId);
        }
        public static void Betalsätt()
        {
            Console.WriteLine("Namn: ");
            var namn = Console.ReadLine();

            InsertBetalsätt(namn);
        }
        public static void Leverantör()
        {
            Console.WriteLine("Namn: ");
            var namn = Console.ReadLine();
            Console.WriteLine("Pris: ");
            var pris = float.Parse(Console.ReadLine());
            Console.WriteLine("Leveranstid: ");
            var leveransTid = int.Parse(Console.ReadLine());

            InsertLeverantör(namn, pris, leveransTid);
        }
        public static void Kategori()
        {
            Console.WriteLine("Namn: ");
            var namn = Console.ReadLine();

            InsertKategori(namn);
        }
        public static void Produkt()
        {
            Console.WriteLine("Namn: ");
            var namn = Console.ReadLine();
            Console.WriteLine("Storlek: ");
            var storlek = Console.ReadLine();
            Console.WriteLine("Pris: ");
            var pris = float.Parse(Console.ReadLine());
            Console.WriteLine("Info: ");
            var info = Console.ReadLine();
            Console.WriteLine("LeverantörId: ");
            var leverantörId = int.Parse(Console.ReadLine());
            Console.WriteLine("KategoriId: ");
            var kategoriId = int.Parse(Console.ReadLine());

            InsertProdukt(namn, storlek, pris, info, leverantörId, kategoriId);
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

        enum MenuList
        {
            Lägga_till_produkter = 1,
            Uppdatera_produkter,
            Ta_bort_produkter,
            Ändra_kunduppgifter,
            Se_beställningshistorik,
            Lägg_till_kategori,
            Lägg_till_betalsätt,
            Lägg_till_leverantör,
            Lägg_till_lagersaldo,

            Quit = 'Q'
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
                        Produkt();
                        break;
                    case MenuList.Uppdatera_produkter:

                        break;
                    case MenuList.Ta_bort_produkter:

                        break;
                    case MenuList.Ändra_kunduppgifter:

                        break;
                    case MenuList.Se_beställningshistorik:

                        break;
                    case MenuList.Lägg_till_kategori:
                        Kategori();
                        break;
                    case MenuList.Lägg_till_betalsätt:
                        Betalsätt();
                        break;
                    case MenuList.Lägg_till_leverantör:
                        Leverantör();
                        break;
                    case MenuList.Lägg_till_lagersaldo:
                        LagerStatus();
                        break;
                }
            }
        }
    }
}


   
