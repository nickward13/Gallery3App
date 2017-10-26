using System;
using System.Collections.Generic;

using Xamarin.Forms;

using GalleryApp.Models;

namespace GalleryApp
{
    public partial class AlbumPage : ContentPage
    {
        ViewModels.AlbumViewModel albumViewModel;
        private int galleryItemId;

        public AlbumPage()
        {
            InitializeComponent();
        }

        public AlbumPage(int GalleryItemId)
        {
            InitializeComponent();
            galleryItemId = GalleryItemId;
            albumViewModel = new ViewModels.AlbumViewModel(GalleryItemId);
            BindingContext = albumViewModel;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Entity tappedEntity = (Entity)e.Item;
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
            OpenSettingsPage();
        }

        async void OpenSettingsPage()
        {
            var settingsPage = new SettingsPage();
            await Navigation.PushAsync(settingsPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            albumViewModel.GetAlbumFromGallery3Async(galleryItemId);
        }
    }
}
