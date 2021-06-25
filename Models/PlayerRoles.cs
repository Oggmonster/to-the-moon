using System.Collections.Generic;
namespace to_the_moon
{
    public class PlayerRoles
    {        
        public static List<Role> GetPlayerRoles() {
            var result = new List<Role> {
                new Role {
                    RoleType = RoleType.Warrior,
                    Strength = 5,
                    Constitution = 4,
                    Dexterity = 2,
                    Intelligence = 1                    
                },
                new Role {
                    RoleType = RoleType.Ranger,
                    Strength = 2,
                    Dexterity = 7,
                    Constitution = 2,
                    Intelligence = 2
                },
                new Role {
                    RoleType = RoleType.Mage,
                    Strength = 1,
                    Dexterity = 1,
                    Intelligence = 9,
                    Constitution = 1
                },
                new Role {
                    RoleType = RoleType.Cleric,
                    Strength = 2,
                    Dexterity = 3,
                    Constitution = 7,
                    Intelligence = 3
                }
            };
            return result;
        }

    }
}