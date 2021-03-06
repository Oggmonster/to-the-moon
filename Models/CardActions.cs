using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{
    public class CardActions
    {
        private static List<Character> FindTargets(Character attacker, IEnumerable<Character> defenders, int targetCount)
        {
            var targets = defenders.Where(d => d.IsAlive()).ToList();
            if (targets.Count == 1 ||
                targets.Count == targetCount)
            {
                return targets.ToList();
            }
            if (targetCount == 1 && typeof(Player).IsInstanceOfType(attacker)) {
                Console.WriteLine("Pick target:");
                return new List<Character> {
                    OptionPicker.PickOption<Character>(targets)
                };
            }
            var take = Math.Min(targets.Count, targetCount);
            var rnd = new Random();
            var luckyOnes = targets.OrderBy(d => rnd.Next()).Take(take);
            return luckyOnes.ToList();
        }

        public static Action<Character, IEnumerable<Character>, int, int> RangedAttack = (attacker, defenders, targetCount, skillDamage) =>
        {
            var weaponDamage = attacker.CombatState.RangedWeapon != null ? 
                attacker.CombatState.RangedWeapon.Damage + attacker.CombatState.Dexterity 
                : 0;            
            var damage = attacker.CalculateDamage(skillDamage, weaponDamage);
            if (damage == 0) {
                Console.WriteLine($"{attacker.Name} shoots but hits nothing but air");
                return;
            }            
            var targets = FindTargets(attacker, defenders, targetCount);
            targets.ForEach(t => Console.WriteLine($"{attacker.Name} shoots {t.Name} with {damage} dmg, {t.Name} takes {t.IncomingAttack(damage)} dmg"));
            targets.Where(e => !e.IsAlive()).ToList().ForEach(c => Console.WriteLine($"{c.Name} dies instantly"));
        };

        public static Action<Character, IEnumerable<Character>, int, int> MeeleAttack = (attacker, defenders, targetCount, skillDamage) =>
        {
            var weaponDamage = attacker.CombatState.MeeleWeapon != null ? 
                attacker.CombatState.MeeleWeapon.Damage + attacker.CombatState.Strength 
                : 0;            
            var damage = attacker.CalculateDamage(skillDamage, weaponDamage);
            if (damage == 0) {
                Console.WriteLine($"{attacker.Name} swings and MISS! Embarrassing!");
                return;
            }
            var targets = FindTargets(attacker, defenders, targetCount);
            targets.ForEach(t => Console.WriteLine($"{attacker.Name} stabs {t.Name} with {damage} dmg, {t.Name} takes {t.IncomingAttack(damage)} dmg"));
            targets.Where(e => !e.IsAlive()).ToList().ForEach(c => Console.WriteLine($"{c.Name} bleeds to death"));
        };

        public static Action<Character, IEnumerable<Character>, int, int> MagicAttack = (attacker, defenders, targetCount, skillDamage) =>
        {
            var weaponDamage = attacker.CombatState.MagicWeapon != null ? 
                attacker.CombatState.MagicWeapon.Damage + attacker.CombatState.Intelligence 
                : 0;            
            var damage = attacker.CalculateDamage(skillDamage, weaponDamage);
            if (damage == 0) {
                Console.WriteLine($"{attacker.Name} didn't hurt anyone. Friendly fellow.");
                return;
            }
            var targets = FindTargets(attacker, defenders, targetCount);
            targets.ForEach(t => Console.WriteLine($"{attacker.Name} blasts {t.Name} with {damage} dmg, {t.Name} takes {t.IncomingAttack(damage)} dmg"));
            targets.Where(e => !e.IsAlive()).ToList().ForEach(c => Console.WriteLine($"{c.Name} explodes in a bloody mess"));
        };
    }
}
