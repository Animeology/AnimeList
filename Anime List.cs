using System.Text.RegularExpressions;

public class AnimeList
{
    public static void Main(string[] args)
    {
        Menu();
    }


    static void Menu()
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("1. WatchList");
            Console.WriteLine("2. Done/Watched");
            Console.WriteLine("3. Dropped");
            Console.WriteLine("4. Quit");

            choice = Convert.ToInt32(Console.ReadLine());


            if (choice != 4)
            {
                Console.WriteLine("Type the anime");
                string anime = Console.ReadLine()!;

                string file = "WatchList.txt";

                switch (choice)
                {
                    case 1:
                        WatchList(anime, file);
                        break;
                    case 2:
                        WatchedList(anime, file);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        Menu();
                        break;
                }
            }
        }
    }

    static void WatchList(string anime, string file)
    {
        File.AppendAllText(file, anime + Environment.NewLine);
    }

    static void WatchedList(string anime, string watchFile)
    {
        string doneFile = "DoneList.txt";

        Regex regex = new Regex(anime);

        using (StreamWriter sw = new StreamWriter(watchFile))
        {
            string content = regex.Replace(anime, string.Empty);
            sw.Write(content);
        }

        File.AppendAllText(doneFile, anime + Environment.NewLine);
    }
}