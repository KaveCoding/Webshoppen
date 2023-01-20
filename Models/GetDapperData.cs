using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Demo_many2many2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DemoEFDapper
{
    public class GetDapperData
    {
       
        public static void Deletevarukorgar(int kundId)
        {
            string connString = "Server=tcp:eliasanghnaeh.database.windows.net,1433;Initial Catalog=WebbshoppGrupp8Eskilstuna;Persist Security Info=False;User ID=Group8;Password=Ourpasswordis100%secure;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            var sql = $"delete from Varukorgar where KundId = {kundId} ";
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    connection.Execute(sql);
                    connection.Close();
                }

            }
        }        
    }
}

