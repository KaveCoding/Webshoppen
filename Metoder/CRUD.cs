using EF_Demo_many2many2.Models;
using Microsoft.EntityFrameworkCore;

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
        public static void UpdateProdukt() //Fixa idiotsäkert
        {
            Console.WriteLine("Ange produktId att uppdatera: ");
            var produktUpdate = Console.ReadLine();
            using (var db = new MyDBContext())
            {
                var updateProdukt = (from t in db.Produkter
                                  where t.Id == int.Parse(produktUpdate)
                                  select t).SingleOrDefault();
                if (updateProdukt != null)
                {
                    Console.WriteLine("Namn: ");
                    var namn = Console.ReadLine();
                    updateProdukt.Namn = namn;
                    Console.WriteLine("Storlek: ");
                    var storlek = Console.ReadLine();
                    updateProdukt.Storlek = storlek;
                    Console.WriteLine("Pris: ");
                    var pris = float.Parse(Console.ReadLine());
                    updateProdukt.Pris = pris;
                    Console.WriteLine("Info: ");
                    var info = Console.ReadLine();
                    updateProdukt.Info = info;
                    Console.WriteLine("Utvald produkt? Ja/Nej");
                    var utvald = Console.ReadLine().ToLower();
                    switch(utvald)
                    {
                        case "ja":
                            updateProdukt.UtvaldProdukt = true;
                            break;
                        case "nej":
                            updateProdukt.UtvaldProdukt = false;
                            break;
                        default:
                            updateProdukt.UtvaldProdukt = false;
                            break;
                    }
                    Console.WriteLine("LeverantörId: ");
                    var leverantörId = int.Parse(Console.ReadLine());
                    updateProdukt.LeverantörId = leverantörId;
                    Console.WriteLine("KategoriId: ");
                    var kategoriId = int.Parse(Console.ReadLine());
                    updateProdukt.KategoriId = kategoriId;
                    db.SaveChanges();
                }
            }
        }
        public static void UpdateKund()
        {
            Console.WriteLine("Ange kundId att uppdatera: ");
            var kundUpdate = Console.ReadLine();
            using (var db = new MyDBContext())
            {
                var updateKund = (from t in db.Kunder
                                  where t.Id == int.Parse(kundUpdate)
                                  select t).SingleOrDefault();
                if (updateKund != null)
                {
                    Console.WriteLine("Namn: ");
                    var namn = Console.ReadLine();
                    updateKund.Namn = namn;
                    Console.WriteLine("Gatunamn: ");
                    var gatuNamn = Console.ReadLine();
                    updateKund.GatuNamn = gatuNamn;
                    Console.WriteLine("Stad: ");
                    var stad = Console.ReadLine();
                    updateKund.Stad = stad;
                    Console.WriteLine("Land: ");
                    var land = Console.ReadLine();
                    updateKund.Land = land;
                    Console.WriteLine("Telefonnummer: ");
                    var telefonNummer = Console.ReadLine();
                    updateKund.TelefonNummer = telefonNummer;
                    db.SaveChanges();
                }
            }
        } //Fixa idiotsäkert
        public static void DeleteProdukt() //Fixa idiotsäkert
        {
            Console.Write("Ange Id att ta bort: ");
            var produktDelete = Console.ReadLine();
            using (var db = new MyDBContext())
            {
                var deleteProdukt = (from t in db.Produkter
                                  where t.Id == int.Parse(produktDelete)
                                  select t).SingleOrDefault();
                if (deleteProdukt != null)
                {
                    db.Produkter.Remove((Produkt)deleteProdukt);
                    db.SaveChanges();
                }
            }
        }
        public static void VälkomstText()
        {
            Console.WriteLine("Välkommen! Har du ett befintligt konto: Ja/Nej?");
            var input = Console.ReadLine().ToLower();
            switch(input)
            {
                case "ja":
                    Console.WriteLine("Ange epost: ");
                    var epost = Console.ReadLine();
                    if(epost.Contains("admin") == true)
                    {
                        AdminDo();
                    }

                    break;

                case "nej":
                    Kund();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    break;
            }
        }

        enum MenuList
        {
            Lägga_till_produkter = 1,
            Uppdatera_produkter,
            Ta_bort_produkter,
            Se_beställningshistorik,
            Lägg_till_kategori,
            Lägg_till_betalsätt,
            Lägg_till_leverantör,
            Lägg_till_lagersaldo,

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
                        Produkt();
                        break;
                    case MenuList.Uppdatera_produkter:
                        UpdateProdukt();
                        break;
                    case MenuList.Ta_bort_produkter:
                        DeleteProdukt();
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


   
