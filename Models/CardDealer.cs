using System.Collections.Generic;
using System;
using System.Linq;

namespace to_the_moon
{
    public class CardDealer
    {
        public static Deck GetStartingDeck(int commonCount, int roleCount, int weaponCount, RoleType roleType, int summonCount = 0)
        {            
            var cards = new List<Card>();
            for (int i = 0; i < commonCount; i++)
            {
                cards.Add(CardData.GetRandomCommonCard());                
            }
            for (int i = 0; i < roleCount; i++)
            {
                cards.Add(CardData.GetRandomCardByRole(roleType));
            }
            for (int i = 0; i < weaponCount; i++)
            {
                cards.Add(CardData.GetRandomWeaponCard());
            }
            for (int i = 0; i < summonCount; i++)
            {
                cards.Add(CardData.GetRandomSummonCard());
            }
            return new Deck(cards);
        }
        
        public static List<Card> GetRewardCards(int level, int count, RoleType role = RoleType.Beast)
        {
            var cards = new List<Card>();
            cards.Add(CardData.GetRandomCommonCard());
            cards.Add(CardData.GetRandomCardByRole(role));
            var rnd = new Random();
            var num = rnd.Next(0, 100);
            if (num >= 70 && num <= 85) {
                cards.Add(CardData.GetRandomWeaponCard());
            }
            if (num > 85) {
                cards.Add(CardData.GetRandomSummonCard());
            }
            
            return cards;
        }  

        public static void AddNewCard(Player player, Card card)
        {
            try
            {
                player.Deck.AddCard(card);
                Console.WriteLine($"{card.Name} added to your deck");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Do you want to replace a card in your deck with the one you selected?");
                if (OptionPicker.ConfirmPrompt())
                {
                    Console.WriteLine();
                    Console.WriteLine("Select a card you want to remove from your deck");
                    var allCards = player.Deck.GetAllCards();
                    var removeCard = OptionPicker.PickOption<Card>(allCards);
                    player.Deck.RemoveCard(removeCard.Id);
                    Console.WriteLine($"{removeCard.Name} removed");
                    AddNewCard(player, card);
                }
            }
        }     

    }
}