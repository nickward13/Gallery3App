using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalleryApp.Models;

namespace GalleryApp.ViewModels
{
    public class GalleryViewModel
    {
        private static string galleryUrl = "http://riogallerydocker.azurewebsites.net/rest";
        public Album Album;

        public GalleryViewModel()
        {
            GetAlbumFromGallery3Async();
        }

        private async Task GetAlbumFromGallery3Async()
        {
            var galleryJson = await GetJsonFromGallery3Async(String.Concat(galleryUrl, "/item/1"));
            this.Album = (Album) await ConvertJsonToAlbumAsync(galleryJson);
        }

        private async Task<JsonValue> GetJsonFromGallery3Async(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var jsonDoc = JsonObject.Load(stream);
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                    return jsonDoc;
                }
            }
        }

        private Entity ConvertJsonToEntity(JsonValue jsonDoc)
        {
            var entityJsonDoc = jsonDoc["entity"];
            return InitializeEntity(entityJsonDoc);
        }

        private async Task<Album> ConvertJsonToAlbumAsync(JsonValue jsonDoc)
        {
            var albumJsonDoc = jsonDoc["entity"];
            var newAlbum = new Album(albumJsonDoc["id"], albumJsonDoc["name"], albumJsonDoc["title"], albumJsonDoc["thumb_url_public"], albumJsonDoc["web_url"])
            {
                Type = albumJsonDoc["type"],
                Entities = new ObservableCollection<Entity>()
            };
            foreach (JsonValue galleryMember in jsonDoc["members"])
            {
                newAlbum.Entities.Add(await GetEntityFromGallery3Async(galleryMember));
            }

            return newAlbum;
        }

        private static Entity InitializeEntity(JsonValue entityJsonDoc)
        {
            var newEntity = new Entity();
            newEntity.Id = entityJsonDoc["id"];
            newEntity.Name = entityJsonDoc["name"];
            newEntity.Title = entityJsonDoc["title"];
            newEntity.ThumbUrlPublic = entityJsonDoc["thumb_url_public"];
            newEntity.WebUrl = entityJsonDoc["web_url"];
            newEntity.Type = entityJsonDoc["type"];
            return newEntity;
        }

        private async Task<Entity> GetEntityFromGallery3Async(string url)
        {
            var galleryJson = await GetJsonFromGallery3Async(url);
            return ConvertJsonToEntity(galleryJson);
        }

        private Photo ConvertJsonToPhoto(JsonValue photoJsonDoc)
        {
            var p = new Photo(photoJsonDoc["id"], photoJsonDoc["name"], photoJsonDoc["title"], photoJsonDoc["thumb_url_public"],
                photoJsonDoc["web_url"], photoJsonDoc["mime_type"], photoJsonDoc["file_url_public"]);
            return p;
        }
    }
}
