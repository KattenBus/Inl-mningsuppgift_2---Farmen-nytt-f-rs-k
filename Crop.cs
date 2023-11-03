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

    public override void GetDescription()
	{	
		base.GetDescription();
		Console.WriteLine($"CropType: {CropType}\nQuantity: {Quantity}\n");
    }
	public void AddCrop(int quantityToAdd)
	{ 
		Quantity += quantityToAdd;
	}

	public bool TakeCrop(int quantityToRemove) 
	{
		
        Quantity -= quantityToRemove;

        if (Quantity > 0) 
		{
			Console.WriteLine($"\nThe crop(s) were succesfuly removed\n");

			return true;
		}
		else
		{
	
            Console.WriteLine($"\nThe Crops have been deleted from the list\n");



            return false;

		}
	}


}
