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
        //at 15 = boss - 14 campfire, 7 campfire - 9 = treasure
        private static Dictionary<int, RoomType> fixedRooms = new Dictionary<int, RoomType> {
                {15, RoomType.Combat},
                {14, RoomType.CampFire},            
                {7, RoomType.CampFire},
                {9, RoomType.Treasure},
                {1, RoomType.Combat}
            };
        private static Dictionary<int, string> fixedTexts = new Dictionary<int, string> {
                {15, "Looks like trouble ahead. Prepare to fight for your life!"},
                {14, "Sit down by the fire and rest. You will need it."},            
                {7, "Relax for a while and lick your wounds."},
                {9, "Hmm, looks like something shiny around the corner."},
                {1, "Our journey begins with a rumble. Monsters ahead!"}
            };
        private static Dictionary<string, RoomType> roomMap = new Dictionary<string, RoomType>
        {
            {"Scary monsters", RoomType.Combat},
            {"Fight for glory", RoomType.Combat},            
            {"Someone over here insulted you", RoomType.Combat},
            {"Superfreaks", RoomType.Combat},
            {"Bust a move", RoomType.Combat},
            {"Evil lurks", RoomType.Combat},
            {"Looks safe I guess", RoomType.Combat},
            {"Who dares wins", RoomType.Combat},
            {"Battle royale", RoomType.Combat},
            {"Hidden treasure", RoomType.Treasure},
            {"Something shiny", RoomType.Treasure},            
            {"Mystery room", RoomType.Chance},
            {"Anything can happen", RoomType.Chance},
            {"Take a chance", RoomType.Chance},
            {"Sidequest", RoomType.Chance},
            {"Merchant", RoomType.Merchant},
            {"Man with some stuff to sell", RoomType.Merchant},
            {"Blacksmith", RoomType.Blacksmith},
            {"Time for some upgrades", RoomType.Blacksmith}
        };

        private static List<string> GetRandomOptions() {
            var rnd = new Random();
            var max = roomMap.Count;
            var options = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var num = rnd.Next(0, max);
                var option = roomMap.ElementAt(num).Key;
                options.Add(option);                                
            }
            return options;
        }

        public static RoomType GetARoom(int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();            
            if (fixedRooms.ContainsKey(stepCount)) {
                Console.WriteLine(fixedTexts[stepCount]);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                return fixedRooms[stepCount];
            }
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine();
            var option = ConsoleOptionPicker.PickOption<string>(GetRandomOptions());
            Console.Clear();
            return roomMap[option];
        }
    }
}