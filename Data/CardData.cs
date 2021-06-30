using System.Collections.Generic;
using System.Linq;
using System;

namespace to_the_moon
{
    public class CardData
    {

        /* important to create new cards each time one uses these lists to avoid getting duplicate ids
        when cards are created */

        private static List<Func<Card>> weapons = new List<Func<Card>> {
            () =>
            new Card (Armory.LightCrossBow.Name) {
                Cost = 1,
                Description = "Light and crossbowy",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.RangedWeapon = Armory.LightCrossBow;
                    Console.WriteLine($"{attacker.Name} equips {Armory.LightCrossBow.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.HeavyCrossBow.Name) {
                Cost = 2,
                Description = "Definitely heavier than the light one",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.RangedWeapon = Armory.HeavyCrossBow;
                    Console.WriteLine($"{attacker.Name} equips {Armory.HeavyCrossBow.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.ShortBow.Name) {
                Cost = 1,
                Description = "Small but does the trick",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.RangedWeapon = Armory.ShortBow;
                    Console.WriteLine($"{attacker.Name} equips {Armory.ShortBow.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.CompositeBow.Name) {
                Cost = 1,
                Description = "A Rangers best friend",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.RangedWeapon = Armory.CompositeBow;
                    Console.WriteLine($"{attacker.Name} equips {Armory.CompositeBow.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.Dagger.Name) {
                Cost = 1,
                Description = "Stabby thing",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MeeleWeapon = Armory.Dagger;
                    Console.WriteLine($"{attacker.Name} equips {Armory.Dagger.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.LongSword.Name) {
                Cost = 1,
                Description = "Any knight would be proud wielding this sword",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MeeleWeapon = Armory.LongSword;
                    Console.WriteLine($"{attacker.Name} wields {Armory.LongSword.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.BroadAxe.Name) {
                Cost = 1,
                Description = "Conan is looking for this one",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MeeleWeapon = Armory.BroadAxe;
                    Console.WriteLine($"{attacker.Name} equips {Armory.BroadAxe.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.Bardiche.Name) {
                Cost = 2,
                Description = "If you are strong enough to handle it you can do some serious damage",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MeeleWeapon = Armory.Bardiche;
                    Console.WriteLine($"{attacker.Name} equips {Armory.Bardiche.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.Wand.Name) {
                Cost = 1,
                Description = "Are you a wizard?",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MagicWeapon = Armory.Wand;
                    Console.WriteLine($"{attacker.Name} equips {Armory.Wand.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.Scepter.Name) {
                Cost = 1,
                Description = "Enchanting and beautiful",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MagicWeapon = Armory.Scepter;
                    Console.WriteLine($"{attacker.Name} equips {Armory.Scepter.Name}");
                    return new List<Card>();
                }
            },
            () =>
            new Card (Armory.Staff.Name) {
                Cost = 2,
                Description = "Long wooden staff that seems to be glowing slightly",
                IsReplayable = false,
                CardType = CardType.Weapon,
                Execute = (attacker, _) => {
                    attacker.CombatState.MagicWeapon = Armory.Staff;
                    Console.WriteLine($"{attacker.Name} equips {Armory.Staff.Name}");
                    return new List<Card>();
                }
            },
        };

        private static List<Func<Card>> commons = new List<Func<Card>> {
            () =>
            new Card ("Magic Arrow") {
                Cost = 0,
                Description = "Always hits its target",
                CardType = CardType.Magic,
                Execute = (attacker, defenders) => {
                    CardActions.MagicAttack(attacker, defenders, 1, 1);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Lightning strike") {
                Cost = 1,
                Description = "Never hits the same spot twice",
                CardType = CardType.Magic,
                Execute = (attacker, defenders) => {
                    CardActions.MagicAttack(attacker, defenders, 1, 3);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Fireball") {
                Cost = 1,
                Description = "Burn baby burn!",
                CardType = CardType.Magic,
                Execute = (attacker, defenders) => {
                    CardActions.MagicAttack(attacker, defenders, 1, 4);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Chain Lightning") {
                Cost = 2,
                Description = "Electricity for everyone",
                CardType = CardType.Magic,
                Execute = (attacker, defenders) => {
                    var aliveCount = defenders.Where(d => d.IsAlive()).Count();
                    CardActions.MagicAttack(attacker, defenders, aliveCount, 2);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Stone throw") {
                Cost = 0,
                Description = "Without sin",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 1);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Sure shot") {
                Cost = 1,
                Description = "Won't stop",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 3);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Sniper bullet") {
                Cost = 1,
                Description = "Right between the eyes",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 7);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Slash") {
                Cost = 0,
                Description = "Like a ninja",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 1);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Bash") {
                Cost = 1,
                Description = "Put all weight behind it",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 3);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Frenzy") {
                Cost = 1,
                Description = "Waving that pointy thing like a crazy person",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 2, 2);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Crush") {
                Cost = 1,
                Description = "Devastating blow",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 8);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Lucky Wish") {
                Cost = 1,
                Description = "Small energy boost and draw a card",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    attacker.Energy += 2;
                    var cards = attacker.Deck.Draw(1);
                    Console.WriteLine($"{attacker.Name}, +2 energy and {cards.First().Name} drawn");
                    return cards;
                }
            },
            () =>
            new Card ("Four leaf clover") {
                Cost = 2,
                Description = "More energy and cards",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    attacker.Energy += 3;
                    var cards = attacker.Deck.Draw(2);
                    Console.WriteLine($"{attacker.Name}, +3 energy and {string.Join(',', cards.Select(c => c.Name))} drawn");
                    return cards;
                }
            },
            () =>
            new Card ("Heal") {
                Cost = 2,
                Description = "Pop some pills. All the pain goes away",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} heal {attacker.Heal(12)} hp");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Light Heal") {
                Cost = 1,
                Description = "Put some bandages on them wounds",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} heal {attacker.Heal(6)} hp");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Stoneskin") {
                Cost = 1,
                Description = "Skin turns to stone",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} increase defence with {attacker.Defend(7, attacker.CombatState.Strength)}");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Leather Hide") {
                Cost = 1,
                Description = "The skin thickens",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} increase defence with {attacker.Defend(7, attacker.CombatState.Dexterity)}");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Electric Field") {
                Cost = 1,
                Description = "The sparks will protect",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} increase defence with {attacker.Defend(7, attacker.CombatState.Intelligence)}");
                    return new List<Card>();
                }
            },
        };

        private static List<Func<Card>> rangers = new List<Func<Card>> {
            () =>
            new Card ("Elemental Arrow") {
                Cost = 0,
                Description = "Pierces through armor",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 3);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Hungering Arrow") {
                Cost = 1,
                Description = "Fire a magically imbued arrow",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 5);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Double Shot") {
                Cost = 1,
                Description = "Two arrows is better than one",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 2, 3);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Multishot") {
                Cost = 1,
                Description = "One arrow for each enemy",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    var aliveCount = defenders.Where(d => d.IsAlive()).Count();
                    CardActions.RangedAttack(attacker, defenders, aliveCount, 2);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Impale") {
                Cost = 1,
                Description = "Knife right in the gut",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 4);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Vengeance") {
                Cost = 1,
                Description = "Furiosly hack and slash",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 5);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Poision Dagger") {
                Cost = 2,
                Description = "Are you an assassin?",
                CardType = CardType.Meele,
                Execute = (attacker, defenders) => {
                    CardActions.MeeleAttack(attacker, defenders, 1, 10);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Strafe") {
                Cost = 2,
                Description = "Spin and let the arrows fly",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    var aliveCount = defenders.Where(d => d.IsAlive()).Count();
                    CardActions.RangedAttack(attacker, defenders, aliveCount, 4);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Cluster Arrow") {
                Cost = 2,
                Description = "Fire a cluster arrow that explodes",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    var aliveCount = defenders.Where(d => d.IsAlive()).Count();
                    CardActions.RangedAttack(attacker, defenders, aliveCount, 6);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Fan of Knives") {
                Cost = 1,
                Description = "Throw knives out in a spiral around you",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    var aliveCount = defenders.Where(d => d.IsAlive()).Count();
                    CardActions.RangedAttack(attacker, defenders, aliveCount, 1);
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Cloak") {
                Cost = 2,
                Description = "Almost become invisible",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} increase defence with {attacker.Defend(7, attacker.CombatState.Dexterity)} and heal {attacker.Heal(6)} hp");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Perfectionist") {
                Cost = 2,
                Description = "You feel healthy",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    Console.WriteLine($"{attacker.Name} increase defence with {attacker.Defend(12, attacker.CombatState.Dexterity)} and heal {attacker.Heal(12)} hp");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Mooooar Cards!") {
                Cost = 1,
                Description = "You get a card! Yooou get a card! And yoooou get a card!",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    var cards = attacker.Deck.Draw(3);
                    Console.WriteLine($"{attacker.Name} draw {string.Join(',', cards.Select(c => c.Name))}");
                    return cards;
                }
            },
            () =>
            new Card ("Steady Aim") {
                Cost = 0,
                Description = "Keep your focus",
                CardType = CardType.Spell,
                Execute = (attacker, _) => {
                    attacker.Energy += 3;
                    Console.WriteLine($"{attacker.Name}, +3 energy");
                    return new List<Card>();
                }
            }
        };

        private static List<Func<Card>> warriors = new List<Func<Card>> {
            () =>
            new Card ("Lucky shot") {
                Cost = 0,
                Description = "This arrow just might hit",
                CardType = CardType.Ranged,
                Execute = (attacker, defenders) => {
                    CardActions.RangedAttack(attacker, defenders, 1, 2);
                    return new List<Card>();
                }
            },
        };

        private static RoleType GetRandomRoleType() {
            return OptionPicker.PickRandomOption<RoleType>(new List<RoleType> {
                        RoleType.Beast,
                        RoleType.Undead,
                        RoleType.Creep,
                        RoleType.Demon,
                        RoleType.Dragon,
                        RoleType.Elemental,
                        RoleType.Elf,
                        RoleType.Troll
                    });
        }

        private static RoleType GetSummonRoleType(RoleType roleType)
        {
            switch (roleType)
            {
                case RoleType.Warrior:
                case RoleType.Ranger:
                case RoleType.Cleric:
                case RoleType.Mage:
                case RoleType.Boss:
                    return GetRandomRoleType();              
                default:
                    return roleType;
            }
        }

        private static List<Func<Card>> summons = new List<Func<Card>> {
            () =>
            new Card ("Get over here") {
                Cost = 1,
                Description = "Summon 1 monster",
                CardType = CardType.Summon,
                Execute = (attacker, _) => {
                    var roleType = GetSummonRoleType(attacker.Role.RoleType);
                    var monster = MonsterData.GetRandomMonsterByType(roleType);                    
                    attacker.AddMinion(monster);
                    Console.WriteLine($"{monster.Name} joins the fight");
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Bring on the twins") {
                Cost = 2,
                Description = "Summon 2 monsters",
                CardType = CardType.Summon,
                Execute = (attacker, _) => {
                    var roleType = GetSummonRoleType(attacker.Role.RoleType);
                    for (int i = 0; i < 2; i++)
                    {
                        var minion = MonsterData.GetRandomMonsterByType(roleType);
                        Console.WriteLine($"{minion.Name} joins the fight");
                        attacker.AddMinion(minion);                        
                    }                    
                    return new List<Card>();
                }
            },
            () =>
            new Card ("Here comes trouble") {
                Cost = 3,
                Description = "Summon 3 monsters",
                CardType = CardType.Summon,
                Execute = (attacker, _) => {
                    var roleType = GetSummonRoleType(attacker.Role.RoleType);
                    for (int i = 0; i < 3; i++)
                    {
                        var minion = MonsterData.GetRandomMonsterByType(roleType);
                        Console.WriteLine($"{minion.Name} joins the fight");
                        attacker.AddMinion(minion);                        
                    }                    
                    return new List<Card>();
                }
            }, 
        };

        public static Card GetRandomWeaponCard()
        {
            return OptionPicker.PickRandomOption<Func<Card>>(weapons)();
        }

        public static Card GetRandomSummonCard()
        {
            return OptionPicker.PickRandomOption<Func<Card>>(summons)();
        }

        public static Card GetRandomCommonCard()
        {
            return OptionPicker.PickRandomOption<Func<Card>>(commons)();
        }

        public static Card GetRandomCardByRole(RoleType role)
        {
            switch (role)
            {
                case RoleType.Ranger:
                    return OptionPicker.PickRandomOption<Func<Card>>(rangers)();
                case RoleType.Warrior:
                    return OptionPicker.PickRandomOption<Func<Card>>(warriors)();
                default:
                    return OptionPicker.PickRandomOption<Func<Card>>(commons)();
            }
        }
    }
}