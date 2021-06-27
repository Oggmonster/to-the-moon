using System.Collections.Generic;
using System;
using System.Linq;

namespace to_the_moon
{
    public class CardDealer
    {
        public static Deck GetStartingDeck(int commonCount, int roleCount, int weaponCount, RoleType roleType)
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
            return new Deck(cards);
        }
        
        public static List<Card> GetRewardCards(int level, int count, RoleType role = RoleType.Beast)
        {
            var cards = new List<Card>();
            cards.Add(CardData.GetRandomCommonCard());
            cards.Add(CardData.GetRandomCommonCard());
            cards.Add(CardData.GetRandomCardByRole(role));
            cards.Add(CardData.GetRandomCardByRole(role));
            cards.Add(CardData.GetRandomWeaponCard());
            return cards;
        }       

    }
}