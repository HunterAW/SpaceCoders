using Newtonsoft.Json;
using System.Threading.Tasks;
using RestSharp;

namespace SpaceCoders.Models
{
    public class NasaImage
    {
        private const string Address = "https://api.nasa.gov/planetary/apod?api_key=jJSnOuXvEk2vL2QFgxcuqVgWSgmtopRCJ48Av4JC";

        public string Title { get; set; }
        public string Url { get; set; }
        public string Copyright { get; set; }
        [JsonProperty("media_type")]
        public string MediaType { get; set; }
        public string Explanation { get; set; }

        public static Task<NasaImage> RequestApod()
        {
            var client = new RestClient(Address);
            var request = new RestRequest(Method.GET);
            var taskCompletionSource = new TaskCompletionSource<NasaImage>();
            var asyncHandle = client.ExecuteAsync<NasaImage>(request, response =>
            {
                taskCompletionSource.SetResult(response.Data);
            });

            return taskCompletionSource.Task;
        }
    }
}
