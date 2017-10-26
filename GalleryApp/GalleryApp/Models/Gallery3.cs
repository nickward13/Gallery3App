using System;
using System.Json;
using System.Net;
using System.Threading.Tasks;

namespace GalleryApp.Models
{
    public class Gallery3
    {
        public Gallery3()
        {
        }

        public async Task<JsonValue> GetJsonFromGallery3Async(string EntityUrl)
        {
            var request = NewGallery3WebRequest(EntityUrl);

            try
            {
                var response = await request.GetResponseAsync();
                var stream = response.GetResponseStream();
                return JsonValue.Load(stream);
            } catch (WebException)
            {
                return null;
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
            return String.Concat(Settings.Gallery3Url, String.Concat("/rest/item/", EntityId));
        }
    }
}
