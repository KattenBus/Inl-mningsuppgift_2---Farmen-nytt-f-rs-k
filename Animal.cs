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
    
    }
    public void Feed()
    { 
    
    }


}
