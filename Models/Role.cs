using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Role
    {        
        public int Strength { get; set; } //add to weapon meele attack damage 
        public int Dexterity { get; set; } //add to shield and ranged dmg
        public int Intelligence { get; set; } //add to spell damage
        public int Constitution { get; set; } //add to healing
        public RoleType RoleType { get; set; }        
        public List<RoleType> WeekAgainst { get; set; }

        public override string ToString()
        {
            return $"{RoleType.ToString()} ( str: {Strength} dex: {Dexterity} int: {Intelligence} con: {Constitution} )";
        }
    }
}