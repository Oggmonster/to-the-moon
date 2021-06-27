using System;
namespace to_the_moon
{
    public class Treasure
    {
        private static string title = @"
 _______  ______    _______  _______  _______  __   __  ______    _______ 
|       ||    _ |  |       ||   _   ||       ||  | |  ||    _ |  |       |
|_     _||   | ||  |    ___||  |_|  ||  _____||  | |  ||   | ||  |    ___|
  |   |  |   |_||_ |   |___ |       || |_____ |  |_|  ||   |_||_ |   |___ 
  |   |  |    __  ||    ___||       ||_____  ||       ||    __  ||    ___|
  |   |  |   |  | ||   |___ |   _   | _____| ||       ||   |  | ||   |___ 
  |___|  |___|  |_||_______||__| |__||_______||_______||___|  |_||_______|
";
        public static void Go(Player player, int level, int stepCount) {
            Console.WriteLine(title);
            Console.WriteLine();
            var artifact = LostTreasure.GetRandomArtifact();
            Console.WriteLine($"You find {artifact.ToString()}. Do you want it?");
            if (OptionPicker.ConfirmPrompt()) {
                player.Artifacts.Add(artifact);
                Console.WriteLine($"{artifact.Name} added");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}