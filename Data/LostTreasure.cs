using System.Collections.Generic;

namespace to_the_moon
{
    public class LostTreasure
    {
        private static List<Artifact> artifacts = new List<Artifact>
        {
            new Artifact ("Golden ring") {
                Description = "Increase Constitution by 2",
                Execute = (state) => {
                    state.Constitution += 2;
                }
            },
            new Artifact ("Ruby ring") {
                Description = "Increase Strength by 2",
                Execute = (state) => {
                    state.Strength += 2;
                }
            },
            new Artifact ("Emerald ring") {
                Description = "Increase Dexterity by 2",
                Execute = (state) => {
                    state.Dexterity += 2;
                }
            },
            new Artifact ("Saphire ring") {
                Description = "Increase Intelligence by 2",
                Execute = (state) => {
                    state.Intelligence += 2;
                }
            },
            new Artifact ("Obisidan ring of the Zodiac") {
                Description = "Add 5 to all attributes",
                Execute = (state) => {
                    state.Intelligence += 5;
                    state.Strength += 5;
                    state.Dexterity += 5;
                    state.Constitution += 5;
                }
            },
            new Artifact ("Windforce") {
                Description = "A legendary bow",
                Execute = (state) => {
                    state.Weapon = Armory.Windforce;
                }
            },
            new Artifact ("Excalibur") {
                Description = "A mighty sword",
                Execute = (state) => {
                    state.Weapon = Armory.Excalibur;
                }
            },
            new Artifact ("Starfire") {
                Description = "A magical wand",
                Execute = (state) => {
                    state.Weapon = Armory.Starfire;
                }
            },
        };

        public static Artifact GetRandomArtifact()
        {
            return OptionPicker.PickRandomOption<Artifact>(artifacts);
        }


    }
}