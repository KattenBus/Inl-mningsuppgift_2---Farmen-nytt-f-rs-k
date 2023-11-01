using System;
using System.Runtime.CompilerServices;

public class CropManager
{
    private List <Crop> AvailableCrops = new List <Crop> ();
	private int CropCount = 0;

	public CropManager() 
	{ 
	}	
    public void CropMenu()
	{

		while (true)
		{
			Console.WriteLine("Vad vill du göra?");
			Console.WriteLine("1. View Crops.");
			Console.WriteLine("2. Add Crops");
			Console.WriteLine("3. RemoveCrops");
			Console.WriteLine("4. Get Crops");
            Console.WriteLine("5. Go back.");

            string Input = Console.ReadLine();

			if (Input == "1")
			{
				ViewCrops();
			}
			else if (Input == "2")
			{
				AddCrops();
			}
			else if (Input == "3")
			{
				RemoveCrops();
			}
			else if (Input == "4")
			{

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
    private void ViewCrops()
    {
        if (AvailableCrops.Count > 0)
        {
            Console.WriteLine("\nList of available crops:\n");
            for (int i = 0; i < AvailableCrops.Count; i++)
            {
                Crop crop = AvailableCrops[i];
                Console.WriteLine($"Crop Id: {crop.Id}, Name: {crop.Name}, Crop Type: {crop.CropType}, Quantity: {crop.Quantity}\n");
            }
        }
        else
        {
            Console.WriteLine("\nNo crops available.\n");
        }

    }
	private void AddCrops()
	{
		try
		{
			Console.WriteLine("What ID?");
			int id = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("What name?");
			string name = Console.ReadLine();

			Console.WriteLine("What CropType");
			string cropType = Console.ReadLine();

			Console.WriteLine("How many?");
            int quantity = Convert.ToInt32(Console.ReadLine());

			AvailableCrops.Add(new Crop(id, name, cropType, quantity));
			CropCount++;
			Console.WriteLine("Crop was added!");
        }
		catch
		{ 
			Console.WriteLine("\nYou did something wrong!\n");
		}
	}
	private void RemoveCrops()
	{
        try
        {
            Console.WriteLine("What ID?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many?");
            int quantityToRemove = Convert.ToInt32(Console.ReadLine());

			/*foreach(Crop crop in AvailableCrops)
			{
				if (crop != null)
				{
					if (crop.Id == id)
					{
                        Console.WriteLine();
						crop.TakeCrop(quantityToRemove);
                    }
				}
			}*/
			for(int i = 0; i < AvailableCrops.Count; i++)
			{
				if (AvailableCrops[i] != null)
				{
					if (AvailableCrops[i].Id == id)
					{
						bool stillExists = AvailableCrops[i].TakeCrop(quantityToRemove);
						if (!stillExists) 
						{
							AvailableCrops.RemoveAt(i);
						}
					}
				}
			}

            Console.WriteLine("The Crops was removed!");
        }
        catch
        {
            Console.WriteLine("\nYou did something wrong!\n");
        }
    }

	public List<Crop> GetCrops()
	{
		return AvailableCrops;
	}
}
