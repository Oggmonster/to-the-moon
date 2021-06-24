using System;
namespace to_the_moon
{
    public class CampFire
    {
        private static string title = @"
 _______  _______  __   __  _______  _______  ___   ______    _______ 
|       ||   _   ||  |_|  ||       ||       ||   | |    _ |  |       |
|       ||  |_|  ||       ||    _  ||    ___||   | |   | ||  |    ___|
|       ||       ||       ||   |_| ||   |___ |   | |   |_||_ |   |___ 
|      _||       ||       ||    ___||    ___||   | |    __  ||    ___|
|     |_ |   _   || ||_|| ||   |    |   |    |   | |   |  | ||   |___ 
|_______||__| |__||_|   |_||___|    |___|    |___| |___|  |_||_______|
";
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

    }
}