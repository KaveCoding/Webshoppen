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
        public static void InsertKund()
        {

            //using (var db = new MyDBContext()) // insert
            //{
            //    var newKund = new Kund
            //    {
            //        Namn = "Micke",
            //        GatuNamn = "SesamsGatan",
            //        Stad = "Eskilstuna",
            //        Land = "Sverige",
            //        PersonNummer = "010424-1431",
            //        TelefonNummer = "0760106132",
            //        Email = "Mickes132@hotmail.com"
            //    };
            //    var KundList = db.Kunder;
            //    KundList.Add(newKund);
            //    db.SaveChanges();
            //}
            //using (var db = new MyDBContext()) // DELETE
            //{
            //    var deleteTodoListID = (from TDL in db.Kunder
            //                            where TDL.Id == 1
            //                            select TDL).SingleOrDefault();
            //    if (deleteTodoListID != null)
            //    {
            //        db.Kunder.Remove((Kund)deleteTodoListID);
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
