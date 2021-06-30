using System.Collections.Generic;

namespace to_the_moon
{
    public class CombatState
    {   
        public int MaxEnergy { get; set; }
        public int Strength { get; set; } //add to weapon meele attack damage 
        public int Dexterity { get; set; } //add to shield and ranged dmg
        public int Intelligence { get; set; } //add to spell damage
        public int Constitution { get; set; } //add to healing
        public Weapon MeeleWeapon { get; set; }
        public Weapon RangedWeapon { get; set; }
        public Weapon MagicWeapon { get; set; }
        public List<Monster> Minions { get; set; }

        public CombatState(Role role) {
            Strength = role.Strength;
            Dexterity = role.Dexterity;
            Intelligence = role.Intelligence;
            Constitution = role.Constitution;
            Minions = new List<Monster>();
            MaxEnergy = 3;
        }

        public override string ToString()
        {
            return $"meele: {(MeeleWeapon == null ? "none" : MeeleWeapon.Name)} ranged: {(RangedWeapon == null ? "none" : RangedWeapon.Name)} magic: {(MagicWeapon == null ? "none" : MagicWeapon.Name)} str: {Strength} dex: {Dexterity} int: {Intelligence} con: {Constitution}"; 
        }
    }
}