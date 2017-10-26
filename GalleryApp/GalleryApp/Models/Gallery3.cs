using System;
using System.Json;
using System.Net;
using System.Threading.Tasks;

namespace GalleryApp.Models
{
    public class Gallery3
    {
        private string gallery3Url = "http://hectagongallerydocker.azurewebsites.net";

        public Gallery3()
        {
        }

        public async Task<JsonValue> GetJsonFromGallery3Async(string EntityUrl)
        {
            var request = NewGallery3WebRequest(EntityUrl);

            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var jsonDoc = JsonValue.Load(stream);
                    return jsonDoc;
                }
            }
        }

        public async Task<JsonValue> GetJsonFromGallery3Async(int EntityId)
        {
            return await GetJsonFromGallery3Async(ConvertEntityIdToRequestURL(EntityId));
        }

        private HttpWebRequest NewGallery3WebRequest(string EntityUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(EntityUrl));
            request.ContentType = "application/json";
            request.Method = "GET";
            return request;
        }

        private string ConvertEntityIdToRequestURL(int EntityId)
        {
            return String.Concat(gallery3Url, String.Concat("/rest/item/", EntityId));
        }
    }
}
