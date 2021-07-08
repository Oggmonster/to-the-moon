using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace to_the_moon
{
    public class OptionPicker
    {
        private static void DisplayOptions<T>(List<T> options, string exitOption)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i].ToString()}");
            }
            if (!string.IsNullOrEmpty(exitOption))
            {
                Console.WriteLine($"0. {exitOption}");
            }

        }
        /*
        public static T PickOption<T>(List<T> options, string prompt = "Choose: ", string exitOption = "") {
            DisplayOptions<T>(options, exitOption);
            Console.Write(prompt);            
            var option = Console.ReadLine();
            if (int.TryParse(option, out int index)) {
                if (index == 0) {
                    return default(T);
                } else {
                    index--;
                }
                if (index < options.Count && index >= 0) {
                    var picked = options[index];                    
                    return picked;
                }                                
            }
            //try again
            Console.WriteLine("Not a valid option - please enter a number - try again");
            return PickOption(options);
        }
        */

        public static T PickOption<T>(List<T> options, string prompt = "Choose: ", string exitOption = "")
        {            
            if (string.IsNullOrEmpty(exitOption)) {
                return AnsiConsole.Prompt(new SelectionPrompt<T>().PageSize(15).AddChoices(options));
            }
            var stringOptions = options.Select(o => o.ToString()).ToList();
            stringOptions.Add(exitOption);
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>().PageSize(15).AddChoices(stringOptions));
            return options.FirstOrDefault(o => o.ToString() == option);
        }
        
        public static T PickRandomOption<T>(List<T> options)
        {
            if (options.Count == 0)
            {
                return default(T);
            }
            if (options.Count == 1)
            {
                return options.First();
            }
            var random = new Random();
            var index = random.Next(0, options.Count);
            return options[index];
        }

        public static bool ConfirmPrompt()
        {
            var options = new List<string> {
                "Yes",
                "No"
            };
            var option = PickOption<string>(options);
            return option == "Yes";
        }

        public static void AnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}