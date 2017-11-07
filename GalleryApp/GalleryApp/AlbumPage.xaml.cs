using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using GalleryApp.Models;
using GalleryApp.ViewModels;

using Microsoft.Azure.Mobile.Analytics;

namespace GalleryApp
{
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel albumViewModel;

        private int galleryItemId;

        public AlbumPage()
        {
            InitializeComponent();
        }

        public AlbumPage(int GalleryItemId)
        {
            InitializeComponent();
            galleryItemId = GalleryItemId;
            albumViewModel = new AlbumViewModel(GalleryItemId);
            BindingContext = albumViewModel;
        }

        void HandleItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var tappedEntity = e.Item as Entity;

            if(tappedEntity.Type == "album")
            {
                OpenNewAlbumPage(tappedEntity.Id);
            } else if (tappedEntity.Type == "photo")
            {
                OpenNewPhotoPage(tappedEntity.Id);
            } else
            {
                DisplayAlert("You've tapped nothing", "carry on", "Ok");
            }

            Analytics.TrackEvent("Album item tapped", new Dictionary<string, string> {
                { "Name", tappedEntity.Name },
                { "Title", tappedEntity.Title },
            });
        }

        async void OpenNewAlbumPage(int AlbumId)
        {
            var newAlbumPage = new AlbumPage(AlbumId);
            await Navigation.PushAsync(newAlbumPage);
        }

        async void OpenNewPhotoPage(int PhotoId)
        {
            var newPhotoPage = new PhotoPage(PhotoId);
            await Navigation.PushAsync(newPhotoPage);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            OpenSettingsPage().ConfigureAwait(false);

            Analytics.TrackEvent("AlbumPage - Button_Clicked", null);
        }

        // make sure you use tasks, 
        // leaving as void can cause untracked memory leaks and exceptions
        async Task OpenSettingsPage()
        {
            var settingsPage = new SettingsPage();
            await Navigation.PushAsync(settingsPage);
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            albumViewModel.GetAlbumFromGallery3Async(galleryItemId)
                          .ConfigureAwait(false);

            Analytics.TrackEvent("AlbumPage - RefreshButton_Clicked", null);
        }

        private void AboutButton_Clicked(object sender, EventArgs e)
        {
            OpenAboutPage().ConfigureAwait(false);

            Analytics.TrackEvent("AlbumPage - AboutButton_Clicked", null);
        }

        async Task OpenAboutPage()
        {
            var aboutPage = new AboutPage();
            await Navigation.PushAsync(aboutPage);
        }
    }
}
