namespace APBD_03;

public class Container
{
    public double MassOfCargo { get; set; }  
    public double Height { get; set; }      
    public double TareWeight { get; set; }  
    public double WeightOfCargo => MassOfCargo;  
    public double Depth { get; set; }       
    public string SerialNumber { get; private set; } 
    public double MaxPayload { get; set; } 
    
    private static int serialNumberCounter = 1;
    
    public Container(double massOfCargo, double height, double tareWeight, double depth, double maxPayload, string containerType)
    {
        MassOfCargo = massOfCargo;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;

        SerialNumber = GenerateSerialNumber(containerType);
    }
    
    private string GenerateSerialNumber(string containerType)
    {
        string serialNumber = $"KON-{containerType}-{serialNumberCounter}";
        serialNumberCounter++; 
        return serialNumber;
    }
    
    
}