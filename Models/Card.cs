using System;
using System.Collections.Generic;

namespace to_the_moon
{
    //lvl 1 - 5. 
    //types weapon, spell, summon
    //weapon can be ranged and meele
    public class Card
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; } 
        public int Cost { get; set; }
        public bool IsReplayable { get; set; } //can play this multilple times during combat
        public CardType CardType { get; set; }
        public Func<Character, IEnumerable<Character>, List<Card>> Execute { get; set; }
        public Card(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            IsReplayable = true;
        }        

        public override string ToString()
        {            
            return $"{Name} ({CardType.ToString()}): Cost {Cost}. {Description}";
        }
    }
}