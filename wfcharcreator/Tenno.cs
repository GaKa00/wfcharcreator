using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfcharcreator
{
    internal class Tenno
    {

        public string Name { get; set; }
        public List<Stat> MentalStats { get; set; }

        public int StatPoints = 5;

        //AI gave me the idea to use a string array to map die types
        private static readonly string[] DieTypeMap = { "d4", "d6", "d8", "d10", "d12" };
        private const int MaxInvestment = 4;


        public int Level { get; set; } = 1;

        public Warframe warframe { get; set; }
        public Tenno(string name, Warframe warframe)
        {
            Name = name;
            this.warframe = warframe;
            MentalStats = new List<Stat>
            {
                new Stat("Resolve", 0),
                new Stat("Focus", 0),
                new Stat("Speech", 0),
                new Stat("Fortitude", 0),
                new Stat("Reaction", 0)
            };
        }

        public void AllocateMentalStatsInteractive()
        {
            while (StatPoints > 0)
            {
                Console.WriteLine($"\nPoints remaining: {StatPoints}");
                Console.WriteLine("Mental stats:");
                foreach ( var stat in MentalStats)
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
                    AllocateMentalStat(statName, points);
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AllocateMentalStat(string statName, int points)
        {

            var stat = MentalStats.FirstOrDefault(s =>
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

        //AI generated method to get die type based on stat investment
        public string GetDieType(string statName)
        {
            Stat stat = MentalStats.FirstOrDefault(s => s.Name.Equals(statName, StringComparison.OrdinalIgnoreCase));
            if (stat != null)
            
            {
                //learned about Math.Clamp from AI!
                int index = Math.Clamp(stat.Value, 0, DieTypeMap.Length - 1);
                return DieTypeMap[index];
            }
            return "N/A";
        }

        public void AwardStatPoint(int points = 1)
        {
            if (points > 0)
            {
                StatPoints += points;
            }
        }

        public void LevelUp()
        {

            if (Level >= 12)
            {
                Console.WriteLine($"{Name} has reached the maximum level.");
                return;
            }
            Level++;
            warframe.Level = Level;
            warframe.Health = (int)(warframe.Health * Level);
            warframe.Shields = (int)(warframe.Shields * Level);
            Console.WriteLine($"\n*** {Name} Leveled Up! ***");
            Console.WriteLine($"Now Level {Level}.");
            AwardStatPoint(1);
        }


        //Ai helped it look nicer!
        public void DisplayStats()
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine($"--- TENNO: {Name} (Level {Level}) ---");
            Thread.Sleep(200);
            Console.WriteLine("======================================");
            Console.WriteLine("Mental Stats:");

            foreach (var stat in MentalStats)
            {
                string dieType = GetDieType(stat.Name);
                string status = stat.Value == MaxInvestment ? " (MAXED)" : "";
                Console.WriteLine($"- {stat.Name,-10}: {stat.Value,-2} points invested -> {dieType}{status}");
                Thread.Sleep(500);
            }
            Thread.Sleep(300);
            Console.WriteLine("======================================");
            Console.WriteLine($"Warframe: {warframe.Name}");

            Thread.Sleep(500);

            Console.WriteLine("Warframe Stats:");

            foreach (var stat in warframe.Stats)
            {
                Console.WriteLine($"- {stat.Name}: {stat.Value}");
                Thread.Sleep(500);
            }
      
            Console.WriteLine("======================================\n");

            Thread.Sleep(500);

            Console.WriteLine("======================================\n");

            Console.WriteLine("Warframe Abilities:");
            foreach (var ability in warframe.Abilities)
            {
                Console.WriteLine($"- {ability.Name}: {ability.Description}");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Current Weapons");
            foreach (var weapon in warframe.Weapons)
            {
                Console.WriteLine($"- {weapon.Type} - {weapon.Name} ({weapon.Damage} + {weapon.DamageType})");
                Thread.Sleep(500);
            }
        }
    }
    }
