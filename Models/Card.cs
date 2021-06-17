using System;
namespace to_the_moon
{
    public class Card
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; set; }
        public int Block { get; set; }
        public int Cost { get; set; }
        public bool IsReplayable { get; set; } //can play this multilple times during combat
        public bool IsMultiTarget { get; set; }
        //play card 
        // action attack , block, modify strength, modify dex, draw card

        public Card(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            IsReplayable = true;
        }

        public override string ToString()
        {
            return $"{Name} - c: {Cost} d: {Damage} b: {Block}";
        }

    }
}