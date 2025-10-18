using System;
using System.Collections.Generic;
using System.Linq;

namespace wfcharcreator
{
    internal static class WarframeDB
    {
        private static List<Warframe> warframes = new List<Warframe>
        {
            new Warframe(
                "Excalibur",
                "A perfect balance of mobility and offense, Excalibur is ideal for new players.",
                health: 100,
                shields: 100,
                armor: 225,
                energy: 100
            )
            {
                Abilities = new List<Ability>
                {
                    new Ability("Slash Dash", "Excalibur dashes between enemies, slashing with his sword."),
                    new Ability("Radial Blind", "Emits a bright flash of light, blinding nearby enemies."),
                    new Ability("Radial Javelin", "Launches javelins toward nearby enemies."),
                    new Ability("Exalted Blade", "Summons a sword of light that sends out energy waves.")
                }
            },

            new Warframe(
                "Mag",
                "A manipulator of magnetic energy, Mag can control enemy positions and strip their defenses.",
                health: 75,
                shields: 150,
                armor: 65,
                energy: 150
            )
            {
                Abilities = new List<Ability>
                {
                    new Ability("Pull", "Pulls enemies toward Mag, dealing damage."),
                    new Ability("Magnetize", "Traps enemies in a magnetic field that amplifies damage."),
                    new Ability("Polarize", "Restores shields to allies and damages enemy armor."),
                    new Ability("Crush", "Lifts and shatters enemies using magnetic force.")
                }
            },

            new Warframe(
                "Volt",
                "Volt can create and harness electrical elements. Perfect for players looking for high-speed combat.",
                health: 100,
                shields: 150,
                armor: 100,
                energy: 100
            )
            {
                Abilities = new List<Ability>
                {
                    new Ability("Shock", "Launches a shocking projectile that stuns enemies."),
                    new Ability("Speed", "Boosts movement speed for Volt and nearby allies."),
                    new Ability("Electric Shield", "Deploys a shield that blocks projectiles."),
                    new Ability("Discharge", "Releases a wave of electricity that paralyzes enemies.")
                }
            }
        };

        // Retrieve all warframes
        public static List<Warframe> GetAll()
        {
            return warframes;
        }

        //AI helper generated method to get warframe by name
        public static Warframe? GetByName(string name)
        {
            return warframes.FirstOrDefault(w =>
                w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        //AI generated method to select a warframe from the console
        public static Warframe SelectWarframe()
        {
            Console.WriteLine("\nAvailable Warframes:\n");
            for (int i = 0; i < warframes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {warframes[i].Name} - {warframes[i].Description}");
            }

            Console.Write("\nSelect your Warframe (enter number): ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > warframes.Count)
            {
                Console.Write("Invalid choice. Try again: ");
            }

            var selected = warframes[choice - 1];
            Console.WriteLine($"\nYou selected: {selected.Name}!\n");
            return selected;
        }
    }
}
