using System;
using System.Security.Cryptography.X509Certificates;

public class Farm
{
    CropManager cropManager = new CropManager();
    AnimalManager animalManager = new AnimalManager();
    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1.Gå till CropManager!");
            Console.WriteLine("2.Gå Till AnimalManager!");

            string Input = Console.ReadLine();

            if (Input == "1")
            {
                cropManager.CropMenu();
            }
            else if (Input == "2")
            {
                animalManager.AnimalMenu(cropManager.GetCrops());
            }
            else
            {
                Console.WriteLine("\nUse 1 or 2 to navigate!\n");
            }

            
        }

    }
}
