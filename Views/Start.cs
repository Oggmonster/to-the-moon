using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class Start
    {
        private static string title = @"
 _______  _______    _______  __   __  _______    __   __  _______  _______  __    _   
|       ||       |  |       ||  | |  ||       |  |  |_|  ||       ||       ||  |  | |  
|_     _||   _   |  |_     _||  |_|  ||    ___|  |       ||   _   ||   _   ||   |_| |  
  |   |  |  | |  |    |   |  |       ||   |___   |       ||  | |  ||  | |  ||       |  
  |   |  |  |_|  |    |   |  |       ||    ___|  |       ||  |_|  ||  |_|  ||  _    |  
  |   |  |       |    |   |  |   _   ||   |___   | ||_|| ||       ||       || | |   |  
  |___|  |_______|    |___|  |__| |__||_______|  |_|   |_||_______||_______||_|  |__|  
";
        //return player and level
        public static (Player player, int level) Go()
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            var options = new List<string> {
                "New Game",
                "Continue",
            };
            Console.WriteLine("Ctrl + C to exit");
            Console.WriteLine();
            var option = OptionPicker.PickOption<string>(options);
            Console.Clear();
            return option == "New Game" ? New() : Load();
        }       

        private static string GetName() {
            Console.WriteLine("What do you want to call yourself?");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"{name} is it?");
            if(OptionPicker.ConfirmPrompt()) {
                return name;
            }
            Console.WriteLine();
            return GetName();
        }

        private static Role GetRole() {
            Console.WriteLine("Select a role that fits your character");
            var role = OptionPicker.PickOption<Role>(PlayerRoles.GetPlayerRoles());
            return role;
        }

        private static (Player player, int level) New()
        {
            var header = @"
 __    _  _______  _     _    _______  __   __  _______  ___      ___      _______  __    _  _______  _______  ______   
|  |  | ||       || | _ | |  |       ||  | |  ||   _   ||   |    |   |    |       ||  |  | ||       ||       ||    _ |  
|   |_| ||    ___|| || || |  |       ||  |_|  ||  |_|  ||   |    |   |    |    ___||   |_| ||    ___||    ___||   | ||  
|       ||   |___ |       |  |       ||       ||       ||   |    |   |    |   |___ |       ||   | __ |   |___ |   |_||_ 
|  _    ||    ___||       |  |      _||       ||       ||   |___ |   |___ |    ___||  _    ||   ||  ||    ___||    __  |
| | |   ||   |___ |   _   |  |     |_ |   _   ||   _   ||       ||       ||   |___ | | |   ||   |_| ||   |___ |   |  | |
|_|  |__||_______||__| |__|  |_______||__| |__||__| |__||_______||_______||_______||_|  |__||_______||_______||___|  |_|
";
            
            Console.WriteLine(header);
            Console.WriteLine();
            var role = GetRole();
            Console.WriteLine();
            var name = GetName();            
            Console.WriteLine();
            var deck = CardDealer.GetStartingDeck(8, 8, 4, role.RoleType);
            var player = new Player(name, role, deck);
            Console.Clear();
            return (player, 1);
        }

        private static (Player player, int level) Load()
        {
            //read json from file or something
            return (new Player("hej", new Role {
                RoleType = RoleType.Warrior,
                Strength = 1,
                Dexterity = 1,
                Constitution = 1,
                Intelligence = 1
            }, new Deck(new List<Card> { new Card("hejs") })), 1);
        }

    }
}