using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Start
    {
        //return player and level
        public static (Player player, int level) Go() {
            Console.Clear();
            Console.WriteLine("To the Mooooon!");
            Console.WriteLine("______________");            
            var options = new List<string> {
                "New Game",
                "Continue",
            };
            Console.WriteLine("Ctrl + C to exit");
            var option = ConsoleOptionPicker.PickOption<string>(options);
            Console.Clear();
            return option == "New Game" ? New() : Load();            
        }

        private static (Player player, int level) New() {
            var startingCards = CardDealer.GetStartingCards();
            var deck = new Deck(startingCards);
            var players = new List<Player> {
                new Player ("GME", 55, 10, 5, deck),
                new Player ("AMC", 25, 23, 24, deck),
                new Player ("BB", 30, 5, 5, deck)
            };
            Console.WriteLine("Pick a fighter");
            var player = ConsoleOptionPicker.PickOption<Player>(players);
            Console.Clear();
            return (player, 1);
        }

        private static (Player player, int level) Load() {
            //read json from file or something
            return (new Player("hej", 1, 1, 1, new Deck(new List<Card> {new Card("hejs")} )), 1);
        }

    }
}