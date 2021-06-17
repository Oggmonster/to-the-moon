using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{

    /* fight between player and an enemy
        1. player draw 4 cards
        2. enemies intended moves - either defend, spell, attack
        3. player turn - play cards until all energy spent or end turn
        4. enemies executes intended moves
        5. Is player alive? yes - is any enemies alive? yes - go to 1. else end combat and get loot */

    public class Combat
    {
        //stepcount 15 == boss

        private static void ShowStats(Player player, List<Enemy> enemies) {
            Console.WriteLine(player.ToString());
            Console.WriteLine(string.Join('|', enemies.Select(e => e.ToString())));
        }
        
        private static List<Enemy> GetEnemies(int level, int stepCount) {
            var startingCards = CardDealer.GetStartingCards();
            var deck = new Deck(startingCards);
            var enemies = new List<Enemy> {
                new Enemy ("TSLA", 10 + level, 10, 5, deck),
                new Enemy ("AMZ", 12 + level, 23, 24, deck),
            };
            return enemies;            
        }

        private static void EnemyTurn(List<Enemy> enemies, Player player) {
            foreach (var enemy in enemies)
            {
                var card = enemy.Deck.Draw(1).First();
                CardHandler.PlayCard(card, enemy, new List<Player> { player });                
            }
        }

        private static void PlayerTurn(Player player, IEnumerable<Enemy> enemies) {
            var cards = player.Deck.Draw(4);
            cards.ForEach(c => Console.WriteLine(c.ToString()));
            var energy = player.Energy;
            while(energy > 0) {
                Console.WriteLine("Which card do you wanna play?");
                var card = ConsoleOptionPicker.PickOption<Card>(cards);
                CardHandler.PlayCard(card, player, enemies);
                cards.Remove(card);
                energy--;
                if (cards.Count == 0) {
                    energy = 0;
                }
            }
        }
        
        private static void Turn(Player player, List<Enemy> enemies) {
            ShowStats(player, enemies);
            PlayerTurn(player, enemies);
            EnemyTurn(enemies, player);
            if (player.IsAlive() && enemies.Any(e => e.IsAlive())){
                Turn(player, enemies);
            }
        }

        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine("Let's fight!");
            //get enemies
            var enemies = GetEnemies(level, stepCount);
            //prepare decks for combat
            player.Deck.NewCombat();
            player.Shield = 0;
            enemies.ForEach(e => e.Deck.NewCombat());
            Turn(player, enemies);            
        }




        








    }
}