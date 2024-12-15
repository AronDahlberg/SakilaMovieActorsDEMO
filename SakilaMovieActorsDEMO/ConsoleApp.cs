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
                    "Enter an actors full name to list the movies they have acted in:\n");

                string input = Console.ReadLine() ?? "";

                if (input == "e")
                {
                    _running = false;
                    Console.Clear();
                    return;
                }

                string[] splitInput = input.Split(' ');
                string actorFirstName = splitInput[0];
                string actorLastName = string.Join(' ', splitInput.Skip(1));

                List<string>? actorMovies = _dataAccess.GetActorMovies(actorFirstName, actorLastName);

                if (actorMovies == null)
                {
                    Console.Clear();
                    Console.Write($"{Helper.CapitalizeFirstLetters(input)} does not exist or has not been in any movies\n");

                    Helper.ContinueMessage();
                    Console.ReadKey();

                    continue;
                }

                Helper.WriteMoviesToConsole(Helper.CapitalizeFirstLetters(input), actorMovies);

                Helper.ContinueMessage();
                Console.ReadKey();
            }
        }
    }
}
