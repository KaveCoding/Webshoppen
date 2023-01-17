using EF_Demo_many2many2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Metoder
{
    public class Kundmetoder
    {
        public class Insert: Kundmetoder
        {
            public static void NewKund()
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

                KundVärden(namn, gatuNamn, stad, land, personNummer, telefonNummer, email);

            }

            public static void KundVärden(string namn, string gatuNamn, string stad, string land, string personNummer, string telefonNummer, string email)
            {

                using (var db = new MyDBContext())
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
                    var deleteKundId = (from TDL in db.Kunder
                                        where TDL.Id == 1
                                        select TDL).SingleOrDefault();
                    if (deleteKundId != null)
                    {
                        db.Kunder.Remove((Kund)deleteKundId);
                        db.SaveChanges();
                    }
                }
            }

            public static void Varor (int kundId, int produktId, string produktStorlek, int produktAntal, float summa)
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
        }


       public class Update : Kundmetoder
        {
            public static void Kundinformation(int id)
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
            }

            public static void Varukorg(int kundID)
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
        }

        public class Read: Kundmetoder
        {
            public static void Historik(int kundId)
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

            public static void Varukorg(int kundId)
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
                    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out switcher))
                    {
                        switch (switcher)
                        {
                            case 1:
                                Update.Varukorg((kundId));
                                break;
                            case 2:
                                Delete.ProduktVaruKorg(kundId);
                                break;
                            default:
                                break;
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Fel inmatning.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        public class Delete : Kundmetoder
        {
            public static void ProduktVaruKorg(int kundID)
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
                            Console.Clear();
                            Console.WriteLine("Existerar inte.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
