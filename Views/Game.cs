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
        private int stepCount = 0;
        private Player player;

        private void TravelMap() {
            //show map - return roomtype
            var roomType = Map.GetARoom(stepCount);
            if(stepCount == 15) {
                level++;
                stepCount=0;
            } else {
                stepCount++;
            }
            Save();
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