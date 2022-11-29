using System.Collections;
using CovidReport.DTO;

namespace CovidReport.Services
{
    public static class FileService
    {
        public static string CreateFile(CovidAll covidAll)
        {
            var path = @"C:\temp";

            Directory.CreateDirectory(path + @"\reports");

            var fileName = $"report{DateTime.Now.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)}.csv";

            var targetPath = path + @"\reports\" + fileName;

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

        public static ByteArrayContent GetFile(string path)
        {
            //FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            byte[] file = File.ReadAllBytes(path);

            var imageContent = new ByteArrayContent(file);

            return imageContent;
        }
    }
}
