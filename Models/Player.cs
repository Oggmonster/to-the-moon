using System;
namespace to_the_moon
{
    public class Player : Character
    {
        public int Energy { get; set; }
        public int Gold { get; set; }

        //potions
        //relics
        public override void SetHealth(int constitution) {    
            var rand = new Random();
            var min = 15 + constitution;
            var max = 30 + constitution;
            var hp = rand.Next(min, max);
            Health = hp;
            MaxHealth = hp;
        }

        public Player (string name, Role role, Deck deck) : base (name, role, deck) 
        {
            Energy = 3;
        }

        public void NewTurn() {
            Energy = 3;
        }

        public void EndTurn() {
            Energy = 0;
        }
    }
}