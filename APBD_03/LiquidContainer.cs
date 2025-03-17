namespace APBD_03;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double maxPayload, string productType) : base(maxPayload, productType) { }

    public override string GetContainerType() => "L";  // "L" for Liquid

    public void SendHazardNotification(string message, string containerNumber)
    {
        Console.WriteLine($"[Hazard Notification] Container {containerNumber}: {message}");
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