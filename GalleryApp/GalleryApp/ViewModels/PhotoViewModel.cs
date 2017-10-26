using System;
using System.ComponentModel;
using System.Json;
using System.Threading.Tasks;
using GalleryApp.Models;

namespace GalleryApp.ViewModels
{
    public class PhotoViewModel : INotifyPropertyChanged
    {
        private Gallery3 gallery3Source = new Gallery3();

        private Photo photo = new Photo();
        public Photo Photo {
            get {
                return photo;
            }
        }

        public PhotoViewModel(int PhotoId)
        {
            GetPhotoFromGallery3Async(PhotoId);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Photo"));
            }
        }

        private async void GetPhotoFromGallery3Async(int PhotoId)
        {
            var photoJson = await gallery3Source.GetJsonFromGallery3Async(PhotoId);
            photo = ConvertJsonToPhotoAsync(photoJson);
            NotifyPropertyChanged();
        }

        private Photo ConvertJsonToPhotoAsync(JsonValue jsonDoc)
        {
            var photoJsonDoc = jsonDoc["entity"];

            var newPhoto = new Photo(photoJsonDoc["id"], photoJsonDoc["name"], photoJsonDoc["title"], photoJsonDoc["thumb_url_public"], photoJsonDoc["web_url"], photoJsonDoc["mime_type"], photoJsonDoc["file_url"])
            {
                Type = "photo"
            };

            return newPhoto;
        }
    }
}
