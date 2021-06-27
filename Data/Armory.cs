namespace to_the_moon
{
    public class Armory
    {
        public static Weapon LightCrossBow => new Weapon
        {
            Damage = 3,
            Name = "Light Crossbow",
            Type = WeaponType.Ranged
        };

        public static Weapon HeavyCrossBow => new Weapon
        {
            Damage = 7,
            Name = "Heavy Crossbow",
            Type = WeaponType.Ranged
        };

        public static Weapon ShortBow => new Weapon
        {
            Damage = 2,
            Name = "Short Bow",
            Type = WeaponType.Ranged
        };

        public static Weapon CompositeBow => new Weapon
        {
            Damage = 10,
            Name = "Composite Bow",
            Type = WeaponType.Ranged
        };

        public static Weapon Dagger => new Weapon
        {
            Damage = 2,
            Name = "Dagger",
            Type = WeaponType.Meele
        };

        public static Weapon LongSword => new Weapon
        {
            Damage = 9,
            Name = "Long Sword",
            Type = WeaponType.Meele
        };

        public static Weapon BroadAxe => new Weapon
        {
            Damage = 11,
            Name = "BroadAxe",
            Type = WeaponType.Meele
        };

        public static Weapon Bardiche => new Weapon
        {
            Damage = 13,
            Name = "Bardiche",
            Type = WeaponType.Meele
        };

        public static Weapon Wand => new Weapon
        {
            Damage = 4,
            Name = "Wand",
            Type = WeaponType.Magic
        };

        public static Weapon Scepter => new Weapon
        {
            Damage = 6,
            Name = "Scepter",
            Type = WeaponType.Magic
        };

        public static Weapon Staff => new Weapon
        {
            Damage = 8,
            Name = "Staff",
            Type = WeaponType.Magic
        };
    }
}