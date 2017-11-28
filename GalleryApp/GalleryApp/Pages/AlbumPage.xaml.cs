using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using GalleryApp.Models;
using GalleryApp.ViewModels;

using Microsoft.Azure.Mobile.Analytics;

namespace GalleryApp.Pages
{
    public partial class AlbumPage : ContentPage
    {
        AlbumViewModel albumViewModel = new AlbumViewModel();

        private int galleryItemId = 1;

        public AlbumPage()
        {
            InitializeComponent();
            BindingContext = albumViewModel;
        }

        async void HandleItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var tappedEntity = e.Item as Entity;

            await OpenNewPhotoPage(tappedEntity.Id);

            Analytics.TrackEvent("Album item tapped", new Dictionary<string, string> {
                { "Name", tappedEntity.Name },
                { "Title", tappedEntity.Title },
            });
        }

        async Task OpenNewPhotoPage(int PhotoId)
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

        private async void RefreshButton_Clicked(object sender, EventArgs e)
        {
            await albumViewModel.GetAlbumFromGallery3Async(galleryItemId);

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
