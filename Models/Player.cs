namespace to_the_moon
{
    public class Player : Character
    {
        public int Energy { get; set; }
        public int Gold { get; set; }

        //potions
        //relics

        public Player (string name, int hp, int str, int dex, Deck deck) : base (name, hp, str, dex, deck) 
        {
            Energy = 4;
        }

        public override string ToString()
        {
            return $"{Name} - hp: {Health} str: {Strength} dex: {Dexterity}";
        }

    }
}