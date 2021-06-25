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

        private static List<Func<Card>> rangers = new List<Func<Card>> {
            () =>
            new Card ("Light Crossbow") {
                Cost = 1,
                Damage = 4,
                Description = "Deal 4 damage.",
                CardType = CardType.Weapon
            },
            () =>
            new Card ("Heavy Crossbow") {
                Cost = 2,
                Damage = 10,
                Description = "Deal 10 damage.",
                CardType = CardType.Weapon
            },
            () =>
            new Card ("Short Bow") {
                Cost = 1,
                Damage = 5,
                CardType = CardType.Weapon
            },
            () =>
            new Card ("Composite Bow") {
                Cost = 2,
                Damage = 12,
                CardType = CardType.Weapon
            },
            () =>
            new Card ("Elemental Arrow") {
                Cost = 0,
                Damage = 3,
                CardType = CardType.Skill
            },
            () =>
            new Card ("Multishot") {
                Cost = 0,
                Damage = 2,
                CardType = CardType.Skill,
                IsMultiTarget = true
            },
            () =>
            new Card ("Leather hide") {
                Cost = 1,
                Description = "The skin thickens.",
                Boost = (Character character) => {                    
                    character.Defend(10);                  
                },
                CardType = CardType.Spell
            },
            () =>
            new Card ("Cloak") {
                Cost = 2,
                Description = "Almost become invisible.",
                Boost = (Character character) => {
                    character.Heal(8); 
                    character.Defend(7);                  
                },
                CardType = CardType.Spell
            },
            () =>
            new Card ("Light heal") {
                Cost = 1,
                Description = "Put some bandages on your wounds.",
                Boost = (Character character) => {
                    character.Heal(6);                   
                },
                CardType = CardType.Spell
            },
            () =>
            new Card ("Heal") {
                Cost = 2,
                Description = "Pop some pills. All the pain goes away.",
                Boost = (Character character) => {
                    character.Heal(12);                   
                },
                CardType = CardType.Spell
            },
        };     

        public static List<Card> GetAllCommons()
        {
            return commons.Select(c => c()).ToList();
        }

        public static Card GetRandomCardByRole(RoleType role)
        {
            var random = new Random();
            var index = 0;
            switch (role)
            {
                case RoleType.Ranger:
                    index = random.Next(0, rangers.Count);
                    return rangers[index]();
                default:
                    index = random.Next(0, commons.Count);
                    return commons[index]();
            }
        }
    }
}