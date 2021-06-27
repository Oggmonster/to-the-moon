using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Player : Character
    {
        
        public int Gold { get; set; }

        public override void SetHealth(int constitution) {    
            var rand = new Random();
            var min = 30 + constitution;
            var max = 50 + constitution;
            var hp = rand.Next(min, max);
            Health = hp;
            MaxHealth = hp;
        }        

        public Player (string name, Role role, Deck deck) : base (name, role, deck) 
        {            
            
        }
    }
}