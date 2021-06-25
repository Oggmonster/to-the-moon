using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class Map
    {
        private static string title = @"
 _______  __   __  _______  _______  _______  _______    __   __  _______  __   __  ______      _______  _______  _______  __   __ 
|       ||  | |  ||       ||       ||       ||       |  |  | |  ||       ||  | |  ||    _ |    |       ||   _   ||       ||  | |  |
|       ||  |_|  ||   _   ||   _   ||  _____||    ___|  |  |_|  ||   _   ||  | |  ||   | ||    |    _  ||  |_|  ||_     _||  |_|  |
|       ||       ||  | |  ||  | |  || |_____ |   |___   |       ||  | |  ||  |_|  ||   |_||_   |   |_| ||       |  |   |  |       |
|      _||       ||  |_|  ||  |_|  ||_____  ||    ___|  |_     _||  |_|  ||       ||    __  |  |    ___||       |  |   |  |       |
|     |_ |   _   ||       ||       | _____| ||   |___     |   |  |       ||       ||   |  | |  |   |    |   _   |  |   |  |   _   |
|_______||__| |__||_______||_______||_______||_______|    |___|  |_______||_______||___|  |_|  |___|    |__| |__|  |___|  |__| |__|
";
        
        private static List<Place> GetRandomPlaces() {
            var rnd = new Random();
            var num = rnd.Next(2, 6);
            var options = new List<Place>();
            for (int i = 0; i < num; i++)
            {                
                options.Add(PlaceData.GetRandomPlace());                                
            }
            return options;
        }

        public static Place GoSomewhere(int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();            
            if (stepCount == 15) {
                var bossPlace = PlaceData.GetRandomBossPlace();
                Console.WriteLine(bossPlace.ToString());
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                return bossPlace;
            }
            Console.WriteLine("You look around and see many places to travel.");
            Console.WriteLine();
            var place = ConsoleOptionPicker.PickOption<Place>(GetRandomPlaces());
            Console.Clear();
            return place;
        }
    }
}