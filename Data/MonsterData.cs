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
            },
            CardDealer.GetStartingDeck(3, 3, 0, RoleType.Creep),
            MonsterType.Common),
            () => new Monster ("Spider", new Role {
                RoleType = RoleType.Creep,
                Strength = 3,
                Dexterity = 2,
                Constitution = 4,
                Intelligence = 3
            },
            CardDealer.GetStartingDeck(4, 4, 1, RoleType.Creep),
            MonsterType.Common)
        };

        private static List<Func<Monster>> eliteCreeps = new List<Func<Monster>> {
            () => new Monster ("Tarantula", new Role {
                RoleType = RoleType.Creep,
                Strength = 5,
                Dexterity = 2,
                Constitution = 10,
                Intelligence = 6
            },
            CardDealer.GetStartingDeck(6, 6, 1, RoleType.Creep, 2),
            MonsterType.Elite)
        };

        private static List<Func<Monster>> undeads = new List<Func<Monster>> {
            () => new Monster ("Zombie", new Role {
                RoleType = RoleType.Undead,
                Strength = 3,
                Dexterity = 2,
                Constitution = 4,
                Intelligence = 2
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Undead),
            MonsterType.Common),
            () => new Monster ("Skeleton", new Role {
                RoleType = RoleType.Undead,
                Strength = 4,
                Dexterity = 1,
                Constitution = 1,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Undead),
            MonsterType.Common),
            () => new Monster ("Skeleton Archer", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 5,
                Constitution = 2,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Undead),
            MonsterType.Common),
            () => new Monster ("Skeleton Mage", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 5
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Undead),
            MonsterType.Common)
        };

        private static List<Func<Monster>> eliteUndeads = new List<Func<Monster>> {
            () => new Monster ("Skeletor", new Role {
                RoleType = RoleType.Undead,
                Strength = 6,
                Dexterity = 2,
                Constitution = 6,
                Intelligence = 4
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Undead, 2),
            MonsterType.Elite),
            () => new Monster ("Skeleton Summoner", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 1,
                Constitution = 4,
                Intelligence = 4
            }, CardDealer.GetStartingDeck(2, 2, 0, RoleType.Undead, 4),
            MonsterType.Elite),
            () => new Monster ("Zombo the Zombie", new Role {
                RoleType = RoleType.Undead,
                Strength = 1,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 5
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Undead, 3),
            MonsterType.Elite)
        };

        private static List<Func<Monster>> demons = new List<Func<Monster>> {
            () => new Monster ("Gargoyle", new Role {
                RoleType = RoleType.Demon,
                Strength = 4,
                Dexterity = 3,
                Constitution = 4,
                Intelligence = 3
            }, CardDealer.GetStartingDeck(4, 4, 1, RoleType.Demon),
            MonsterType.Common),
            () => new Monster ("Bat", new Role {
                RoleType = RoleType.Demon,
                Strength = 2,
                Dexterity = 2,
                Constitution = 4,
                Intelligence = 3
            }, CardDealer.GetStartingDeck(5, 5, 1, RoleType.Demon),
            MonsterType.Common)
        };

        private static List<Func<Monster>> eliteDemons = new List<Func<Monster>> {
            () => new Monster ("Vampire Lord", new Role {
                RoleType = RoleType.Demon,
                Strength = 4,
                Dexterity = 4,
                Constitution = 10,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(5, 5, 2, RoleType.Demon, 2),
            MonsterType.Elite)
        };

        private static List<Func<Monster>> elves = new List<Func<Monster>> {
            () => new Monster ("Dark elf", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 6,
                Constitution = 3,
                Intelligence = 3
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Elf),
            MonsterType.Common),
            () => new Monster ("Forest elf", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 7,
                Constitution = 3,
                Intelligence = 5
            }, CardDealer.GetStartingDeck(5, 5, 2, RoleType.Elf),
            MonsterType.Common)
        };

        private static List<Func<Monster>> eliteElves = new List<Func<Monster>> {
            () => new Monster ("Eleven King", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 10,
                Constitution = 6,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Elf, 3),
            MonsterType.Elite),
            () => new Monster ("Elven Queen", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 12,
                Constitution = 8,
                Intelligence = 4
            }, CardDealer.GetStartingDeck(5, 5, 2, RoleType.Elf, 4),
            MonsterType.Elite)
        };

        private static List<Func<Monster>> beasts = new List<Func<Monster>> {
            () => new Monster ("Fox", new Role {
                RoleType = RoleType.Beast,
                Strength = 2,
                Dexterity = 6,
                Constitution = 2,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Beast),
            MonsterType.Common),
            () => new Monster ("Wolf", new Role {
                RoleType = RoleType.Beast,
                Strength = 4,
                Dexterity = 2,
                Constitution = 3,
                Intelligence = 2
            }, CardDealer.GetStartingDeck(4, 3, 0, RoleType.Beast),
            MonsterType.Common),
            () => new Monster ("Boar", new Role {
                RoleType = RoleType.Beast,
                Strength = 3,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 0
            }, CardDealer.GetStartingDeck(2, 2, 0, RoleType.Beast),
            MonsterType.Common),
            () => new Monster ("Bear", new Role {
                RoleType = RoleType.Beast,
                Strength = 5,
                Dexterity = 1,
                Constitution = 7,
                Intelligence = 1
            }, CardDealer.GetStartingDeck(5, 5, 1, RoleType.Beast),
            MonsterType.Common)
        };

        private static List<Func<Monster>> eliteBeasts = new List<Func<Monster>> {
            () => new Monster ("Beastmaster", new Role {
                RoleType = RoleType.Beast,
                Strength = 5,
                Dexterity = 5,
                Constitution = 5,
                Intelligence = 5
            }, CardDealer.GetStartingDeck(4, 4, 2, RoleType.Beast, 2),
            MonsterType.Elite)
        };

        private static List<Func<Monster>> bosses = new List<Func<Monster>> {
            () => new Monster ("Mad king", new Role {
                RoleType = RoleType.Boss,
                Strength = 10,
                Dexterity = 2,
                Constitution = 15,
                Intelligence = 6
            }, CardDealer.GetStartingDeck(6, 8, 3, RoleType.Elf, 5),
            MonsterType.Boss)
        };

        public static Monster GetRandomMonsterByType(RoleType role)
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