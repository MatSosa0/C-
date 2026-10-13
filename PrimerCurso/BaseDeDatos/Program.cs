using System;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DB db = new DB(@"DESKTOP-NJB8MT2\SQLEXPRESS", "csharpDB", "admin", "123");
                db.Connect();

                db.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("No pudimos conectarnos");
            }
        }
    }
}