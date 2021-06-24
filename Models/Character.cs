using System;
namespace to_the_moon
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public Deck Deck { get; private set; }

        public Character(string name, int hp, int str, int dex, Deck deck) {
            Name = name;
            Health = hp;
            MaxHealth = hp;
            Strength = str;
            Dexterity = dex;
            Deck = deck;
            Shield = 0;
        }

        public int CalculateDamage(int damage) {
            //apply modifiers - str, weak etc
            return damage;
        }

        public void Defend(int block) {
            //apply modifiers - dex, frail etc.
            Shield += block;
        }

        public void Heal(int heal) {
            Health = Math.Min(Health + heal, MaxHealth);
        }

        public int IncomingAttack(int damage) {
            var takenDamage = damage;
            if (Shield > 0) {
                takenDamage = damage >= Shield ? damage - Shield : 0;
                Shield = Math.Max(Shield - damage, 0);
            }
            Health = Math.Max(Health - takenDamage, 0);
            return takenDamage;
        }

        public void NewCombat() {
            Shield = 0;
            Deck.NewCombat();
        }

        public bool IsAlive() {
            return Health > 0;
        }

    }
}