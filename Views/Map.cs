using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class Map
    {
        //at 15 = boss - 14 campfire, 7 campfire - 9 = treasure
        private static Dictionary<int, RoomType> fixedRooms = new Dictionary<int, RoomType> {
                {15, RoomType.Combat},
                {14, RoomType.CampFire},            
                {7, RoomType.CampFire},
                {9, RoomType.Treasure},
                {1, RoomType.Combat}
            };
        private static Dictionary<string, RoomType> options = new Dictionary<string, RoomType>
        {
            {"Hidden treasure", RoomType.Treasure},
            {"Combat", RoomType.Combat},
            {"Anything can happen", RoomType.Chance},
            {"Merchant", RoomType.Merchant}
        };

        private static List<string> GetRandomOptions() {
            //make these random
            return options.Select(o => o.Key).ToList();
        }

        public static RoomType GetARoom(int stepCount) {            
            if (fixedRooms.ContainsKey(stepCount)) {
                return fixedRooms[stepCount];
            }
            Console.WriteLine("Where do you want to go?");
            var option = ConsoleOptionPicker.PickOption<string>(GetRandomOptions());
            return options[option];
        }
    }
}