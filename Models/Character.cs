using System;
namespace to_the_moon
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public Deck Deck { get; private set; }

        public Character(string name, int hp, int str, int dex, Deck deck) {
            Name = name;
            Health = hp;
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

        public void IncomingAttack(int damage) {
            var takenDamage = damage;
            if (Shield > 0) {
                takenDamage = Shield - damage;
                Shield = Math.Max(Shield - damage, 0);
            }
            Health -= takenDamage;
        }

        public bool IsAlive() {
            return Health > 0;
        }

    }
}