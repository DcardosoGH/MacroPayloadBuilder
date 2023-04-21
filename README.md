# MacroPayloadBuilder
This C# program generates a Macro template to be used for a reverse-shell running on powershell.

It takes 2 input parameters, LHOST and LPORT.
You will then be able to choose from 3 Payload Templates.

### Limitations and Considerations:
- **This is for educational/ethical purposes only, I've developped this project to enhance my personal skills.**
- The reverse-shell payloads all use powershell.
- No AV evasion techniques, may add later.
- Only tested on Windows.

## Download:
Check: https://github.com/DcardosoGH/MacroPayloadBuilder/releases


### Usage:
- Enter your LHOST and LPORT
- Choose your desired payload:
   - Option 1 requires a server hosting "Powercat.ps1" and will use `IEX` to download and execute in memory.
   - Opton 2 is a standard powershell reverse-shell using ``New-Object System.Net.Sockets.TCPClient``
   - Option 3 encodes the payload with base64 encoding.
- Copy the Macro generated to your Document.

### Example:
![image](https://user-images.githubusercontent.com/26344222/233415438-1f8118c2-c2ec-4923-a292-e826c2bfca1a.png)

