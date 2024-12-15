namespace SakilaMovieActorsDEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new();
            ConsoleApp consoleApp = new(dataAccess);

            consoleApp.Start();
        }
    }
}
