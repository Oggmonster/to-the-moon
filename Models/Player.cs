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
            Energy = 3;
        }

        public void NewTurn() {
            Energy = 3;
        }

        public void EndTurn() {
            Energy = 0;
        }

        public override string ToString()
        {
            return $"{Name} - e: {Energy} hp: {Health}/{MaxHealth} def: {Shield} str: {Strength} dex: {Dexterity}";
        }

    }
}