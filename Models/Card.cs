using System;
namespace to_the_moon
{    
    public class Card
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public bool IsReplayable { get; set; } //can play this multilple times during combat
        //play card 
        // action attack , block, modify strength, modify dex, draw card

        public Card(string name) {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }

    }
}