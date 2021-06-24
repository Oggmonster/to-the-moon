using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class CardData
    {
        /* important to create new cards each time one uses these lists to avoid getting duplicate ids
        when cards are created */
        private static List<Func<Card>> commons = new List<Func<Card>> {
            () =>
            new Card ("Magic Arrow") {
                Cost = 1,
                Damage = 2
            },
            () =>
            new Card ("Wish") {
                Cost = 1,
                DrawCount = 2
            },
            () =>
            new Card ("Fireball") {
                Cost = 1,
                Damage = 7
            },
            () =>
            new Card ("Heal") {
                Cost = 1,
                Heal = 6
            },
            () =>
            new Card ("Stoneskin") {
                Cost = 1,
                Block = 6,
                DexterityModify = 1
            },
            () =>
            new Card ("Electric Field") {
                Cost = 1,
                StrengthModify = 1,
                Block = 7
            },
            () =>
            new Card ("Iceblast") {
                Cost = 1,
                Damage = 4,
                DexterityModify = -1
            },
            () =>
            new Card ("Lightning Bolt") {
                Cost = 1,
                Damage = 5,
                StrengthModify = -1
            },
            () =>
            new Card ("Chain Lightning") {
                Cost = 2,
                Damage = 5,
                StrengthModify = -1,
                IsMultiTarget = true
            },

        };        

        public static List<Card> GetAllCommons()
        {
            return commons.Select(c => c()).ToList();
        }





    }
}