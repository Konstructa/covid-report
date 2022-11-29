namespace CovidReport
{
    public class FileService
    {
        public static string CreateFile(CovidAll covidAll)
        {
            var path = @"C:\temp";

            Directory.CreateDirectory(path + @"\reports");

            var fileName = $"report-{DateTime.Now.Date}.csv";

            var targetPath = Path.GetDirectoryName(path) + @"\reports\" + fileName;

            using (StreamWriter streamWriter = File.AppendText(targetPath))
            {
                streamWriter.WriteLine(covidAll.ToString());
            }

            return targetPath;
        }

        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
