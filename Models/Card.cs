using System;
using System.Text;

namespace to_the_moon
{
    public class Card
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; set; }
        public int Block { get; set; }
        public int Heal { get; set; }
        public int StrengthModify { get; set; } //base target on if positive or negative number
        public int DexterityModify { get; set; }// -- " --
        public int TurnCount { get; set; }
        public int DrawCount { get; set; }
        public int Cost { get; set; }
        public bool IsReplayable { get; set; } //can play this multilple times during combat
        public bool IsMultiTarget { get; set; }

        public Card(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            IsReplayable = true;
        }        

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{Name}: Cost {Cost}. ");
            if (Damage > 0) {
                sb.Append($"Deal {Damage} damage{(IsMultiTarget ? " on all enemies." : ".")} ");
            }
            if (Block > 0) {
                sb.Append($"Add {Block} to shield. ");
            }
            if (Heal > 0) {
                sb.Append($"Heal {Heal} hp. ");
            }
            if (DrawCount > 0) {
                sb.Append($"Draw {DrawCount} {(DrawCount > 1 ? "cards" : "card")}. ");
            }
            return sb.ToString();
        }
    }
}