namespace to_the_moon
{
    public class Enemy : Character
    {
        public Enemy (string name, int hp, int str, int dex, Deck deck) : base (name, hp, str, dex, deck) 
        {
            
        }

        public override string ToString()
        {
            return $"{Name} - hp: {Health}/{MaxHealth} def: {Shield} str: {Strength} dex: {Dexterity}";
        }
    }
}