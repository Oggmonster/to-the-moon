using System;
namespace to_the_moon
{
    public class Blacksmith
    {
        private static string title = @"
 _______  ___      _______  _______  ___   _  _______  __   __  ___   _______  __   __ 
|  _    ||   |    |   _   ||       ||   | | ||       ||  |_|  ||   | |       ||  | |  |
| |_|   ||   |    |  |_|  ||       ||   |_| ||  _____||       ||   | |_     _||  |_|  |
|       ||   |    |       ||       ||      _|| |_____ |       ||   |   |   |  |       |
|  _   | |   |___ |       ||      _||     |_ |_____  ||       ||   |   |   |  |       |
| |_|   ||       ||   _   ||     |_ |    _  | _____| || ||_|| ||   |   |   |  |   _   |
|_______||_______||__| |__||_______||___| |_||_______||_|   |_||___|   |___|  |__| |__|
";

        public static void Go(Player player) {
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine("This beastly human being gladly removes a card from your deck, if you want?");
            if (OptionPicker.ConfirmPrompt()) {
                var card = OptionPicker.PickOption<Card>(player.Deck.GetAllCards());
                Console.WriteLine($"Are you sure you want to remove {card.Name}?");
                if (OptionPicker.ConfirmPrompt()) {
                    player.Deck.RemoveCard(card.Id);
                    Console.WriteLine($"{card.Name} removed from your deck");
                }
            }
            OptionPicker.AnyKeyToContinue();
        }

    }
}