using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{
    public class Place
    {
        public string Description { get; set; }
        public PlaceType PlaceType { get; set; }
        public List<RoomProbability> RoomProbabilities { get; set; }
        public List<RoleType> MonsterTypes { get; set; }
        
        public RoomType GetRoom() {
            //random num between 0-100 and depending on placetype different rooms may have varying probability
            var rnd = new Random();
            var num = rnd.Next(0, 100);
            var roomProbability = RoomProbabilities.First(r => r.WithinRange(num));
            return roomProbability.RoomType;
        }

        public List<Monster> GetMonsters(int level, int stepCount) {
            var rnd = new Random();            
            var monsterCount = stepCount == 15 ? 1 : rnd.Next(1, stepCount + 1);            
            var monsters = new List<Monster>();
            for (int i = 0; i < monsterCount; i++)
            {
                var index = MonsterTypes.Count == 1 ? 0 : rnd.Next(0, MonsterTypes.Count);
                var monsterType = MonsterTypes[index];
                monsters.Add(MonsterData.GetRandomMonsterByType(monsterType, level));                
            }
            return monsters;
        }        

        public override string ToString()
        {
            return Description;
        }
    }
}