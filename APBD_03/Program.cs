using APBD_03;

public class Program
{
    public static void Main(string[] args)
    {
        
        var liquidContainer = new LiquidContainer(1000, "hazardous");
        liquidContainer.DisplayContainerInfo();
        liquidContainer.LoadContainer(400);  
        try
        {
            liquidContainer.LoadContainer(700); 
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        var gasContainer = new GasContainer(1500, "helium", 5);
        gasContainer.DisplayContainerInfo();
        gasContainer.LoadContainer(500);  
        gasContainer.EmptyCargo(); 
        
        var refrigeratedContainer = new RefrigeratedContainer(2000, "meat", 5);
        refrigeratedContainer.DisplayContainerInfo();
        refrigeratedContainer.Temperature = 3;  
        try
        {
            refrigeratedContainer.LoadContainer(1000);  
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        var refrigeratedContainer1 = new RefrigeratedContainer(2000, "meat", -15);
        refrigeratedContainer1.DisplayContainerInfo();
        refrigeratedContainer1.Temperature = 3; 
        Console.WriteLine($"Current temperature: {refrigeratedContainer1.Temperature}°C");
        try
        {
            refrigeratedContainer1.LoadContainer(1000);  
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
        
    }
}