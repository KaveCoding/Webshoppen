using DemoEFDapper;
using EF_Demo_many2many2.Migrations;
using EF_Demo_many2many2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace EF_Demo_many2many2.Metoder
{
    internal class Meny
    {
        public static void VälkomstText()
        {
            while (true)
            {
                Console.WriteLine("Välkommen! Har du ett befintligt konto: Ja/Nej?");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "ja":
                        LoggaIn();
                        break;
                    case "nej":
                        Kundmetoder.Insert.NewKund();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Felaktig inmatning");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }


        public static void LoggaIn()
        {
            Console.WriteLine("Ange epost: ");
            var epost = Console.ReadLine();
            using (var db = new MyDBContext())
            {
                var hittaAdmin = (from t in db.AdminLogins
                                  where t.Namn == epost
                                  select t).SingleOrDefault();
                if (hittaAdmin != null)
                {
                    Console.WriteLine("Ange Lösenord");
                    string lösen = Console.ReadLine();
                    if (lösen == hittaAdmin.Lösen)
                    {
                        Console.Clear();
                        Adminkör();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lösenordet är fel");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    KundKör(epost);

                }
            }
        }
        public static void VisaProdukter(int kundId)
        {
            using (var db = new MyDBContext())
            {
                GetDapperData.Hämta_kategorier();
                Console.WriteLine("Ange kategoriId: ");
                int kategoriId;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out kategoriId))
                {
                    var visaProdukter = (from p in db.Produkter
                                         where p.KategoriId == kategoriId
                                         select p);
                    Console.Clear();
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
                        Console.Clear();
                        if (visaProdukt != null)
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
                                    Kundmetoder.Insert.Varor(kundId, visaProdukt.Id, visaProdukt.Storlek, antal, summaTotal);
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");
                    Console.ReadKey();
                    Console.Clear();
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
                                Kundmetoder.Insert.Varor(kundId, visaProdukt.Id, visaProdukt.Storlek, antal, summaTotal);
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
        public static void Kassa(int kundId) 
        {
            using (var db = new MyDBContext()) 
            {
                var kundvarukorg = (from t in db.Varukorgar
                                    where t.KundId == kundId
                                    select t);
                if(kundvarukorg.Count() < 0)
                {
                    Console.WriteLine("Vad vill du ha för leveranssätt?");

                    Console.WriteLine("2 Postnord \n3 DHL\n4 Bring ");


                    var leveransSätt = Console.ReadLine();


                    Console.WriteLine("1 Kreditkort \n2 Swish\n3 Klarna ");
                    Console.WriteLine("Hur vill du betala?");
                    var betalning = Console.ReadLine();

                    foreach (var t in kundvarukorg)
                    {
                        var newBeställningar = new Beställning
                        {
                            Antal = t.ProduktAntal,
                            Summa = t.Summa,
                            Datum = DateTime.Now,
                            BetalsättId = int.Parse(betalning),
                            KundId = kundId,
                            ProduktId = t.ProduktId,
                            LeverantörId = int.Parse(leveransSätt),
                            VarukorgId = t.Id
                        };
                        var BeställningList = db.Beställningar;
                        BeställningList.Add(newBeställningar);

                    }
                    GetDapperData.Deletevarukorgar(kundId);
                    db.SaveChanges();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Varukorgen är tom.");
                    Console.ReadKey();
                    Console.Clear();
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
        enum MenuListAdmin
        {
            Lägga_till_produkter = 1,
            Uppdatera_produkter,
            Ta_bort_produkter,
            Se_Queries,
            Lägg_till_kategori,
            Lägg_till_betalsätt,
            Lägg_till_leverantör,
            Lägg_till_lagersaldo,

            Quit = 9
        }
        public static void KundKör(string epost)
        {
            using (var db = new MyDBContext())
            {
                var hittaKund = (from t in db.Kunder
                                 where t.Email == epost
                                 select t).SingleOrDefault();
                if (hittaKund != null)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen " + hittaKund.Namn);
                    var loop = true;
                    while (loop)
                    {
                        foreach (int i in Enum.GetValues(typeof(MenuListKund)))
                        {
                            Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListKund), i).Replace('_', ' ')}");
                        }
                        UtvaldProdukt();
                        int nr;
                        MenuListKund menu = (MenuListKund)99;
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menu = (MenuListKund)nr;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        switch (menu)
                        {
                            case MenuListKund.Uppdatera_konto:
                                Console.Clear();
                                Kundmetoder.Update.Kundinformation(hittaKund.Id);
                                break;
                            case MenuListKund.Visa_Historik:
                                Console.Clear();
                                Kundmetoder.Read.Historik((hittaKund.Id));
                                break;
                            case MenuListKund.Visa_produkter:
                                Console.Clear();
                                VisaProdukter(hittaKund.Id);
                                break;
                            case MenuListKund.Sök_efter_produkt:
                                Console.Clear();
                                Sök(hittaKund.Id);
                                break;
                            case MenuListKund.Visa_varukorg:
                                Console.Clear();
                                Kundmetoder.Read.Varukorg((hittaKund.Id));
                                break;
                            case MenuListKund.Gå_till_beställning:
                                Console.Clear();
                                Kassa(hittaKund.Id);
                                break;
                            case MenuListKund.Logga_ut:
                                Console.Clear();
                                loop = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Fel inmatning");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Existerar inte");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
                
            
        }
        public static void Adminkör()
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
                        Adminmetoder.Insert.Produktvärden();
                        break;
                    case MenuListAdmin.Uppdatera_produkter:
                        Adminmetoder.Update.Produkt();
                        break;
                    case MenuListAdmin.Ta_bort_produkter:
                        Adminmetoder.Delete.Produkt();
                        break;
                    case MenuListAdmin.Se_Queries:
                        Console.Clear();
                        GetDapperData.HämtaBästSäljareProdukt();
                        Console.WriteLine("-----------------------------");
                        GetDapperData.LagerStatusQuery();
                        Console.WriteLine("-----------------------------");
                        GetDapperData.HämtaBästSäljareKategori();
                        Console.WriteLine("-----------------------------");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case MenuListAdmin.Lägg_till_kategori:
                        Adminmetoder.Insert.Kategori();
                        break;
                    case MenuListAdmin.Lägg_till_betalsätt:
                        Adminmetoder.Insert.Betalsätt();
                        break;
                    case MenuListAdmin.Lägg_till_leverantör:
                        Adminmetoder.Insert.Leverantör();
                        break;
                    case MenuListAdmin.Lägg_till_lagersaldo:
                        Adminmetoder.Insert.LagerStatus();
                        break;
                    case MenuListAdmin.Quit:
                        loop = false;
                        break; 
                }
            }
        }
        public static void UtvaldProdukt()
        {
            using (var db = new MyDBContext())
            {
                var hittaUtvald = (from p in db.Produkter
                                   where p.UtvaldProdukt == true
                                   select p);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("SUPERREA!!!!");
                foreach(var p in hittaUtvald)
                {
                    Console.WriteLine($"{p.Namn} - {p.Info} - NU ENDAST {p.Pris} SEK!");
                }
                Console.ResetColor();
            }
        }
    }
}


   
