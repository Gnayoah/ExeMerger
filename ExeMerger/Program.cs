// ExeMerger by Gnayoah.com
// View on Github https://github.com/Gnayoah/ExeMerger
// A tool to merge exe, dll, and other program files or folders into a single executable
// GPL-3.0 License

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;

class Program
{
    static void Main()
    {
        string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string targetFolderPath = Path.Combine(localAppDataPath, "demo");
        string exemergerZipPath = Path.Combine(targetFolderPath, "demo.zip");



        Directory.CreateDirectory(targetFolderPath);



        if (!ExtractEmbeddedResource("ExeMerger.demo.zip", targetFolderPath))
        {
            Console.WriteLine("Failed to extract the ZIP file.");
            return;
        }




        string exemergerPath = Path.Combine(targetFolderPath, "demo.exe");
        if (File.Exists(exemergerPath))
        {
            RunAsAdmin(exemergerPath);
        }
        else
        {
            Console.WriteLine("file not found.");
        }




        DirectoryInfo directoryInfo = new DirectoryInfo(targetFolderPath);
        directoryInfo.Attributes |= FileAttributes.Hidden;


    }


    static bool ExtractEmbeddedResource(string resourceName, string extractionPath)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.WriteLine("Resource not found.");
                return false;
            }

            using (ZipArchive archive = new ZipArchive(resourceStream, ZipArchiveMode.Read))
            {
                archive.ExtractToDirectory(extractionPath, true);
            }
        }
        return true;
    }


    static bool CopyEmbeddedResourceToFile(string resourceName, string outputPath)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (resourceStream == null)
            {
                Console.WriteLine("Resource not found.");
                return false;
            }

            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                resourceStream.CopyTo(fileStream);
            }
        }
        return true;
    }


    static void RunAsAdmin(string filePath)
    {
        string command = $"-Command \"Start-Process '{filePath}' -Verb runAs\"";
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "powershell",
            Arguments = command,
            UseShellExecute = true,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        try
        {
            Process process = Process.Start(psi);
            process.WaitForExit();
            Console.WriteLine("executed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to execute" + ex.Message);
        }
    }
}
