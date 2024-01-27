using ProjetoAula05.Controllers;

public class Program
{
    static async Task Main()
    {
        var clientController = new ClientController();
        await clientController.RegisterClientAsync();

        // Add this line to keep the console window open
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}