using System;
namespace to_the_moon
{
    public class Game
    {
        /* 
        start - new game or continue
        map - pick next step
        either - treasure - rest - combat - chance - merchant - when finished back to map
        when last step finished - show stats and level completed - render new level (more difficult)
        */

        private int level;
        private int stepCount = 1;
        private Player player;

        private void TravelMap() {
            var place = Map.GoSomewhere(stepCount);
            var roomType = place.GetRoom();             
            if (roomType == RoomType.Combat) {
                var monsters = place.GetMonsters(level, stepCount);
                Combat.Go(player, monsters, level, stepCount);
            }
            if (roomType == RoomType.CampFire) {
                CampFire.Go(player, level, stepCount);
            }
            if (roomType == RoomType.Chance) {
                Chance.Go(player, level, stepCount);
            }
            if (roomType == RoomType.Merchant) {
                Merchant.Go(player, level, stepCount);
            }
            if (roomType == RoomType.Treasure) {
                Treasure.Go(player, level, stepCount);
            }
            if (roomType == RoomType.Blacksmith) {
                Blacksmith.Go(player);
            }
            if(stepCount == 15) {
                level++;
                stepCount=1;
            } else {
                stepCount++;
            }
            Save();
            if (player.IsAlive()) {
                TravelMap();
            }
        }

        private void Save() {
            //save state - player - level and stepcount
        }


        
        public void Run() {
            //start - return player and level
            (player, level) = Start.Go();
            Console.WriteLine("You are playing as " + player.Name);
            TravelMap();
            Console.WriteLine("Thanks for playing. Goodbye!");
        }




    }
}