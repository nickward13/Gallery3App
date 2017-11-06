using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryApp.Models
{
    static class Settings
    {
        public static string Gallery3Url
        {
            get
            {
                return GetGallery3UrlFromProperties();
            }
            set
            {
                SaveGallery3UrlToProperties(value);
            }
        }

        public static string GetGallery3UrlFromProperties()
        {
            object gallery3UrlObject;

            if (App.Current.Properties.TryGetValue("Gallery3Url", out gallery3UrlObject))
            {
                return gallery3UrlObject as string;
            }
            else
            {
                return SaveDefaultGallery3UrlToProperties();
            }
        }

        private static void SaveGallery3UrlToProperties(string newGallery3Url)
        {
            SetGallery3UrlProperty(newGallery3Url);
        }

        private static string SaveDefaultGallery3UrlToProperties()
        {
            string defaultGallery3Url = "http://gallery3hectgallerydocker.azurewebsites.net";
            SetGallery3UrlProperty(defaultGallery3Url);
            return defaultGallery3Url;
        }

        private static void SetGallery3UrlProperty(string defaultGallery3Url)
        {
            App.Current.Properties["Gallery3Url"] = defaultGallery3Url;
            PersistAppProperties();
        }

        private static async void PersistAppProperties()
        {
            await App.Current.SavePropertiesAsync();
        }
    }
}
