using System;
using System.Collections.Generic;

namespace to_the_moon
{
    public class ConsoleOptionPicker
    {
        private static void DisplayOptions<T>(List<T> options) {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i}. {options[i].ToString()}");
            }
        }
        public static T PickOption<T>(List<T> options) {
            DisplayOptions<T>(options);
            Console.Write("Pick one (enter number): ");            
            var option = Console.ReadLine();
            if (int.TryParse(option, out int index)) {
                if (index < options.Count && index >= 0) {
                    var picked = options[index];
                    return picked;
                }                                
            }
            //try again
            Console.WriteLine("Not a vailid option - try again");
            return PickOption(options);
        }

    }
}