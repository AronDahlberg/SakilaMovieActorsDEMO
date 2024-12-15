namespace SakilaMovieActorsDEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new();

            if (!dataAccess.CheckDatabaseConnection())
            {
                return;
            }

            ConsoleApp consoleApp = new(dataAccess);

            consoleApp.Start();
        }
    }
}
