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
        private static string title = @"
 _______  ___   _______  __   __  _______ 
|       ||   | |       ||  | |  ||       |
|    ___||   | |    ___||  |_|  ||_     _|
|   |___ |   | |   | __ |       |  |   |  
|    ___||   | |   ||  ||       |  |   |  
|   |    |   | |   |_| ||   _   |  |   |  
|___|    |___| |_______||__| |__|  |___|  
";
        //stepcount 15 == boss

        private static void ShowStats(Player player, List<Enemy> enemies)
        {
            Console.WriteLine("STATS:");
            Console.WriteLine();
            Console.WriteLine($"Hero: {player.ToString()}");
            Console.WriteLine();
            Console.WriteLine("Evil ones:");
            enemies.ForEach(e => Console.WriteLine(e.ToString()));
            Console.WriteLine();
        }

        private static List<Enemy> GetEnemies(int level, int stepCount)
        {
            var startingCards = CardDealer.GetStartingCards();
            var deck = new Deck(startingCards);
            var enemies = new List<Enemy> {
                new Enemy ("TSLA", 5, 10, 5, deck),
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
            Console.WriteLine("ENEMY TURN OVER");
        }

        private static void PlayerTurn(Player player, IEnumerable<Enemy> enemies)
        {            
            var cards = player.Deck.Draw(4);
            while (player.Energy > 0
            && cards.Count > 0
            && enemies.Any(e => e.IsAlive()))
            {
                Console.WriteLine();
                Console.WriteLine($"Energy left {player.Energy}. Your hand:");
                var card = ConsoleOptionPicker.PickOption<Card>(cards, "Pick a card: ", "End turn");
                if (card == null)
                {
                    player.EndTurn();
                }
                else if (card.Cost > player.Energy)
                {
                    Console.WriteLine();
                    Console.WriteLine("You don't have enough energy to pick that card. Pick another one or end turn.");

                }
                else
                {
                    Console.WriteLine();
                    CardHandler.PlayCard(card, player, enemies);
                    player.Energy -= card.Cost;
                    cards.Remove(card);

                }

            }
        }

        private static void Loot(Player player, int level)
        {
            if (!player.IsAlive())
            {
                return;
            }
            Console.Clear();
            Console.WriteLine(@"
 ___      _______  _______  _______ 
|   |    |       ||       ||       |
|   |    |   _   ||   _   ||_     _|
|   |    |  | |  ||  | |  |  |   |  
|   |___ |  |_|  ||  |_|  |  |   |  
|       ||       ||       |  |   |  
|_______||_______||_______|  |___|  
");
            Console.WriteLine("You won the battle! Claim your rewards");
            var rnd = new Random();
            var gold = rnd.Next(5, 100);
            Console.WriteLine($"You found {gold} gold");
            Console.WriteLine();
            player.Gold += gold; 
            var newCards = CardDealer.GetCards(level, 4);
            Console.WriteLine("Pick a card to add to your deck");
            var card = ConsoleOptionPicker.PickOption<Card>(newCards, "Pick card: ");          
            AddNewCard(player, card);            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void AddNewCard(Player player, Card card) {            
            try {
                player.Deck.AddCard(card);
                Console.WriteLine($"{card.Name} added to your deck");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Do you want to replace a card in your deck with the one you selected?");
                if (ConsoleOptionPicker.ConfirmPrompt()) {
                    Console.WriteLine();
                    Console.WriteLine("Select a card you want to remove from your deck");
                    var allCards = player.Deck.GetAllCards();
                    var removeCard = ConsoleOptionPicker.PickOption<Card>(allCards);
                    player.Deck.RemoveCard(removeCard.Id);
                    Console.WriteLine($"{removeCard.Name} removed");
                    AddNewCard(player, card);
                }
            }
        }

        private static void Turn(Player player, List<Enemy> enemies)
        {
            player.NewTurn();
            ShowStats(player, enemies);
            Console.WriteLine("PLAYER TURN:");
            PlayerTurn(player, enemies);
            Console.WriteLine();
            Console.WriteLine("ENEMY TURN:");
            EnemyTurn(enemies, player);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            if (player.IsAlive() && enemies.Any(e => e.IsAlive()))
            {
                Turn(player, enemies);
            }
        }

        public static void Go(Player player, int level, int stepCount)
        {
            Console.WriteLine(title);
            Console.WriteLine();
            //get enemies
            var enemies = GetEnemies(level, stepCount);
            //prepare decks for combat
            player.NewCombat();
            enemies.ForEach(e => e.NewCombat());
            Turn(player, enemies);
            Loot(player, level);
            Console.Clear();
        }













    }
}