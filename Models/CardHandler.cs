using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace to_the_moon
{
    public class CardHandler
    {
        private static void HandleAttack(Card card, Character attacker, IEnumerable<Character> defenders)
        {
            //look at attacker str, weakness etc and defender block vurnable etc.
            if (card.IsMultiTarget)
            {
                defenders.ToList().ForEach(d => d.IncomingAttack(card.Damage));
            }
            else
            {
                var defender = defenders.Count(d => d.Health > 0) > 1 ?
                 ConsoleOptionPicker.PickOption<Character>(defenders.ToList())
                 : defenders.First(d => d.Health > 0);
                defender.IncomingAttack(card.Damage);
            }
        }

        private static void HandleDefend(Card card, Character character)
        {
            character.Defend(card.Block);
        }
        public static void PlayCard(Card card, Character attacker, IEnumerable<Character> defenders)
        {
            //check card attributes and do stuff 
            if (card.Damage > 0)
            {
                HandleAttack(card, attacker, defenders);
            }
            if (card.Block > 0)
            {
                HandleDefend(card, attacker);
            }
        }

    }
}