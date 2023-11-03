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
            Console.WriteLine("4. Get Description");
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
                Console.WriteLine("\nWhich crop do you want to look up? Write its name.");
                string lookUpCropName = Console.ReadLine();

                // Search for the crop by name
                Crop cropToDisplay = AvailableCrops.FirstOrDefault(crop => crop.Name == lookUpCropName);

                if (cropToDisplay != null)
                {
                    cropToDisplay.GetDescription();
                }
                else
                {
                    Console.WriteLine("\nCouldn't find any crop matching that name.\n");
                }

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
			Console.WriteLine("\nWhat ID?");
			int id = Convert.ToInt32(Console.ReadLine());

			Crop existingCrop = null;

			foreach (Crop crop in AvailableCrops)
			{
				if (crop.Id == id)
				{ 
					existingCrop = crop;
					break;
				}
			}

			if (existingCrop != null)
			{

				Console.WriteLine($"\nThe crop:{id} already exists!");
				Console.WriteLine("Do you wanna add any quantity to it?");
				string answer = Console.ReadLine().ToLower();

				if (answer == "yes")
				{
					Console.WriteLine("\nHow many do you wanna add?");
					int quantityToAdd = int.Parse(Console.ReadLine());

					existingCrop.AddCrop(quantityToAdd);
					Console.WriteLine("\nAdded the crops\n");


				}
				else
				{
					Console.WriteLine("\nCrop was not added\n");
				}



			}

            else if (existingCrop == null)
			{
                Console.WriteLine("What name?");
                string name = Console.ReadLine().ToLower();

                Console.WriteLine("What CropType");
				string cropType = Console.ReadLine().ToLower();

				Console.WriteLine("How many?");
				int quantity = Convert.ToInt32(Console.ReadLine());

				AvailableCrops.Add(new Crop(id, name, cropType, quantity));
				Console.WriteLine("\nCrop was added!\n");
			}
        }
		catch
		{ 
			Console.WriteLine("\nWrite the ID number!\n");
		}
	}
	private void RemoveCrops()
	{
		try
		{
			if (AvailableCrops.Count > 0)
			{
				Console.WriteLine("\nWhat Crop do you wanna remove? Write their ID.\n");

				foreach (var crop in AvailableCrops)
				{
					Console.WriteLine($"ID: {crop.Id} Name: {crop.Name} CropType: {crop.CropType} Quantity: {crop.Quantity}\n");
				}
				Console.WriteLine("\nWhat ID?");
				int id = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine("How many?");
				int quantityToRemove = Convert.ToInt32(Console.ReadLine());

				for (int crop = 0; crop < AvailableCrops.Count; crop++)
				{
					if (AvailableCrops[crop] != null)
					{
						if (AvailableCrops[crop].Id == id)
						{
							bool stillExists = AvailableCrops[crop].TakeCrop(quantityToRemove);
							if (!stillExists)
							{
								AvailableCrops.RemoveAt(crop);
							}
						}
					}
				}
			}
            else
            {
                Console.WriteLine("\nNo crop was found.\n");
            }
        }
		catch
		{
			Console.WriteLine("\nYou did something wrong!\n");
		}
    }

	public List<Crop> GetCrops()
	{ 
		return AvailableCrops;
		/* ska skickas med i farm framför allt så den blir tillänglig i flera klasser*/
	}
}
