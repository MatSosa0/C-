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

        public Beer Get(int id)
        {
            Connect();
            Beer beer = null;

            string query = "SELECT * FROM Beer WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandId = reader.GetInt32(2);

                beer = new Beer(id, name, brandId);
            }

            Close();

            return beer;
        }

        public void AddBeer(Beer beer)
        {
            Connect();
            string query = "INSERT INTO BEER(NAME,BRANDID)" +
                "Values(@name, @brandId)";
            SqlCommand command = new SqlCommand(query,_connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);
            command.ExecuteNonQuery();

            Close();
        }
        public void EditBeer(Beer beer)
        {
            Connect();
            string query = "Update BEER Set NAME=@name, BRANDID=@brandId WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandId", beer.BrandId);
            command.Parameters.AddWithValue("@id", beer.Id);
            command.ExecuteNonQuery();

            Close();
        }

        public void DeleteBeer(int id)
        {
            Connect();
            string query = "DELETE FROM BEER WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            Close();
        }
    }
}
