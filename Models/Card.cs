using System;

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
        public int Damage { get; set; }
        public int Block { get; set; }
        public int Heal { get; set; }
        public int StrengthModify { get; set; } //base target on if positive or negative number
        public int DexterityModify { get; set; }// -- " --
        public int TurnCount { get; set; }
        public int DrawCount { get; set; }
        public int SummonCount { get; set; }
        public int Cost { get; set; }
        public bool IsReplayable { get; set; } //can play this multilple times during combat
        public bool IsMultiTarget { get; set; }
        public CardType CardType { get; set; }
        public Action<Character> Boost { get; set; }
        public Card(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            IsReplayable = true;
        }        

        public override string ToString()
        {            
            return $"{Name}: Cost {Cost}. {Description}";
        }
    }
}