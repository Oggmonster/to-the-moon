using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{
    public class PlaceData
    {
        private static List<Func<Place>> places = new List<Func<Place>> {
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "A ring of mushrooms surrounded by tall pine trees reaching for the clouds.",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 5,
                        RoomType = RoomType.CampFire
                    },
                    new RoomProbability {
                        Start = 6,
                        End = 15,
                        RoomType = RoomType.Merchant
                    },
                    new RoomProbability {
                        Start = 16,
                        End = 75,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 76,
                        End = 100,
                        RoomType = RoomType.Chance
                    }
                },
                MonsterTypes = new List<RoleType> {
                    RoleType.Beast,
                    RoleType.Elf,
                    RoleType.Creep
                }
            },
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "Tall trees covering the sun. It's dark.",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 80,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 81,
                        End = 100,
                        RoomType = RoomType.Chance
                    }
                },
                MonsterTypes = new List<RoleType> {
                    RoleType.Beast,
                    RoleType.Elf,
                    RoleType.Undead,
                    RoleType.Creep
                }
            },
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "On a ledge sits a wise looking Owl",
                RoomProbabilities = new List<RoomProbability>
                {                    
                    new RoomProbability {
                        Start = 0,
                        End = 100,
                        RoomType = RoomType.Chance
                    }
                },
                MonsterTypes = new List<RoleType> {
                    RoleType.Beast,
                }
            },
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "This enormous Oak is as old as the earth itself",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 9,
                        RoomType = RoomType.Treasure
                    },
                    new RoomProbability {
                        Start = 10,
                        End = 90,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 91,
                        End = 100,
                        RoomType = RoomType.Chance
                    }
                },
                MonsterTypes = new List<RoleType> {                    
                    RoleType.Elf
                }
            },
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "Someone has chopped down a bunch of trees over here and cleared up some space",
                RoomProbabilities = new List<RoomProbability>
                {                    
                    new RoomProbability {
                        Start = 0,
                        End = 30,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 31,
                        End = 100,
                        RoomType = RoomType.Merchant
                    }
                },
                MonsterTypes = new List<RoleType> {                    
                    RoleType.Elf,
                    RoleType.Beast
                }
            },
            () => new Place {
                PlaceType = PlaceType.Forest,
                Description = "It looks like a cosy little cottage in the middle of the forest",
                RoomProbabilities = new List<RoomProbability>
                {                    
                    new RoomProbability {
                        Start = 0,
                        End = 30,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 31,
                        End = 70,
                        RoomType = RoomType.Blacksmith
                    },
                    new RoomProbability {
                        Start = 71,
                        End = 100,
                        RoomType = RoomType.CampFire
                    }
                },
                MonsterTypes = new List<RoleType> {                    
                    RoleType.Elf,
                    RoleType.Beast,
                    RoleType.Dwarf,
                }
            },
            () => new Place {
                PlaceType = PlaceType.Cave,
                Description = "The murky sky with the pouring rain almost hide a small cave entrance.",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 15,
                        RoomType = RoomType.Treasure
                    },
                    new RoomProbability {
                        Start = 16,
                        End = 69,
                        RoomType = RoomType.Combat
                    },
                    new RoomProbability {
                        Start = 70,
                        End = 100,
                        RoomType = RoomType.Chance
                    }
                },
                MonsterTypes = new List<RoleType> {
                    RoleType.Demon,
                    RoleType.Troll,
                    RoleType.Creep,
                    RoleType.Undead
                }
            },
            () => new Place {
                PlaceType = PlaceType.Cave,
                Description = "A giant pile of gold and shimmery things. Is there perhaps a dragon nearby?",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 50,
                        RoomType = RoomType.Treasure
                    },
                    new RoomProbability {
                        Start = 51,
                        End = 100,
                        RoomType = RoomType.Combat
                    },
                }, 
                MonsterTypes = new List<RoleType> {
                    RoleType.Dragon
                }
            },
        };

        private static List<Func<Place>> bossPlaces = new List<Func<Place>> {
            () => new Place {
                PlaceType = PlaceType.Castle,
                Description = "This magnificent castles looks like something right out of a children story.",
                RoomProbabilities = new List<RoomProbability>
                {
                    new RoomProbability {
                        Start = 0,
                        End = 100,
                        RoomType = RoomType.Combat
                    }
                },
                MonsterTypes = new List<RoleType> {
                    RoleType.Boss
                }
            }
        };

        public static Place GetRandomPlace()
        {
            return OptionPicker.PickRandomOption<Func<Place>>(places)();
        }

        public static List<Func<Place>> GetAllPlaces() {
            return places;
        }

        public static Place GetRandomBossPlace()
        {
            return OptionPicker.PickRandomOption<Func<Place>>(bossPlaces)();
        }
    }
}