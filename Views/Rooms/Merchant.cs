using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{
    public class Merchant
    {
        private static string title = @"
 __   __  _______  ______    _______  __   __  _______  __    _  _______ 
|  |_|  ||       ||    _ |  |       ||  | |  ||   _   ||  |  | ||       |
|       ||    ___||   | ||  |       ||  |_|  ||  |_|  ||   |_| ||_     _|
|       ||   |___ |   |_||_ |       ||       ||       ||       |  |   |  
|       ||    ___||    __  ||      _||       ||       ||  _    |  |   |  
| ||_|| ||   |___ |   |  | ||     |_ |   _   ||   _   || | |   |  |   |  
|_|   |_||_______||___|  |_||_______||__| |__||__| |__||_|  |__|  |___|  
";
        private static Dictionary<string, (Card card, int price)> Warez (RoleType roleType) {
            var minPrice = 150;
            var maxPrice = 1000;
            var price = 0;
            var random = new Random();
            Card card = null;
            var theGoods = new Dictionary<string, (Card, int)>();
            for (int i = 0; i < 10; i++)
            {
                price = random.Next(minPrice, maxPrice);
                card = i % 2 == 0 ? CardData.GetRandomCardByRole(roleType) : CardData.GetRandomCommonCard();
                if (i % 7 == 0) {
                    card = CardData.GetRandomSummonCard();
                }
                theGoods.Add(card.Id, (card, price));                
            }
            return theGoods;
        }
        private static void BuySomething(Player player, Dictionary<string, (Card card, int price)> warez) {
            Console.WriteLine($"You have {player.Gold} gold. Pick something you can afford");
            warez.Select(w => w.Value).ToList().ForEach(w => Console.WriteLine($"{w.card.ToString()} cost {w.price} gold"));
            var card = OptionPicker.PickOption<Card>(warez.Select(w => w.Value.card).ToList(), "I want that one: ", "No thanks");
            if (card == null) {
                return;
            }
            var price = warez[card.Id].price;
            if (price > player.Gold) {
                Console.WriteLine("You don't have enough gold");
                OptionPicker.AnyKeyToContinue();
                BuySomething(player, warez);
            } else {
                player.Gold -= price;
                CardDealer.AddNewCard(player, card);
            }
        }
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine("This suspicious looking fellow want to sell you some cards");            
            var warez = Warez(player.Role.RoleType);   
            BuySomething(player, warez);   
            OptionPicker.AnyKeyToContinue();
        }

    }
}