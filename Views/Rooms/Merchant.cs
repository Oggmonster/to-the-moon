using System;
namespace to_the_moon
{
    public class Merchant
    {
        private static string title = @"
 __   __  _______  ______    _______  __   __  _______  __    _  _______ 
|  |_|  ||       ||    _ |  |       ||  | |  ||   _   ||  |  | ||       |
|       ||    ___||   | ||  |       ||  |_|  ||  |_|  ||   |_| ||_     _|
|       ||   |___ |   |_||_ |       ||       ||       ||       |  |   |  
|       ||    ___||    __  ||      _||       ||       ||  _    |  |   |  
| ||_|| ||   |___ |   |  | ||     |_ |   _   ||   _   || | |   |  |   |  
|_|   |_||_______||___|  |_||_______||__| |__||__| |__||_|  |__|  |___|  
";
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

    }
}