using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class ConsoleOptionPicker
    {
        private static void DisplayOptions<T>(List<T> options, string exitOption) {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i+1}. {options[i].ToString()}");
            }
            if (!string.IsNullOrEmpty(exitOption)) {
                Console.WriteLine($"0. {exitOption}");
            }

        }
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
            Console.WriteLine("Not a vailid option - please enter a number - try again");
            return PickOption(options);
        }

        public static bool ConfirmPrompt() {
            var options = new List<string> {
                "Yes", 
                "No"
            };
            var option = PickOption<string>(options);
            return option == "Yes";
        }

    }
}