using System;
using System.Collections.Generic;
using System.Linq;

namespace to_the_moon
{
    public class Mysteries
    {
        private static List<Action<Player>> mysteries = new List<Action<Player>>
        {
            (player) => {
                Console.WriteLine("A Blonde Redhead pops up from a hole in the ground and ask you a question.");
                Console.WriteLine("-You give me an artifact and I'll give you...AN ARTIFACT! DO YOU ACCEPT???!!");
                if (OptionPicker.ConfirmPrompt()) {
                    if (player.Artifacts.Count == 0) {
                        Console.WriteLine("-YOU FOOL YOU DON'T HAVE ANY ARTIFACTS. GTFO!");
                        return;
                    }
                    Console.WriteLine("Pick one of your artifacts to trade:");
                    var artifact = OptionPicker.PickOption<Artifact>(player.Artifacts);
                    player.Artifacts.Remove(artifact);
                    var newArtifact = LostTreasure.GetRandomArtifact();
                    player.Artifacts.Add(newArtifact);
                    Console.WriteLine($"{newArtifact.ToString()} added");
                    Console.WriteLine("-THANKS VERY MUCH. HA HA HHAHHAHAHAH!");
                }
                Console.WriteLine("The Blonde Redhead disappears in a cloud of smoke");
            },
            (player) => {
                Console.WriteLine("A miserable bastards approches you.");
                Console.WriteLine("-Give me all your gold and I will give you more life. DO WE HAVE A DEAL?");
                if (OptionPicker.ConfirmPrompt()) {
                    Console.WriteLine("-Sweet. Here drink this.");
                    Console.WriteLine("The bastard hands you a potion. You drink it.");
                    var rnd = new Random();
                    var num = rnd.Next(10, 30);
                    player.Gold = 0;
                    player.MaxHealth += num;
                    Console.WriteLine("You no longer have any gold but you feel full of life");
                }
                Console.WriteLine("The miserable bastard turns into a happy bloke and skips away");
            },
            (player) => {
                Console.WriteLine("You suddenly feel a cold hand on your shoulder. It's a vampire!");
                Console.WriteLine("-I will make you smart if you give me some bloooood. Stop being a dumb dumb?");
                if (OptionPicker.ConfirmPrompt()) {
                    player.IncomingAttack(20);
                    if (player.IsAlive()) {
                        player.Role.Intelligence += 5;
                        Console.WriteLine("You gain 5 int");
                    } else {
                        Console.WriteLine("You died!");
                    }
                }
                Console.WriteLine("The vampire hides in a coffin");
            },
            (player) => {
                Console.WriteLine("Suddenly The Mountain King stands in front of you.");
                Console.WriteLine("-I need the sword Excalibur. I will give a great reward. Do you have it?");
                if (OptionPicker.ConfirmPrompt()) {
                    var excalibur = player.Artifacts.FirstOrDefault(a => a.Name == Armory.Excalibur.Name);
                    if (excalibur == null) {
                        Console.WriteLine("-LIIIAAAARRR!!! The King attacks you");
                        player.IncomingAttack(40);
                        if (!player.IsAlive()) {
                            Console.WriteLine("...and you are dead");
                        }
                    } else {
                        player.Artifacts.Remove(excalibur);
                        Console.WriteLine("You give the sword to the King and the King keeps his promise.");
                        player.MaxHealth += 40;
                        player.Health = player.MaxHealth;
                        player.Role.Strength += 10;
                        player.Role.Dexterity += 10;
                        player.Role.Intelligence += 10;
                        player.Role.Constitution += 10;

                    }
                }
                Console.WriteLine("The King raises Excalibur to the sky in triumph, gets struck by lightning and dies.");
            },
            (player) => {
                Console.WriteLine("You stand in front of a lake and you hear a whispering voice from the left. It's a mermaid.");
                Console.WriteLine("-I'm looking for my lost wand Starfire. I will give a great reward if you find it for me. Do you have it?");
                if (OptionPicker.ConfirmPrompt()) {
                    var starfire = player.Artifacts.FirstOrDefault(a => a.Name == Armory.Starfire.Name);
                    if (starfire == null) {
                        Console.WriteLine("-Oh well");
                        return;
                    }
                    player.Artifacts.Remove(starfire);
                    Console.WriteLine("You give the wand to the Mermaid and you feel much stronger.");
                    player.MaxHealth += 40;
                    player.Health = player.MaxHealth;
                    player.Role.Strength += 10;
                    player.Role.Dexterity += 10;
                    player.Role.Intelligence += 10;
                    player.Role.Constitution += 10;
                }
                Console.WriteLine("The Mermaid swims away.");
            },
            (player) => {
                Console.WriteLine("You stand in front of a lake and you hear a whispering voice from the left. It's a mermaid.");
                Console.WriteLine("-I'm looking for my lost wand Starfire. I will give a great reward if you find it for me. Do you have it?");
                if (OptionPicker.ConfirmPrompt()) {
                    var starfire = player.Artifacts.FirstOrDefault(a => a.Name == Armory.Starfire.Name);
                    if (starfire == null) {
                        Console.WriteLine("-Oh well");
                        return;
                    }
                    player.Artifacts.Remove(starfire);
                    Console.WriteLine("You give the wand to the Mermaid and you feel much stronger.");
                    player.MaxHealth += 40;
                    player.Health = player.MaxHealth;
                    player.Role.Strength += 10;
                    player.Role.Dexterity += 10;
                    player.Role.Intelligence += 10;
                    player.Role.Constitution += 10;
                }
                Console.WriteLine("The Mermaid swims away.");
            },
            (player) => {
                Console.WriteLine("You find yourself in the deepest forest a deer locks eyes with you. It can be speak.");
                Console.WriteLine("-I want Windforce. Give me?");
                if (OptionPicker.ConfirmPrompt()) {
                    var windforce = player.Artifacts.FirstOrDefault(a => a.Name == Armory.Windforce.Name);
                    if (windforce == null) {
                        Console.WriteLine("-Pffft");
                        return;
                    }
                    player.Artifacts.Remove(windforce);
                    Console.WriteLine("You give Windforce to the deer. It rewards you greatly.");
                    player.MaxHealth += 60;
                    player.Health = player.MaxHealth;
                    player.Role.Strength += 20;
                    player.Role.Dexterity += 20;
                    player.Role.Intelligence += 20;
                    player.Role.Constitution += 20;
                }
                Console.WriteLine("The deer turns into an Elven Queen and wishes you safe travels.");
            },
        };

        public static Action<Player> GetRandomMystery()
        {
            var mystery = OptionPicker.PickRandomOption<Action<Player>>(mysteries);
            mysteries.Remove(mystery);
            return mystery;
        }


    }
}