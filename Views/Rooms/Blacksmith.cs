using System;
namespace to_the_moon
{
    public class Blacksmith
    {
        private static string title = @"
 _______  ___      _______  _______  ___   _  _______  __   __  ___   _______  __   __ 
|  _    ||   |    |   _   ||       ||   | | ||       ||  |_|  ||   | |       ||  | |  |
| |_|   ||   |    |  |_|  ||       ||   |_| ||  _____||       ||   | |_     _||  |_|  |
|       ||   |    |       ||       ||      _|| |_____ |       ||   |   |   |  |       |
|  _   | |   |___ |       ||      _||     |_ |_____  ||       ||   |   |   |  |       |
| |_|   ||       ||   _   ||     |_ |    _  | _____| || ||_|| ||   |   |   |  |   _   |
|_______||_______||__| |__||_______||___| |_||_______||_|   |_||___|   |___|  |__| |__|
";

//upgrade card
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

    }
}