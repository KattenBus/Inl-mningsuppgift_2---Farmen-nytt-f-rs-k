using System;

public class Crop : Entity
{
	public string CropType { get; set; }
	public int Quantity { get; set; }

	public Crop(int id, string name, string cropType, int quantity) 
		: base(id, name)
	{
		CropType = cropType;
		Quantity = quantity;
	}

	public virtual void GetDescription()
	{ 
	
	}
	public void AddCrop()
	{ 
	
	}

	public bool TakeCrop(int quantityToRemove) 
	{
		
        Quantity -= quantityToRemove;

        if (Quantity > 0) 
		{
			Console.WriteLine($"The crop(s) were succesfuly removed");

			return true;
		}
		else
		{
	
            Console.WriteLine($"The Crops have been deleted from the list");

            return false;

		}
	}


}
