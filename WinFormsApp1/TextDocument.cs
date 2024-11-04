namespace WpfApp4;

using System.IO;

public class TextDocument
{
    private static string[] lines;

    public TextDocument()
    {
        lines = [];
    }

    public TextDocument(String fileName)
        : this()
    {
        lines = new string[1024];
        try
        {
            Initialize(fileName);
            Console.WriteLine("File successfully opened.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Continuing with empty text file.");
        }
    }

    /// <summary>
    /// Loads a file into the TextDocument. Throws an error if file is unable to be loaded.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private void Initialize(String fileName)
    {
        // Gets the path to this directory
        string? winDir = Environment.GetEnvironmentVariable("windir");

        if (winDir == null)
        {
            throw new IOException("Could not find win directory");
        }

        // Check if file exists and is not a directory
        if (!File.Exists($"{winDir}\\{fileName}"))
        {
            throw new IOException($"Could not find file {fileName}");
        }

        // Read the lines in the file
        using StreamReader sr = new StreamReader($"{winDir}\\{fileName}");

        string? line;
        int i = 0;

        while ((line = sr.ReadLine()) != null)
        {
            lines[i++] = line;
        }
    }
}
