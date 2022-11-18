namespace Downstream
{
    public class BasicLogger
    {
        // Displays the Single Responsibility Principle of SOLID as this is now handled in it's own separate class instead of within the Tickets Controller. This ensures that the purpose of this class is clear and isn't convoluting other classes.
        // This was also developed in a way to follow the Open/Closed principle. I wanted to set the BasicLogger class up in a way that in the future, I can easily extend this for other basic logging as I work on the program.
        public static void WriteToFile(string fileName, string fileContent)
        {
            fileName += ".txt";
            string FolderPath = @"C:\Downstream Logs\";
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (!File.Exists(FolderPath + fileName))
                File.Create(FolderPath + fileName).Close();

            StreamWriter streamWriter = new StreamWriter(FolderPath + fileName, true);
            streamWriter.WriteLine(fileContent);
            streamWriter.Close();


        }
      
    }
}
