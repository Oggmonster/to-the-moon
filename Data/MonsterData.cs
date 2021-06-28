using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class MonsterData
    {

        private static List<Func<Monster>> creeps = new List<Func<Monster>> {
            () => new Monster ("Slime", new Role {
                RoleType = RoleType.Creep,
                Strength = 2,
                Dexterity = 0,
                Constitution = 1,
                Intelligence = 0
            }, CardDealer.GetStartingDeck(3, 3, 0, RoleType.Creep))
        };

        private static List<Func<Monster>> undeads = new List<Func<Monster>> {
            () => new Monster ("Skeleton", new Role {
                RoleType = RoleType.Undead,
                Strength = 4,
                Dexterity = 1,
                Constitution = 1,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Undead)),
            () => new Monster ("Skeleton Archer", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 5,
                Constitution = 2,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Undead)),
            () => new Monster ("Skeleton Mage", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 5
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Undead))
        };

        private static List<Func<Monster>> demons = new List<Func<Monster>> {
            () => new Monster ("Gargoyle", new Role {
                RoleType = RoleType.Demon,
                Strength = 4,
                Dexterity = 3,
                Constitution = 4,
                Intelligence = 3
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Demon))
        };

        private static List<Func<Monster>> elves = new List<Func<Monster>> {
            () => new Monster ("Dark elf", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 6,
                Constitution = 3,
                Intelligence = 3
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Elf))
        };

        private static List<Func<Monster>> beasts = new List<Func<Monster>> {
            () => new Monster ("Fox", new Role {
                RoleType = RoleType.Beast,
                Strength = 2,
                Dexterity = 6,
                Constitution = 2,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Beast)),
            () => new Monster ("Wolf", new Role {
                RoleType = RoleType.Beast,
                Strength = 4,
                Dexterity = 2,
                Constitution = 3,
                Intelligence = 2
            }, CardDealer.GetStartingDeck(4, 3, 0, RoleType.Beast)),
            () => new Monster ("Boar", new Role {
                RoleType = RoleType.Beast,
                Strength = 3,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 0
            }, CardDealer.GetStartingDeck(2, 2, 0, RoleType.Beast)),
            () => new Monster ("Bear", new Role {
                RoleType = RoleType.Beast,
                Strength = 5,
                Dexterity = 1,
                Constitution = 7,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(5, 5, 1, RoleType.Beast))
        };

        private static List<Func<Monster>> bosses = new List<Func<Monster>> {
            () => new Monster ("Mad king", new Role {
                RoleType = RoleType.Boss,
                Strength = 10,
                Dexterity = 2,
                Constitution = 15,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(6, 8, 3, RoleType.Beast))
        };

        public static Monster GetRandomMonsterByType(RoleType role, int level)
        {
            switch (role)
            {
                case RoleType.Beast:
                    return OptionPicker.PickRandomOption<Func<Monster>>(beasts)();
                case RoleType.Creep:
                    return OptionPicker.PickRandomOption<Func<Monster>>(creeps)();
                case RoleType.Demon:
                    return OptionPicker.PickRandomOption<Func<Monster>>(demons)();
                case RoleType.Elf:
                    return OptionPicker.PickRandomOption<Func<Monster>>(elves)();
                case RoleType.Undead:
                    return OptionPicker.PickRandomOption<Func<Monster>>(undeads)();
                case RoleType.Boss:
                    return OptionPicker.PickRandomOption<Func<Monster>>(bosses)();
                default:
                    return OptionPicker.PickRandomOption<Func<Monster>>(beasts)();
            }
        }
    }
}