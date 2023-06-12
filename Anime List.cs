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
                string file = "WatchList.txt";

                switch (choice)
                {
                    case 1:
                        WatchList(file);
                        break;
                    case 2:
                        DoneList(file);
                        break;
                    case 3:
                        DroppedList(file);
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

    static void WatchList(string file)
    {
        ShowAnimeList(file);

        string anime = InputAnime();

        bool inList = CheckAnimeOnList(anime, file);
        if (inList)
        {
            File.AppendAllText(file, anime + Environment.NewLine);
        }
    }

    static void DoneList(string file)
    {
        string doneFile = "DoneList.txt";
        ShowAnimeList(doneFile);

        string anime = InputAnime();

        DeleteAnimeName(anime, file);
        bool inWatchList = CheckAnimeOnList(anime, file);
        if (inWatchList)
        {
            bool inList = CheckAnimeOnList(anime, doneFile);
            if (inList)
            {
                File.AppendAllText(doneFile, anime + Environment.NewLine);
            }
        }
    }

    static void DroppedList(string file)
    {
        string dropFile = "DroppedList.txt";
        ShowAnimeList(dropFile);

        string anime = InputAnime();

        DeleteAnimeName(anime, file);
        bool inWatchList = CheckAnimeOnList(anime, file);
        if (inWatchList)
        {
            bool inList = CheckAnimeOnList(anime, dropFile);
            if (inList)
            {
                File.AppendAllText(dropFile, anime + Environment.NewLine);
            }
        }
    }

    static string InputAnime()
    {
        Console.Write("Anime: ");
        string anime = Console.ReadLine()!;
        return anime;
    }

    static bool CheckAnimeOnList(string anime, string file)
    {
        using (StreamReader sr = new StreamReader(file))
        {
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                if (line == anime)
                {
                    Console.WriteLine("The anime is on the list already");
                    return false;
                }
                else
                {
                    Console.WriteLine("The anime isn't on the watchlist");
                    return false;
                }
            }
        }
        return true;
    }

    static void DeleteAnimeName(string anime, string file)
    {
        Regex regex = new Regex(anime);
        using (StreamWriter sw = new StreamWriter(file))
        {
            string content = regex.Replace(anime, string.Empty);
            sw.Write(content);
        }
    }

    static void ShowAnimeList(string file)
    {
        string line;

        using (StreamReader sr = new StreamReader(file))
        {
            while ((line = sr.ReadLine()!) != null)
            {
                if (line == null)
                {
                    Console.WriteLine("There is no anime in this list");
                }
                Console.WriteLine(line);
            }
        }
    }
}