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
            var attackDamage = attacker.CalculateDamage(card.Damage);    
            var targets = defenders.Where(d => d.Health > 0).ToList();        
            //look at attacker str, weakness etc and defender block vurnable etc.
            if (card.IsMultiTarget)
            {                
                targets.ForEach(d => d.IncomingAttack(attackDamage));
                Console.WriteLine($"{attacker.Name} attack {string.Join(',', targets.Select(t => t.Name))} with {attackDamage}");
            }
            else
            {
                var defender = targets.Count == 1 ? targets.First() :  ConsoleOptionPicker.PickOption<Character>(targets, "Pick target: ");
                defender.IncomingAttack(attackDamage);
                Console.Clear();
                Console.WriteLine($"{attacker.Name} attack {defender.Name} with {attackDamage}");
            }
            ShowDeath(targets);
        }

        private static void ShowDeath(List<Character> characters) {
            //random death string
            characters.Where(e => !e.IsAlive()).ToList().ForEach(c => Console.WriteLine($"{c.Name} dies a slow painful death."));
        }

        private static void HandleDefend(Card card, Character character)
        {
            character.Defend(card.Block);
            Console.WriteLine($"{character.Name} defend with {card.Block}");
        }

        private static void HandleHeal(Card card, Character character) 
        {
            character.Heal(card.Heal);
            Console.WriteLine($"{character.Name} heal with {card.Heal}");
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
            if (card.Heal > 0)
            {
                HandleHeal(card, attacker);
            }
        }

    }
}