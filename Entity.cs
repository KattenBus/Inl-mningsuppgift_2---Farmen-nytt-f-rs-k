using System;

public class Entity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Entity(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public virtual void GetDescription() 
	{
		Console.WriteLine($"\nID: {Id}\nName: {Name}");

	}
}
