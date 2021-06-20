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

        private static void ShowStats(Player player, List<Enemy> enemies)
        {

            Console.WriteLine($"Hero: {player.ToString()}");
            Console.WriteLine("Evil ones:");
            enemies.ForEach(e => Console.WriteLine(e.ToString()));
        }

        private static List<Enemy> GetEnemies(int level, int stepCount)
        {
            var startingCards = CardDealer.GetStartingCards();
            var deck = new Deck(startingCards);
            var enemies = new List<Enemy> {
                new Enemy ("TSLA", 10 + level, 10, 5, deck),
                new Enemy ("AMZ", 12 + level, 23, 24, deck),
            };
            return enemies;
        }

        private static void EnemyTurn(List<Enemy> enemies, Player player)
        {
            foreach (var enemy in enemies.Where(e => e.IsAlive()))
            {
                var card = enemy.Deck.Draw(1).First();
                CardHandler.PlayCard(card, enemy, new List<Player> { player });
            }
        }

        private static void PlayerTurn(Player player, IEnumerable<Enemy> enemies)
        {
            player.NewTurn();
            var cards = player.Deck.Draw(4);
            while (player.Energy > 0
            && cards.Count > 0
            && enemies.Any(e => e.IsAlive()))
            {
                if (cards.Any(c => c.Cost <= player.Energy))
                {
                    var card = ConsoleOptionPicker.PickOption<Card>(cards, "Pick a card", "End turn");
                    if (card == null)
                    {
                        player.EndTurn();
                    }
                    else
                    {
                        CardHandler.PlayCard(card, player, enemies);
                        player.Energy -= card.Cost;
                        cards.Remove(card);

                    }
                }
                else
                {
                    player.EndTurn();
                }
                ShowStats(player, enemies.ToList());
            }
        }

        private static void Loot(Player player, int level) {
            if (!player.IsAlive()) {
                return;
            }
            Console.Clear();
            Console.WriteLine("You won the battle! Claim your rewards");
            var rnd = new Random();
            var gold = rnd.Next(5, 100);
            Console.WriteLine($"You found {gold} gold");
            player.Gold += gold;
            var newCards = CardDealer.GetCards(level, 4);
            Console.WriteLine("Pick a card to add to your deck");
            var card = ConsoleOptionPicker.PickOption<Card>(newCards, "Pick card: ");
            player.Deck.AddCard(card);
            Console.WriteLine($"{card.Name} added to your deck"); 
        }

        private static void Turn(Player player, List<Enemy> enemies)
        {
            ShowStats(player, enemies);
            Console.WriteLine("Player turn:");
            PlayerTurn(player, enemies);
            Console.WriteLine("Enemy turn:");
            EnemyTurn(enemies, player);
            if (player.IsAlive() && enemies.Any(e => e.IsAlive()))
            {
                Turn(player, enemies);
            }
        }

        public static void Go(Player player, int level, int stepCount)
        {
            Console.WriteLine("Let's fight!");
            //get enemies
            var enemies = GetEnemies(level, stepCount);
            //prepare decks for combat
            player.Deck.NewCombat();
            player.Shield = 0;
            enemies.ForEach(e => e.Deck.NewCombat());
            Turn(player, enemies);
            Loot(player, level);
        }













    }
}