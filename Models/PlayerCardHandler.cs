using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace to_the_moon
{
    public class PlayerCardHandler : ICardHandler
    {        
        public Card PickCard(List<Card> cards) {
            Console.Write("Pick a card please");
            return ConsoleOptionPicker.PickOption<Card>(cards);            
        }

        public void PlayCard(Card card, Character attacker, List<Character> defenders) {
            //check card attributes and do stuff 
            if (card.Damage > 0) {
                if (card.IsMultiTarget) {
                    defenders.ForEach(d => d.Health-=card.Damage);
                }
            }
        }

    }
}