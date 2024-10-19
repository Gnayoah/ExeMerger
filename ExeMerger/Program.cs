// ExeMerger by Gnayoah.com
// View on Github https://github.com/Gnayoah/ExeMerger
// A tool to merge exe, dll, and other program files or folders into a single executable
// GPL-3.0 License

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Reflection;

namespace UnzipAndRunInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string tempPath = Path.GetTempPath();
                string zipFileName = "installer.zip";
                string exeFileName = "installer.exe";
                string extractPath = Path.Combine(tempPath, "InstallerFiles");

                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true);
                }

                Directory.CreateDirectory(extractPath);
                string zipFilePath = Path.Combine(tempPath, zipFileName);

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Installer.installer.zip"))
                {
                    if (stream == null)
                    {
                        Console.WriteLine("installer.zip not found.");
                        return;
                    }

                    using (FileStream fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                string exeFilePath = Path.Combine(extractPath, exeFileName);

                if (File.Exists(exeFilePath))
                {
                    Process.Start(exeFilePath);
                }
                else
                {
                    Console.WriteLine("installer.exe not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
