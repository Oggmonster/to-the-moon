using System.Collections.Generic;
using System;
using System.Linq;

namespace to_the_moon
{
    public class CardDealer
    {
        //start with 10 cards 
        
        private static Random rnd = new Random();

        private static Card Strike(int level)
        {
            var minDamage = 2 + level;
            var maxDamage = 10 + level;
            var damage = rnd.Next(minDamage, maxDamage);
            return new Card("Strike")
            {
                Damage = damage,
                Cost = 1
            };
        }

        private static Card Block(int level)
        {
            var minBlock = 2 + level;
            var maxBlock = 7 + level;
            var block = rnd.Next(minBlock, maxBlock);
            return new Card("Block")
            {
                Block = block,
                Cost = 1
            };
        }

        private static Card Heal(int level)
        {
            var minHeal = 1 + level;
            var maxHeal = 5 + level;
            var heal = rnd.Next(minHeal, maxHeal);
            return new Card("Heal")
            {
                Heal = heal,
                Cost = 2
            };
        }

        public static List<Card> GetCards(int level, int count)
        {
            var cards = new List<Card>();
            var commons = CardData.GetAllCommons();
            for (int i = 0; i < count; i++)
            {                
                var index = rnd.Next(0, commons.Count);
                var card = commons[index];                
                cards.Add(card);                
                commons.Remove(card);
            }            
            return cards;
        }

        public static List<Card> GetStartingCards(int level = 1)
        {
            var cards = new List<Card>();
            int cardCount = 25;
            Card card = null;
            for (int i = 0; i < cardCount; i++)
            {
                if (i % 2 == 0)
                {
                    card = Strike(level);
                }
                else if (i % 3 == 0)
                {
                    card = Heal(level);
                }
                else
                {
                    card = Block(level);
                }
                cards.Add(card);
            }
            return cards;
        }

    }
}