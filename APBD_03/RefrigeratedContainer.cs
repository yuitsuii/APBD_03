namespace APBD_03
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        public double RequiredTemperature { get; set; }
        private static readonly Dictionary<string, (double MinTemperature, double MaxTemperature)> ProductTemperatureRequirements = new()
        {
            { "bananas", (12.3, 14.3) },
            { "chocolate", (17, 19) },
            { "fish", (1, 3) },
            { "meat", (-16, -14) },
            { "ice cream", (-19, -18) },
            { "frozen pizza", (-31, -29) },
            { "cheese", (6.2, 8.2) },
            { "sausages", (4, 6) },
            { "butter", (19.5, 21.5) },
            { "eggs", (18, 20) }
        };

        public RefrigeratedContainer(double maxPayload, string productType, double temperature = 0) : base(maxPayload, productType, temperature)
        {

            if (ProductTemperatureRequirements.ContainsKey(productType.ToLower()))
            {
                var tempRange = ProductTemperatureRequirements[productType.ToLower()];
                RequiredTemperature = (tempRange.MinTemperature + tempRange.MaxTemperature) / 2;
            }
            else
            {

                throw new ArgumentException($"No temperature requirement defined for product type: {productType}");
            }

            if (temperature < RequiredTemperature)
            {
                throw new Exception($"The initial temperature is too low. It cannot be set lower than the required temperature of {RequiredTemperature}°C for {productType}.");
            }
        }

        public override string GetContainerType()
        {
            return "C"; 
        }

        public override void LoadContainer(double cargoWeight)
        {

            if (Temperature < RequiredTemperature)
            {
                SendHazardNotification("Temperature is too low for this cargo.", SerialNumber);
                throw new Exception($"Cargo cannot be loaded. The current temperature of {Temperature}°C is too low. Required: {RequiredTemperature}°C.");
            }

            CurrentLoad += cargoWeight;
            Console.WriteLine($"Successfully loaded {cargoWeight} kg into refrigerated container. Current load: {CurrentLoad} kg.");
        }

        public new double Temperature
        {
            get => base.Temperature;
            set
            {
                if (value < RequiredTemperature)
                {
                    Console.WriteLine($"Cannot set temperature to {value}°C. Minimum required temperature is {RequiredTemperature}°C for {ProductType}.");
                }
                else
                {
                    base.Temperature = value;
                    Console.WriteLine($"Temperature set to {value}°C.");
                }
            }
        }

        public void SendHazardNotification(string message, string containerNumber)
        {
            Console.WriteLine($"[Hazard Notification] Container {containerNumber}: {message}");
        }
    }
}