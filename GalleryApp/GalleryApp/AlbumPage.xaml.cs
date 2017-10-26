using System;
using System.Collections.Generic;

using Xamarin.Forms;

using GalleryApp.Models;

namespace GalleryApp
{
    public partial class AlbumPage : ContentPage
    {
        ViewModels.AlbumViewModel albumViewModel;

        public AlbumPage()
        {
            InitializeComponent();
        }

        public AlbumPage(int GalleryItemId)
        {
            InitializeComponent();
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

    }
}
