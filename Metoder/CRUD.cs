using DemoEFDapper;
using EF_Demo_many2many2.Migrations;
using EF_Demo_many2many2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

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
            using (var db = new MyDBContext())
            {
                var visaHistorik = (from h in db.Beställningar
                                    where h.KundId == kundId
                                    select h);
                var counter = 1;
                Console.Clear();
                foreach (var t in visaHistorik)
                {
                    Console.WriteLine($" Beställningsnummer: {counter} BeställningsId: {t.Id} ProduktId: {t.ProduktId} Antal: {t.Antal} Summa: {t.Summa} VarukorgId: {t.VarukorgId} Betalsätt: {t.BetalsättId} LeverantörId: {t.LeverantörId} KundId: {t.KundId}");
                    counter++;
                }
                Console.ReadKey();
                                Console.Clear();
            }
        }
        public static void VisaVarukorg(int kundId)
        {
            using (var db = new MyDBContext())
            {
                int switcher;
                var visaVarukorg = (from p in db.Varukorgar
                                    where p.KundId == kundId
                                    select p);

                var counter = 1;
                Console.Clear();
                foreach (var t in visaVarukorg)
                    {
                        Console.WriteLine($" Varukorg: {counter} ProduktId: {t.ProduktId} Antal: {t.ProduktAntal} Storlek: {t.ProduktStorlek} Summa: {t.Summa}");
                    counter++;
                    }
                Console.WriteLine("[1] Vill du ändra antal på en produkt");
                Console.WriteLine("[2] Vill du ta bort en produkt");
                Console.WriteLine("[3] Gå tillbaka");
                switcher = int.Parse(Console.ReadLine());
                switch (switcher)
                {
                    case 1:
                        UpdateVarukorg(kundId);
                        break;
                    case 2:
                        DeleteProductVaruKorg(kundId);
                        break;
                    default:
                        break;
                }


                Console.ReadKey();
                Console.Clear();

            }

        }
        public static void UpdateVarukorg(int kundID)
        {
            using (var db = new MyDBContext())
            {
                Console.WriteLine("Vilken produkt vill du uppdatera? (Ange ProduktID)");
                int nr;
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    var visaVarukorg = (from p in db.Varukorgar
                                        where p.ProduktId == nr
                                        select p).SingleOrDefault();
                    if (visaVarukorg != null && visaVarukorg.KundId == kundID)
                    {
                        Console.WriteLine("Produkt Antal: ");
                        var antal = int.Parse(Console.ReadLine());
                        visaVarukorg.ProduktAntal = antal;
                        db.SaveChanges();
                    }
                    }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }
            }
        }
        public static void DeleteProductVaruKorg(int kundID)
        {

            Console.Write("Ange Id att ta bort: ");
            int nr;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
            {
                using (var db = new MyDBContext())
                {
                    var deleteProdukt = (from t in db.Varukorgar
                                         where t.ProduktId == nr
                                         select t).SingleOrDefault();

                    if (deleteProdukt != null && deleteProdukt.KundId == kundID)
                    {
                        db.Varukorgar.Remove((Varukorg)deleteProdukt);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning");
            }

        }


        public static void Kassa(int kundId) //fixa idioti sen
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
            int produktUpdate;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out produktUpdate))
            {
                using (var db = new MyDBContext())
                {
                    var updateProdukt = (from t in db.Produkter
                                         where t.Id == produktUpdate
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
                        switch (utvald)
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
                        Console.Clear();
                        Console.WriteLine("Lyckad uppdatering av produkt");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Finns inte");
                        Console.ReadKey();
                        Console.Clear();
                    }
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
            int produktDelete;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out produktDelete))
            {
                using (var db = new MyDBContext())
                {
                    var deleteProdukt = (from t in db.Produkter
                                         where t.Id == produktDelete
                                         select t).SingleOrDefault();
                    if (deleteProdukt != null)
                    {
                        db.Produkter.Remove((Produkt)deleteProdukt);
                        db.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("Produkten har blivit deletad");
                        Console.ReadKey();
                        Console.Clear();
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
            else
            {
                Console.Clear();
                Console.WriteLine("Fel inmatning");
                Console.ReadKey();
                Console.Clear();
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
            while (true)
            {
                Console.WriteLine("Välkommen! Har du ett befintligt konto: Ja/Nej?");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "ja":
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
                                    AdminDo();
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
                                                    UpdateKund(hittaKund.Id);
                                                    break;
                                                case MenuListKund.Visa_Historik:
                                                    Console.Clear();
                                                    VisaHistorik(hittaKund.Id);
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
                                                    VisaVarukorg(hittaKund.Id);
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
                        break;

                    case "nej":
                        Kund();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
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
        public static void Queries()
        {
            using (var db = new MyDBContext())
            {
                var bästSäljare = (from h in db.Beställningar
                                   orderby h.ProduktId descending
                                   select h);
            }
        }
    }
}


   
