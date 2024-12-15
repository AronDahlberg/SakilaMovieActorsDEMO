using Microsoft.Extensions.Configuration;

namespace SakilaMovieActorsDEMO
{
    internal class DataAccess
    {
        private readonly string? connectionString;

        public DataAccess()
        {
            connectionString = new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json")
                               .Build()
                               .GetConnectionString("Sakila");
        }

        public IEnumerable<string> GetActorMovies(string actorName)
        {
            throw new NotImplementedException();
        }
    }
}
