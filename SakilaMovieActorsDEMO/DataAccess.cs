using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SakilaMovieActorsDEMO
{
    internal class DataAccess
    {
        private readonly string? _connectionString;

        public DataAccess()
        {
            _connectionString = new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json")
                               .Build()
                               .GetConnectionString("Sakila");
        }

        public bool CheckDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new(_connectionString))
                {
                    connection.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
                return false;
            }
        }

        public List<string>? GetActorMovies(string actorFirstName, string actorLastName)
        {
            List<string> movies = [];

            string sql = $"select film.title from ( select actor_id from actor where actor.first_name = '{actorFirstName.ToUpper()}' and actor.last_name = '{actorLastName.ToUpper()}' ) as selected_actor inner join film_actor on selected_actor.actor_id = film_actor.actor_id inner join film on film_actor.film_id = film.film_id";
            
            using (SqlConnection connection = new(_connectionString))
            using (SqlCommand cmd = new(sql, connection))
            {
                connection.Open();

                using SqlDataReader reader = cmd.ExecuteReader();

                foreach (string movie in Helper.GetStringsFromReader(reader))
                {
                    movies.Add(Helper.CapitalizeFirstLetters(movie));
                }
            }

            return movies.Count != 0 ? movies : null;
        }
    }
}
