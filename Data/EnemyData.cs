using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class EnemyData
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
        private static List<Func<Enemy>> simpletons = new List<Func<Enemy>> {
            () => new Enemy ("Slime", 10, 0, 1, GetSimpleDeck(2, 3, 1)),
            () => new Enemy ("Wolf", 15, 1, 1, GetSimpleDeck(4, 1, 1)),
            () => new Enemy ("Boar", 9, 0, 0, GetSimpleDeck(2, 0, 0)),
            () => new Enemy ("Bear", 20, 2, 2, GetSimpleDeck(3, 3, 1))
        };

        public static Enemy GetRandomSimpleton()
        {
            var random = new Random();
            var index = random.Next(0, simpletons.Count);
            return simpletons[index]();
        }


        public static List<Enemy> GetAllSimpletons() {
            return simpletons.Select(s => s()).ToList();
        }
    }
}