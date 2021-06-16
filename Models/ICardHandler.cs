using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace to_the_moon
{
    public interface ICardHandler
    {               
        public Card PickCard(List<Card> cards);

        public void PlayCard(Card card, Character attacker, List<Character> defenders);

    }
}