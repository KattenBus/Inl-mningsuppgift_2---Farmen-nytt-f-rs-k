using System;

public class AnimalManager
{
    private List<Animal> AvaibleAnimals = new List<Animal>();
    private int AnimalCount = 0;
    public void AnimalMenu(List<Crop> crops)
    {
        while (true)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1.View Animals.");
            Console.WriteLine("2. Add Animals.");
            Console.WriteLine("3. Remove Animals.");
            Console.WriteLine("4.Feed Animals.");
            Console.WriteLine("5. Go back.");

            string Input = Console.ReadLine();

            if (Input == "1")
            {
                ViewAnimal();
            }
            else if (Input == "2")
            {
                AddAnimal();
            }
            else if (Input == "3")
            {
                RemoveAnimal();
            }
            else if (Input == "4")
            {
                FeedAnimal(crops);   
            }
            else if (Input == "5")
            {
                return;
            }
            else
            {

                Console.WriteLine("\nUse 1, 2, 3 or 4 to navigate!\n");

            }
        }
    }
    public void ViewAnimal()
    {
        if (AvaibleAnimals.Count > 0)
        {
            Console.WriteLine("\nList of Animals\n");
            for (int i = 0; i < AvaibleAnimals.Count; i++)
            {
                Animal animal = AvaibleAnimals[i];
                Console.WriteLine($"Animal Id: {animal.Id}, Name: {animal.Name}, Species:: {animal.Species}, AcceplebleCropTypes {animal.AcceptebleCropTypes}\n");
            }
        }
        else
        {
            Console.WriteLine("\nNo animals here!\n");
        }
    }
    public void AddAnimal()
    {
        try
        {
            Console.WriteLine("What ID?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What name?");
            string name = Console.ReadLine();

            Console.WriteLine("What species");
            string species = Console.ReadLine();

            Console.WriteLine("Accepteble Crop type??");
            string acceptebleCropTypes = Console.ReadLine();

            AvaibleAnimals.Add(new Animal(id, name, species, acceptebleCropTypes));
            AnimalCount++;
            Console.WriteLine("Animal(s) was added!");
        }
        catch
        {
            Console.WriteLine("\nYou did something wrong!\n");
        }
    }
    public void RemoveAnimal()
    {
        try
        {
            Console.WriteLine("What ID?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many?");
            int quantityToRemove = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < AvaibleAnimals.Count; i++)
            {
                AvaibleAnimals.RemoveAt(i);
            }

            Console.WriteLine("The animal(s) was removed!");
        }
        catch
        {
            Console.WriteLine("\nYou did something wrong!\n");
        }
    }
    public void FeedAnimal(List<Crop> aviableCrops)
    {
        if (AvaibleAnimals.Count > 0)
        {
            Console.WriteLine("Which animal do you wanna feed?\n");
            foreach (Animal animal in AvaibleAnimals)
            {
                Console.WriteLine($"Animal: {animal.Name} Accepteble food: {animal.AcceptebleCropTypes}\n");
                string feedAnimal = Console.ReadLine();

                if (feedAnimal == animal.Name)
                {
                    Console.WriteLine("What crops would you like to feed" + animal.Name + "?");
                    string feedCrop = Console.ReadLine();
                    Console.WriteLine($"How many of {feedCrop} do you wanna feed {animal.Name} ?");
                    int quantityToFeed = int.Parse(Console.ReadLine());

                    /*
                    foreach (aviableCrops[0].Name == feedCrop)
                    */

                    Crop correspondingCrop = aviableCrops.Find(rightCropType => rightCropType.CropType == feedCrop);

                    if(correspondingCrop != null && animal.AcceptebleCropTypes.Contains(correspondingCrop.CropType))
                    {
                        Console.WriteLine("Yay! The animal Liked the food!\n");
                        int quantityToRemove = quantityToFeed;
                        bool succes = correspondingCrop.TakeCrop(quantityToRemove);
                    }
                    else 
                    {
                         Console.WriteLine("Ugh! The animal doesn't eat that!\n");
                    }

                }
                else
                {
                    Console.WriteLine("Du gjorde fel\n");
                }
            }
        }
        else 
        {
            Console.WriteLine("No animals regiterd!\n");
        }
    }
}
