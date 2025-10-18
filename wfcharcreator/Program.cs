namespace wfcharcreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
        


            Console.WriteLine("Welcome to the unofficial warframe ttrpg  character creator.");

            Console.Write("Enter your Tenno's name: ");
            string tennoName = Console.ReadLine();

            Console.WriteLine($"You've awoken at last, {tennoName}, now, what Warframe will you decide upon?");
            Warframe selectedWarframe = WarframeDB.SelectWarframe();

            Tenno playerTenno = new Tenno(tennoName, selectedWarframe);
            Console.WriteLine($"\nExcellent choice, {playerTenno.Name}! You have selected the {playerTenno.warframe.Name} Warframe.");

            Console.WriteLine("\nAllocate your Mental Stats (5 points total):");
            playerTenno.AllocateMentalStatsInteractive();

            Console.WriteLine("\n Now decide the power upon your Warframe. (40 points total)");

            playerTenno.warframe.AllocateStatsInteractive();

            Console.WriteLine("Excellent Job Tenno, you will surely become a fearsome prescence on the battlefield.");

            Thread.Sleep(2000);

            Console.WriteLine("You will now be assigned your first weapons to exploit in the war for the galaxy.");
                
            playerTenno.warframe.AssignStartingWeapons();

            Thread.Sleep(2000);

            Console.WriteLine(" Prepare yourself Tenno. Your war has just begun.");

            Thread.Sleep(1000);

            playerTenno.DisplayStats();

         











        }


    }
}
