namespace SakilaMovieActorsDEMO
{
    internal class ConsoleApp(DataAccess dataAccess)
    {
        private readonly DataAccess _dataAccess = dataAccess;
        private bool _running = true;

        public void Start()
        {
            while (_running)
            {
                Console.Clear();
                Console.Write(
                    "Enter 'e' to exit\n" +
                    "\n" +
                    "Enter an actors name to list the movies they have acted in:\n");

                string input = Console.ReadLine() ?? "";

                if (input == "e")
                {
                    _running = false;
                    Console.Clear();
                    return;
                }

                IEnumerable<string>? actorMovies = _dataAccess.GetActorMovies(input);

                if (actorMovies == null)
                {
                    ActorDoesNotExistErrorMessage(input);
                    ContinueMessage();
                    Console.ReadKey();
                    continue;
                }

                WriteMoviesToConsole(input, actorMovies);
                ContinueMessage();
                Console.ReadKey();
            }
        }

        private static void ActorDoesNotExistErrorMessage(string actorName)
        {
            Console.Clear();
            Console.Write($"Actor '{actorName}' does not exist\n");
        }

        private static void WriteMoviesToConsole(string actorName, IEnumerable<string>? actorMovies)
        {
            ArgumentNullException.ThrowIfNull(actorMovies);

            Console.Clear();

            if (actorMovies.Count() == 1)
            {
                Console.Write($"Actor {actorName} has acted in the movie {actorMovies.First()}\n");
                return;
            }
            
            Console.Write($"Actor {actorName} has acted in these movies:\n");

            foreach (string movieName in actorMovies)
            {
                Console.Write($"  {movieName}\n");
            }
        }

        private static void ContinueMessage()
        {
            Console.Write(
                    "\n" +
                    "Press any button to continue\n");
        }
    }
}
