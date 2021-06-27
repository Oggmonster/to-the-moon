using System.Collections.Generic;

namespace to_the_moon
{
    public class CombatState
    {        
        public int Strength { get; set; } //add to weapon meele attack damage 
        public int Dexterity { get; set; } //add to shield and ranged dmg
        public int Intelligence { get; set; } //add to spell damage
        public int Constitution { get; set; } //add to healing
        public Weapon Weapon { get; set; }
        public List<Monster> Minions { get; set; }

        public CombatState(Role role) {
            Strength = role.Strength;
            Dexterity = role.Dexterity;
            Intelligence = role.Intelligence;
            Constitution = role.Constitution;
            Minions = new List<Monster>();
        }

        public override string ToString()
        {
            return $"weapon: {(Weapon == null ? "none" : Weapon.Name)} str: {Strength} dex: {Dexterity} int: {Intelligence} con: {Constitution}"; 
        }
    }
}