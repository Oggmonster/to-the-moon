namespace to_the_moon
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public Deck Deck { get; private set; }

        public Character(string name, int hp, int str, int dex, Deck deck) {
            Name = name;
            Health = hp;
            Strength = str;
            Dexterity = dex;
            Deck = deck;
        }

    }
}