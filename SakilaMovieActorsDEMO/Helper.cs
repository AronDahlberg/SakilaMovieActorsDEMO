using Microsoft.Data.SqlClient;

namespace SakilaMovieActorsDEMO
{
    internal static class Helper
    {
        public static string CapitalizeFirstLetters(string input)
        {
            return string.Join(' ', input.Split(' ')
                                         .Select(word => char.ToUpper(word[0]) + word[1..].ToLower()));
        }

        public static IEnumerable<string> GetStringsFromReader(SqlDataReader reader)
        {
            while (reader.Read())
            {
                yield return reader.GetString(0);
            }
        }

        public static void WriteMoviesToConsole(string actorName, List<string>? actorMovies)
        {
            ArgumentNullException.ThrowIfNull(actorMovies);

            Console.Clear();

            if (actorMovies.Count == 1)
            {
                Console.Write($"{actorName} has acted in the movie {actorMovies.First()}\n");
                return;
            }

            Console.Write($"{actorName} has acted in the movies:\n");

            foreach (string movieName in actorMovies)
            {
                Console.Write($"  {movieName}\n");
            }
        }

        public static void ContinueMessage()
        {
            Console.Write(
                    "\n" +
                    "Press any button to continue\n");
        }
    }
}
