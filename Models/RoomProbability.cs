using System;
namespace to_the_moon
{
    public class RoomProbability
    {
        public RoomType RoomType { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public bool WithinRange(int num) {
            return num >= Start && num <= End;
        }
    }
}