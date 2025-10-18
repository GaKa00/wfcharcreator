using System;
using System.Collections.Generic;
using System.Linq;

namespace wfcharcreator
{
    internal class Warframe
    {
        public string Name { get; set; }
        public string Description { get; set; }

     
        public int Health { get; set; }

        public int Level { get; set; } = 1;
        public int Shields { get; set; }
        public int Armor { get; set; }
        public int Energy { get; set; }

        private int StatPoints = 40;
     
        public List<Stat> Stats { get; set; }
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public Warframe(string name, string description, int health, int shields, int armor, int energy)
        {
            Name = name;
            Description = description;
            Health = health;
            Shields = shields;
            Armor = armor;
            Energy = energy;

            Stats = new List<Stat>
            {
                new Stat("Strength", 5),
                new Stat("Range", 5),
                new Stat("Duration", 5),
                new Stat("Endurance", 5)
            };
        }

    

        // --- WEAPONS ---
        public void EquipWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void AssignStartingWeapons()
        {
            // Simple starting weapons for demonstration
            EquipWeapon(new Weapon("MK1-Braton", Weapon.WeaponType.Primary, "d6", "Slashing"));
            EquipWeapon(new Weapon("MK1-Lato", Weapon.WeaponType.Secondary,  "d4", "Piercing"));
            EquipWeapon(new Weapon("Skana", Weapon.WeaponType.Melee, "d6", "Impact"));  
          
           
        }

        public void AllocateStat(string statName, int points)
        {
            var stat = Stats.FirstOrDefault(s =>
                s.Name.Equals(statName, StringComparison.OrdinalIgnoreCase));
            if (stat == null)
            {
                throw new Exception("Stat not found.");
            }
            if (points > StatPoints)
            {
                throw new Exception("Not enough stat points available.");
            }
            stat.Value += points;
            StatPoints -= points;
        }

        public void AllocateStatsInteractive()
        {

            while ( StatPoints > 0)
            {
                Console.WriteLine($"\nPoints remaining: {StatPoints}");

                Console.WriteLine("Warframe stats:");
                foreach (var stat in Stats)
                {
                    Console.WriteLine($"- {stat.Name}: {stat.Value}");
                }
                Console.Write("\nEnter the stat to invest in: ");
                string statName = Console.ReadLine();

                Console.Write("Points to allocate: ");
                if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                try
                {
                    AllocateStat(statName, points);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
  

    internal class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Ability(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
