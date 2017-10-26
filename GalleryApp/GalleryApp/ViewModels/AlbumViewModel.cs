using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GalleryApp.Models;

namespace GalleryApp.ViewModels
{
    public class AlbumViewModel : INotifyPropertyChanged
    {
        private Gallery3 gallery3Source = new Gallery3();

        private Album album = new Album();
        public Album Album {
            get {
                return album;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AlbumViewModel(int AlbumId)
        {
            GetAlbumFromGallery3Async(AlbumId);
        }

        private void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Album"));
            }
        }

        private async void GetAlbumFromGallery3Async(int AlbumId)
        {
            var albumJson = await gallery3Source.GetJsonFromGallery3Async(AlbumId);
            this.album = (Album) await ConvertJsonToAlbumAsync(albumJson);
            NotifyPropertyChanged();
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

        private async Task<Entity> GetEntityFromGallery3Async(string EntityUrl)
        {
            var galleryJson = await gallery3Source.GetJsonFromGallery3Async(EntityUrl);
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
