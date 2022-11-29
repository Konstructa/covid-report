using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using System.Net;

namespace CovidReport
{
    public class GetServer 
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data 
    {
        [JsonProperty("server")]
        public string Server { get; set; }
    }

    public class SendService
    {
        public async Task<string> GetBestServer()
        {
            var url = "https://api.gofile.io/getServer";

            var requisicao = new HttpClient();

            var stringTask = await requisicao.GetAsync(url);

            var response = await stringTask.Content.ReadAsStringAsync();

            GetServer getBestServer = JsonConvert.DeserializeObject<GetServer>(response);

            return $"https://{getBestServer.Data.Server}.gofile.io/uploadFile";
        }

        public MultipartFormDataContent MakeContentRequest(IConfiguration _config, string path)
        {
            

            var fileName = Path.GetFileName(path);

            var file = FileService.GetFile(path);

            var folderId = _config["GoFile:FolderId"];

            var apiToken = _config["GoFile:ApiToken"];

            var values = new Dictionary<string, string>
            {
                {"token", apiToken },
                {"folderId", folderId }
            };

            var content = new FormUrlEncodedContent(values);

            var requestContent = new MultipartFormDataContent
            {
                { file, "file", fileName },
                content
            };

            return requestContent;

        }
        public async Task<int> SendFormData(IConfiguration _config, string path)
        {

            var requestContent = MakeContentRequest(_config, path);

            string server = await GetBestServer();

            var client = new HttpClient();

            var response = await client.PostAsync(server, requestContent);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            //using (WebClient client2 = new WebClient())
            //{
            //    client2.UploadFile(server, req);
            //}

            FileService.DeleteFile(path);

            Console.WriteLine(server);

            Console.WriteLine(response.StatusCode);

            Console.WriteLine(responseString);

            return 2;
        }
    }
}
