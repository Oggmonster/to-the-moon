using System;
namespace to_the_moon
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }        
        public Deck Deck { get; private set; }
        public Role Role { get; set; }
        public virtual void  SetHealth(int constitution) {
            var hp = (constitution * 2) + 5;
            Health = hp;
            MaxHealth = hp;
        }
        public Character(string name, Role role, Deck deck) {
            Name = name;
            Role = role;            
            Deck = deck;
            Shield = 0;
            SetHealth(role.Constitution);
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

        public override string ToString()
        {
            if (Health == 0) {
                return $"{Name} is dead";
            }
            return $"{Name} - hp: {Health}/{MaxHealth} def: {Shield} {Role.ToString()}";
        }

    }
}