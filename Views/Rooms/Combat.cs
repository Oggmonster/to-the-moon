using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Spectre.Console;

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

        private static Table GetCharacterTable(List<Character> characters, string color = "white")
        {

            var table = new Table();

            //hp: 40/40 def: 0 Ranger (meele: none ranged: none magic: none str: 2 dex: 7 int: 2 con: 2)

            table.AddColumn("");
            table.AddColumn("hp");
            table.AddColumn("def");
            table.AddColumn("str");
            table.AddColumn("dex");
            table.AddColumn("int");
            table.AddColumn("con");
            table.AddColumn("mel");
            table.AddColumn("rgd");
            table.AddColumn("mag");

            foreach (var c in characters)
            {
                var columns = new List<string> {
                    c.Name,
                    $"{c.Health}/{c.MaxHealth}",
                    c.Shield.ToString(),
                    c.CombatState.Strength.ToString(),
                    c.CombatState.Dexterity.ToString(),
                    c.CombatState.Intelligence.ToString(),
                    c.CombatState.Constitution.ToString(),
                    c.CombatState.MeeleWeapon?.Name,
                    c.CombatState.RangedWeapon?.Name,
                    c.CombatState.MagicWeapon?.Name
                };
                var markups = columns.Select(s => new Markup($"[{color}]{s}[/]"));
                table.AddRow(markups);
            }
            table.Border(TableBorder.Ascii);
            table.Expand();
            
            return table;
        }
        private static void ShowStats(Player player, List<Monster> enemies)
        {   
            var goodOnes = new List<Character>();
            goodOnes.Add(player);
            goodOnes.AddRange(player.Minions);
            var evilOnes = new List<Character>();
            evilOnes.AddRange(enemies);
            var heroTable = GetCharacterTable(goodOnes, "green");
            var enemyTable = GetCharacterTable(evilOnes, "red");
            heroTable.Title = new TableTitle("Good ones", new Style( Color.DarkGoldenrod));
            enemyTable.Title = new TableTitle("Evil", new Style( Color.Red1));             
            AnsiConsole.Render(heroTable);
            AnsiConsole.Render(enemyTable);
        }

        private static void EnemyTurn(List<Monster> enemies, Player player)
        {
            if (!enemies.Any(e => e.IsAlive()))
            {
                return;
            }
            Console.WriteLine("ENEMY TURN");
            var minions = new List<Monster>();
            var targets = new List<Character> {
                player,
            };
            if (player.Minions.Any())
            {
                targets.AddRange(player.Minions);
            }
            foreach (var enemy in enemies.Where(e => e.IsAlive()))
            {
                if (!player.IsAlive())
                {
                    continue;
                }
                var cards = enemy.Deck.Draw(2);
                enemy.NewTurn();
                while (enemy.Energy > 0
            && cards.Count > 0
            && player.IsAlive())
                {
                    var card = OptionPicker.PickRandomOption<Card>(cards);
                    cards.Remove(card);
                    if (card.Cost <= enemy.Energy)
                    {
                        enemy.Energy -= card.Cost;
                        cards.Remove(card);
                        var newCards = card.Execute(enemy, targets);
                        if (newCards.Any())
                        {
                            cards.AddRange(newCards);
                        }
                        //check if enemy summoned any minions - convert them to enemies
                        if (enemy.Minions.Any())
                        {
                            minions.AddRange(enemy.Minions);
                            enemy.Minions = new List<Monster>();
                        }
                    }
                }
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            enemies.AddRange(minions);
            Console.WriteLine("ENEMY TURN OVER");
        }

        private static void MinionsTurn(IEnumerable<Monster> minions, IEnumerable<Monster> enemies)
        {
            if (!minions.Any(e => e.IsAlive()))
            {
                return;
            }
            Console.WriteLine("MINIONS TURN");
            foreach (var minion in minions.Where(e => e.IsAlive()))
            {
                var cards = minion.Deck.Draw(2);
                minion.NewTurn();
                while (minion.Energy > 0 && cards.Count > 0)
                {
                    var card = OptionPicker.PickRandomOption<Card>(cards);
                    cards.Remove(card);
                    if (card.Cost <= minion.Energy)
                    {
                        minion.Energy -= card.Cost;
                        cards.Remove(card);
                        var newCards = card.Execute(minion, enemies);
                        if (newCards.Count > 0)
                        {
                            cards.AddRange(newCards);
                        }
                    }
                }
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            Console.WriteLine("MINIONS TURN OVER");
        }

        private static void PlayerTurn(Player player, IEnumerable<Monster> enemies)
        {
            var cards = player.Deck.Draw(4);
            while (player.Energy > 0
            && cards.Count > 0
            && enemies.Any(e => e.IsAlive()))
            {
                Console.WriteLine();
                Console.WriteLine($"Energy left {player.Energy}. Your hand:");
                var card = OptionPicker.PickOption<Card>(cards, "Pick a card: ", "End turn");
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
                    player.Energy -= card.Cost;
                    cards.Remove(card);
                    var newCards = card.Execute(player, enemies);
                    if (newCards.Count > 0)
                    {
                        cards.AddRange(newCards);
                    }
                }
            }
            if (player.Minions.Count > 0 && enemies.Any(e => e.IsAlive()))
            {
                MinionsTurn(player.Minions, enemies);
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
            var newCards = CardDealer.GetRewardCards(level, 4, player.Role.RoleType);
            Console.WriteLine("Pick a card to add to your deck");
            var card = OptionPicker.PickOption<Card>(newCards, "Pick card: ");
            CardDealer.AddNewCard(player, card);
        }

        private static void Turn(Player player, List<Monster> enemies)
        {
            player.NewTurn();
            ShowStats(player, enemies);
            Console.WriteLine("PLAYER TURN:");
            PlayerTurn(player, enemies);
            Console.WriteLine();
            EnemyTurn(enemies, player);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            if (player.IsAlive() && enemies.Any(e => e.IsAlive()))
            {
                Turn(player, enemies);
            }
        }

        public static void Go(Player player, List<Monster> monsters, int level, int stepCount)
        {
            Console.WriteLine(title);
            Console.WriteLine();
            player.NewCombat();
            monsters.ForEach(e => e.NewCombat());
            Turn(player, monsters);
            Loot(player, level);
            OptionPicker.AnyKeyToContinue();
        }













    }
}