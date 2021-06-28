using System;
namespace to_the_moon
{
    public class Chance
    {
        private static string title = @"
 __   __  __   __  _______  _______  _______  ______    __   __    ______    _______  _______  __   __ 
|  |_|  ||  | |  ||       ||       ||       ||    _ |  |  | |  |  |    _ |  |       ||       ||  |_|  |
|       ||  |_|  ||  _____||_     _||    ___||   | ||  |  |_|  |  |   | ||  |   _   ||   _   ||       |
|       ||       || |_____   |   |  |   |___ |   |_||_ |       |  |   |_||_ |  | |  ||  | |  ||       |
|       ||_     _||_____  |  |   |  |    ___||    __  ||_     _|  |    __  ||  |_|  ||  |_|  ||       |
| ||_|| |  |   |   _____| |  |   |  |   |___ |   |  | |  |   |    |   |  | ||       ||       || ||_|| |
|_|   |_|  |___|  |_______|  |___|  |_______||___|  |_|  |___|    |___|  |_||_______||_______||_|   |_|
";
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            var mystery = Mysteries.GetRandomMystery();
            if (mystery == null) {
                Console.WriteLine("Strange. Nothing here");
            } else {
                mystery(player);
            }            
            OptionPicker.AnyKeyToContinue();
        }
    }
}