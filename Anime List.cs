public class AnimeList
{
    public static void Main(string[] args)
    {
        Menu();
    }


    static void Menu()
    {
        Console.WriteLine("1. WatchList");
        Console.WriteLine("2. Done/Watched");
        Console.WriteLine("3. Dropped");
        Console.WriteLine("4. Quit");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                WatchList();
                break;
            case 2:
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

    static void WatchList()
    {
        Console.WriteLine("Type the anime you want to watch");
        string anime = Console.ReadLine()!;

        string file = "WatchList.txt";
        File.AppendAllText(file, anime + Environment.NewLine);
    }


}