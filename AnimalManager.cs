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
            Console.WriteLine("1. View Animals.");
            Console.WriteLine("2. Add Animals.");
            Console.WriteLine("3. Remove Animals.");
            Console.WriteLine("4. Feed Animals.");
            Console.WriteLine("5. Get Description");
            Console.WriteLine("6. Go back.");

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
                Console.WriteLine("Which animal do you want to look up? Write its name.");
                string lookUpCropName = Console.ReadLine();

                // Search for the crop by name
                Animal animalDisplay = AvaibleAnimals.FirstOrDefault(animal => animal.Name == lookUpCropName);

                if (animalDisplay != null)
                {
                    animalDisplay.GetDescription();
                }
                else
                {
                    Console.WriteLine("Couldn't find any animal matching that name.");
                }
            }
            else if (Input == "6")
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
                Console.WriteLine($"Animal Id: {animal.Id}, Name: {animal.Name}, Species: {animal.Species}, AcceplebleCropTypes: {animal.AcceptebleCropTypes}\n");
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
            Console.WriteLine("\nWhat ID?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What name?");
            string name = Console.ReadLine().ToLower();

            Console.WriteLine("What species?");
            string species = Console.ReadLine().ToLower(); 

            Console.WriteLine("Accepteble Crop type?");
            string acceptebleCropTypes = Console.ReadLine().ToLower();

            AvaibleAnimals.Add(new Animal(id, name, species, acceptebleCropTypes));
            AnimalCount++;
            Console.WriteLine("\nAnimal(s) was added!\n");
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
            if (AvaibleAnimals.Count > 0)
            {
                Console.WriteLine("\nWhat animal do you wanna remove? Write their ID.");

                foreach (var animal in AvaibleAnimals)
                {
                    Console.WriteLine($"ID: {animal.Id} Name: {animal.Name} Species: {animal.Species} AcceptebleCropTypes: {animal.AcceptebleCropTypes}\n");
                }
                
                int id = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < AvaibleAnimals.Count; i++)
                    {
                        AvaibleAnimals.RemoveAt(i);
                    }

                    Console.WriteLine("\nThe animal(s) was removed!\n");
                
            }
            else
            { 
                Console.WriteLine("\nThere are no animals to remove!\n");
            }
        }
        catch
        {
            Console.WriteLine("\nWrite the animals ID!\n");
        }
    }
    public void FeedAnimal(List<Crop> AviableCrops)
    {
        if (AvaibleAnimals.Count > 0)
        {
            Console.WriteLine("\nWhich animal do you wanna feed? Write their name. \n");
            foreach (var animal in AvaibleAnimals)
            {
                Console.WriteLine($"ID: {animal.Id} Name: {animal.Name} Species: {animal.Species} AcceptebleCropTypes: {animal.AcceptebleCropTypes}\n");
            }
                string feedAnimal = Console.ReadLine().ToLower();

            foreach (var animal in AvaibleAnimals)
            {
                if (feedAnimal == animal.Name)
                {
                    Console.WriteLine("What crops would you like to feed" + animal.Name + "?");
                    string feedCrop = Console.ReadLine().ToLower();
                    Console.WriteLine($"How many of {feedCrop} do you wanna feed {animal.Name} ?");
                    int quantityToFeed = int.Parse(Console.ReadLine());

                    /*
                    foreach (aviableCrops[0].Name == feedCrop)
                    */

                    Crop correspondingCrop = AviableCrops.Find(rightCropType => rightCropType.CropType == feedCrop);

                    if (correspondingCrop != null && animal.AcceptebleCropTypes.Contains(correspondingCrop.CropType))
                    {
                        Console.WriteLine("\nYay! The animal Liked the food!\n");
                        int quantityToRemove = quantityToFeed;

                        /*
                         correspondingCrop.TakeCrop(quantityToRemove);
                        */

                        for (int crop = 0; crop < AviableCrops.Count; crop++)
                        {
                            if (AviableCrops[crop] != null && AviableCrops[crop].Id == correspondingCrop.Id)
                            {
                                bool stillExists = AviableCrops[crop].TakeCrop(quantityToRemove);
                                if (!stillExists)
                                {
                                    AviableCrops.RemoveAt(crop);
                                }
                            }
                        }

                    }
                    else if (AviableCrops.Count <= 0)
                    {
                        Console.WriteLine("\nThere's no crop left of that sort!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nUgh! The animal doesn't eat that!\n");
                    }

                }
                else
                {
                    Console.WriteLine("\nUse numbers or letters when necessary!\n");
                }
            }
            
        }
        else
        {
            Console.WriteLine("\nNo animals registred!\n");
        }
    }
}
