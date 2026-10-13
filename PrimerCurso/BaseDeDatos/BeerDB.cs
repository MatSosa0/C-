using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BaseDeDatos
{
    public class BeerDB : DB
    {
        public BeerDB(string server, string db, string user, string password) :
            base(server, db, user, password)
        {

        }

        public List<Beer> GetBeers()
        {
            Connect();
            
            List<Beer> beers = new List<Beer>();
            string query = "SELECT * FROM Beer";
            SqlCommand command = new SqlCommand(query,_connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);
                beers.Add(new Beer(id, name, brandId));
            }
            Close();
            return beers;
        }
    }
}
