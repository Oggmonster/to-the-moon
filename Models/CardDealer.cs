using System.Collections.Generic;

namespace to_the_moon
{
    public class CardDealer
    {
        //generates random cards

        public static Card GetRandomCard(int level) {
            return new Card("Strike");
        }

        public static List<Card> GetStartingCards() {
            var cards = new List<Card>();
            int cardCount = 25;
            for (int i = 0; i < cardCount; i++)
            {
                if (i % 2 == 0) {
                    cards.Add(new Card("Strike") {
                        Damage = 7
                    });
                } else {
                    cards.Add(new Card("Defend") {
                        Block = 7
                    });
                }                
            }
            return cards;
        }

    }
}