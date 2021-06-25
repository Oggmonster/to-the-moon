using System;
using System.Collections.Generic;

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
                    RoleType.Creep
                }
            }
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
            var random = new Random();
            var index = random.Next(0, places.Count);
            return places[index]();
        }

        public static Place GetRandomBossPlace()
        {
            var random = new Random();
            var index = random.Next(0, bossPlaces.Count);
            return bossPlaces[index]();
        }
    }
}