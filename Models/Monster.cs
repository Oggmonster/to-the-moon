namespace to_the_moon
{
    public class Monster : Character
    {
        public MonsterType Type { get; set; }
        public Monster (string name, Role role, Deck deck, MonsterType type) : base (name, role, deck) 
        {
            Type = type;
        }        
    }
}