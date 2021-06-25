using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class MonsterData
    {
        private static Deck GetSimpleDeck(int attacks, int blocks, int heals)
        {
            var commons = CardData.GetAllCommons();
            var cards = new List<Card>();
            var r = new Random();
            if (attacks > 0)
            {
                var attackCards = commons.Where(c => c.Damage > 0).OrderBy(c => r.Next()).Take(attacks);
                cards.AddRange(attackCards);
            }
            if (blocks > 0)
            {
                var blockCards = commons.Where(c => c.Block > 0).OrderBy(c => r.Next()).Take(blocks);
                cards.AddRange(blockCards);
            }
            if (heals > 0)
            {
                var healCards = commons.Where(c => c.Heal > 0).OrderBy(c => r.Next()).Take(heals);
                cards.AddRange(healCards);
            }
            return new Deck(cards);
        }
        private static List<Func<Monster>> creeps = new List<Func<Monster>> {
            () => new Monster ("Slime", new Role {
                RoleType = RoleType.Creep,
                Strength = 2,
                Dexterity = 0,
                Constitution = 1,
                Intelligence = 0
            }, GetSimpleDeck(2, 3, 1))
        };

        private static List<Func<Monster>> demons = new List<Func<Monster>> {
            () => new Monster ("Gargoyle", new Role {
                RoleType = RoleType.Demon,
                Strength = 4,
                Dexterity = 3,
                Constitution = 4,
                Intelligence = 3
            }, GetSimpleDeck(4, 3, 2))
        };

        private static List<Func<Monster>> elves = new List<Func<Monster>> {
            () => new Monster ("Dark elf", new Role {
                RoleType = RoleType.Elf,
                Strength = 2,
                Dexterity = 6,
                Constitution = 3,
                Intelligence = 3
            }, GetSimpleDeck(4, 3, 2))
        };

        private static List<Func<Monster>> beasts = new List<Func<Monster>> {
            () => new Monster ("Slime", new Role {
                RoleType = RoleType.Creep,
                Strength = 2,
                Dexterity = 0,
                Constitution = 1,
                Intelligence = 0
            }, GetSimpleDeck(2, 3, 1)),
            () => new Monster ("Wolf", new Role {
                RoleType = RoleType.Beast,
                Strength = 4,
                Dexterity = 2,
                Constitution = 3,
                Intelligence = 2
            }, GetSimpleDeck(4, 1, 1)),
            () => new Monster ("Boar", new Role {
                RoleType = RoleType.Beast,
                Strength = 3,
                Dexterity = 1,
                Constitution = 2,
                Intelligence = 0
            }, GetSimpleDeck(2, 0, 0)),
            () => new Monster ("Bear", new Role {
                RoleType = RoleType.Beast,
                Strength = 5,
                Dexterity = 1,
                Constitution = 7,
                Intelligence = 1
            }, GetSimpleDeck(3, 3, 1))
        };

        private static List<Func<Monster>> bosses = new List<Func<Monster>> {
            () => new Monster ("Mad king", new Role {
                RoleType = RoleType.Boss,
                Strength = 10,
                Dexterity = 2,
                Constitution = 15,
                Intelligence = 6
            }, GetSimpleDeck(7, 6, 2))
        };

        public static Monster GetRandomMonsterByType(RoleType role, int level)
        {
            var random = new Random();
            var index = 0;
            switch (role)
            {
                case RoleType.Beast:
                    index = random.Next(0, beasts.Count);
                    return beasts[index]();
                case RoleType.Creep:
                    index = random.Next(0, creeps.Count);
                    return creeps[index]();
                case RoleType.Demon:
                    index = random.Next(0, demons.Count);
                    return demons[index]();
                case RoleType.Elf:
                    index = random.Next(0, elves.Count);
                    return elves[index]();
                case RoleType.Boss:
                    index = random.Next(0, bosses.Count);
                    return bosses[index]();
                default:
                    return beasts[0]();
            }
        }
    }
}