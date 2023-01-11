using DemoEFDapper;
using EF_Demo_many2many2.Migrations;
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
        public static void VisaProdukter(int kundId)
        {
            using (var db = new MyDBContext())
            {
                GetDapperData.Hämta_kategorier();
                Console.WriteLine("Ange kategoriId: ");
                var kategoriId = Console.ReadLine();
                var visaProdukter = (from p in db.Produkter
                                     where p.KategoriId == int.Parse(kategoriId)
                                     select p);
                if (visaProdukter != null)
                {
                    foreach (var t in visaProdukter)
                    {
                        Console.WriteLine(t.Namn + " " + t.Id);
                    }
                    Console.WriteLine("Ange produktId: ");
                    var produktId = Console.ReadLine();
                    var visaProdukt = (from p in db.Produkter
                                         where p.Id == int.Parse(produktId)
                                         select p).SingleOrDefault();
                    if(visaProdukt != null)
                    {
                        Console.WriteLine($"Namn: {visaProdukt.Namn}  Storlek: {visaProdukt.Storlek}  Pris: {visaProdukt.Pris}  Detaljerad information: {visaProdukt.Info}");
                        Console.WriteLine("Vill du lägga till i varukorg? Ja/Nej");
                        var input = Console.ReadLine().ToLower();
                        Console.WriteLine("Antal?");
                        var antal = int.Parse(Console.ReadLine());
                        float summaTotal = antal * visaProdukt.Pris;
                        switch (input)
                        {
                            case "ja":
                                LäggTillVarukorg(kundId, visaProdukt.Id, visaProdukt.Storlek, antal, summaTotal);
                                break;
                            case "nej":
                                Console.WriteLine("Ej tillagd.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Fel inmatning!");
                }
            }
        }
        public static void Sök(int kundId)
        {
            Console.WriteLine("Ange sökord: ");
            var sökord = Console.ReadLine();
            using (var db = new MyDBContext())
            {
                var hittaProdukt = (from t in db.Produkter
                                 where t.Namn.Contains(sökord)
                                 select t);
                if(hittaProdukt != null)
                {
                    foreach (var p in hittaProdukt)
                    {
                        Console.WriteLine(p.Namn + " " + p.Id);
                    }
                    Console.WriteLine("Ange produktId: ");
                    var produktId = Console.ReadLine();
                    var visaProdukt = (from p in db.Produkter
                                       where p.Id == int.Parse(produktId)
                                       select p).SingleOrDefault();
                    if (visaProdukt != null)
                    {
                        Console.WriteLine($"Namn: {visaProdukt.Namn}  Storlek: {visaProdukt.Storlek}  Pris: {visaProdukt.Pris}  Detaljerad information: {visaProdukt.Info}");
                        Console.WriteLine("Vill du lägga till i varukorg? Ja/Nej");
                        var input = Console.ReadLine().ToLower();
                       
                        switch (input)
                        {
                            case "ja":
                                Console.WriteLine("Antal?");
                                var antal = int.Parse(Console.ReadLine());
                                float summaTotal = antal * visaProdukt.Pris;
                                LäggTillVarukorg(kundId, visaProdukt.Id, visaProdukt.Storlek, antal, summaTotal);
                                break;
                            case "nej":
                                Console.WriteLine("Ej tillagd.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                    }
                }
            }
        }
        public static void VisaHistorik(int kundId)
        {

        }
        public static void VisaVarukorg(int kundId)
        {

        }
        public static void Kassa(int kundId)
        {

        }
        public static void LäggTillVarukorg(int kundId, int produktId, string produktStorlek, int produktAntal, float summa)
        {
            using (var db = new MyDBContext())
            {
                var newVarukorg = new Varukorg
                {
                    KundId = kundId,
                    ProduktId = produktId,
                    ProduktStorlek = produktStorlek,
                    ProduktAntal = produktAntal,
                    Summa = summa
                };
                var VarukorgList = db.Varukorgar;
                VarukorgList.Add(newVarukorg);
                db.SaveChanges();
            }
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
        public static void UpdateKund(int id)
        {
            using (var db = new MyDBContext())
            {
                var updateKund = (from t in db.Kunder
                                  where t.Id == id
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
        enum MenuListKund
        {
            Uppdatera_konto = 1,
            Visa_Historik,
            Visa_produkter,
            Sök_efter_produkt,
            Visa_varukorg,
            Gå_till_beställning,
            
            Logga_ut = 9
        }
        public static void VälkomstText() //Fixa idiotsäkert
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
                    else
                    {
                        using (var db = new MyDBContext())
                        {
                            var hittaKund = (from t in db.Kunder
                                              where t.Email == epost
                                              select t).SingleOrDefault();
                            if (hittaKund != null)
                            {
                                var loop = true;
                                while(loop)
                                {
                                    foreach (int i in Enum.GetValues(typeof(MenuListKund)))
                                    {
                                        Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListKund), i).Replace('_', ' ')}");
                                    }
                                    int nr;
                                    MenuListKund menu = (MenuListKund)99;
                                    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                                    {
                                        menu = (MenuListKund)nr;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Fel inmatning");

                                    }
                                    switch (menu)
                                    {
                                        case MenuListKund.Uppdatera_konto:
                                            UpdateKund(hittaKund.Id);
                                            break;
                                        case MenuListKund.Visa_Historik:
                                            VisaHistorik(hittaKund.Id);
                                            break;
                                        case MenuListKund.Visa_produkter:
                                            VisaProdukter(hittaKund.Id);
                                            break;
                                        case MenuListKund.Sök_efter_produkt:
                                            Sök(hittaKund.Id);
                                            break;
                                        case MenuListKund.Visa_varukorg:
                                            VisaVarukorg(hittaKund.Id);
                                            break;
                                        case MenuListKund.Gå_till_beställning:
                                            Kassa(hittaKund.Id);
                                            break;
                                        case MenuListKund.Logga_ut:
                                            loop = false;
                                            break;
                                    }
                                }                               
                            }
                        }
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

        enum MenuListAdmin
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
                foreach (int i in Enum.GetValues(typeof(MenuListAdmin)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListAdmin), i).Replace('_', ' ')}"); // samma sak som ovan och lägg till replcae för att få med mellan slag
                }
                int nr;
                MenuListAdmin menu = (MenuListAdmin)99; // Default
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (MenuListAdmin)nr;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");

                }
                switch (menu)
                {
                    case MenuListAdmin.Lägga_till_produkter:
                        Produkt();
                        break;
                    case MenuListAdmin.Uppdatera_produkter:
                        UpdateProdukt();
                        break;
                    case MenuListAdmin.Ta_bort_produkter:
                        DeleteProdukt();
                        break;
                    case MenuListAdmin.Se_beställningshistorik:
                        break;
                    case MenuListAdmin.Lägg_till_kategori:
                        Kategori();
                        break;
                    case MenuListAdmin.Lägg_till_betalsätt:
                        Betalsätt();
                        break;
                    case MenuListAdmin.Lägg_till_leverantör:
                        Leverantör();
                        break;
                    case MenuListAdmin.Lägg_till_lagersaldo:
                        LagerStatus();
                        break;
                    case MenuListAdmin.Quit:
                        loop = false;
                        break;
                }
            }
        }
    }
}


   
