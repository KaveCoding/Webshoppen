using DemoEFDapper;
using EF_Demo_many2many2.Metoder;
using EF_Demo_many2many2.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_Demo_many2many2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CRUD.InsertLagerStatus();
            //CRUD.InsertBetalsätt();
            //CRUD.InsertBeställningar();
            GetDapperData.Hämta_kategorier();
            //CRUD.InsertKategori();
            //CRUD.InsertLeverantör();
            //CRUD.InsertProdukt();
            //CRUD.Kund();


        }
    }
}