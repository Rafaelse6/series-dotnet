using Series.Classes;
using Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        AddSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        SeeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thanks for using our services");
            Console.ReadLine();
        }

        private static void DeleteSerie()
        {
            Console.Write("Choose the serie id: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.Delete(indiceSerie);
        }

        private static void SeeSerie()
        {
            Console.Write("Choose the serie id: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repository.FindById(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Choose the serie id: ");
            int serieIndex = int.Parse(Console.ReadLine());

         
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Choose the gender: ");
            int genreTyped = int.Parse(Console.ReadLine());

            Console.Write("Type the serie's title: ");
            string titleTyped = Console.ReadLine();

            Console.Write("Type the serie's start year: ");
            int yearTyped = int.Parse(Console.ReadLine());

            Console.Write("Type the serie description: ");
            string typedDescription = Console.ReadLine();

            Serie updateSerie = new Serie(id: serieIndex,
                                        genre: (Genre)genreTyped,
                                        title: titleTyped,
                                        year: yearTyped,
                                        description: typedDescription);

            repository.Update(serieIndex, updateSerie);
        }
        private static void ListSeries()
        {
            Console.WriteLine("List series");

            var lista = repository.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("No serie found.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.ReturnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitle(), (excluido ? "*Deleted*" : ""));
            }
        }

        private static void AddSerie()
        {
            Console.WriteLine("Add new serie");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Choose the gender: ");
            int genreTyped = int.Parse(Console.ReadLine());

            Console.Write("Type the serie's title: ");
            string titleTyped = Console.ReadLine();

            Console.Write("Type the serie's start year: ");
            int yearTyped = int.Parse(Console.ReadLine());

            Console.Write("Type the serie description: ");
            string typedDescription = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)genreTyped,
                                        title: titleTyped,
                                        year: genreTyped,
                                        description: typedDescription);

            repository.Add(novaSerie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("What do do you wish ? :");

            Console.WriteLine("1- List Series");
            Console.WriteLine("2- Add New Serie");
            Console.WriteLine("3- Update Serie");
            Console.WriteLine("4- Delete Serie");
            Console.WriteLine("5- See Series");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Close Window");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}