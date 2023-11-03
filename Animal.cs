using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Animal : Entity
{
  
    public string AcceptebleCropTypes { get; set; }
    public string Species { get; set; }
    public Animal(int id, string name, string species, string acceptebleCropTypes) 
       : base(id, name)
    {
        Species = species;
        AcceptebleCropTypes = acceptebleCropTypes;  
    }

    public void GetDescription()
    {
        base.GetDescription();
        Console.WriteLine($"Species: {Species}\nAcceptebleCropType: {AcceptebleCropTypes}\n");

    }
    public void Feed(string cropToFeed)
    {
        /* Loop igenom croptype som finns och om djuret äter det. kalla takecrop*/
        if (AcceptebleCropTypes.Contains(cropToFeed))
        {
            Console.WriteLine($"{Name} of {Species} is feed with {cropToFeed}");
        }
        else
        {
            Console.WriteLine($"{Name} of {Species} does not eat {cropToFeed}");
        }
    }


}
