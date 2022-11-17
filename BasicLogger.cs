namespace Downstream
{
    public class BasicLogger
    {

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
