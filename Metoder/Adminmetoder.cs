using EF_Demo_many2many2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Demo_many2many2.Metoder
{
    public class Adminmetoder
    {
        public  class Insert : Adminmetoder
        {
            public static void LagerStatus()
            {
                Console.WriteLine("Saldo: ");
                var saldo = int.Parse(Console.ReadLine());
                Console.WriteLine("ProduktId: ");
                var produktId = int.Parse(Console.ReadLine());

                LagerStatusVärden(saldo, produktId);
            }
            public static void LagerStatusVärden(int saldo, int produktId)
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

            public static void Betalsättvärden(string namn)
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
            public static void Betalsätt()
            {
                Console.WriteLine("Namn: ");
                var namn = Console.ReadLine();

                Betalsättvärden(namn);
            }

            public static void Kategori()
            {
                Console.WriteLine("Namn: ");
                var namn = Console.ReadLine();

                KategoriVärden(namn);
            }
            public static void KategoriVärden(string namn)
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

            public static void Leverantör()
            {
                Console.WriteLine("Namn: ");
                var namn = Console.ReadLine();
                Console.WriteLine("Pris: ");
                var pris = float.Parse(Console.ReadLine());
                Console.WriteLine("Leveranstid: ");
                var leveransTid = int.Parse(Console.ReadLine());

                Leverantörvärden(namn, pris, leveransTid);
            }
            public static void Leverantörvärden(string namn, float pris, int leveransTid)
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

            public static void Produktvärden()
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

                Produkt(namn, storlek, pris, info, leverantörId, kategoriId);
            }
            public static void Produkt(string namn, string storlek, float pris, string info, int leverantörId, int kategoriId)
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
                    Console.Clear();
                    Console.WriteLine("Produkt tillagd.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public class Update : Adminmetoder
        {
            public static void Produkt() 
            {
                Console.WriteLine("Ange produktId att uppdatera: ");
                string inmatning = Console.ReadLine();
                int produktUpdate;
                if (int.TryParse(inmatning, out produktUpdate))
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
        }

        public class Read : Adminmetoder
        {
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
        public class Delete : Adminmetoder
        {
            public static void Produkt()
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
        }
        
    }

}
