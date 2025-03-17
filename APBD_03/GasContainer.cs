namespace APBD_03;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure {get ; set;}
    
    public GasContainer(double maxPayload, string productType, double pressure) : base(maxPayload, productType)
    {
        Pressure = pressure;
    }

    public override string GetContainerType()
    {
        return "G";
    }

    public override void EmptyCargo()
    {
        
        CurrentLoad = CurrentLoad * 0.05;
        Console.WriteLine($"Gas container emptied. 5% of the cargo remains: {CurrentLoad} kg.");
    }


    public void SendHazardNotification(string message, string containerNumber)
    {
        Console.WriteLine($"[Hazard Notification] Container{containerNumber}:{message}");
    }
    
    public override void LoadContainer(double cargoWeight)
    {
        double maxAllowedWeight = GetMaxAllowedWeight();

        if (cargoWeight + CurrentLoad > maxAllowedWeight)
        {
            SendHazardNotification("Overload attempt detected!", SerialNumber);
            throw new OverfillException($"Cannot load {cargoWeight} kg. It exceeds the allowed weight for hazardous cargo.");
        }

        CurrentLoad += cargoWeight;
        Console.WriteLine($"Successfully loaded {cargoWeight} kg into liquid container. Current load: {CurrentLoad} kg.");
    }
    
    
}