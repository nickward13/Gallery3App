using System;
using System.Collections.Generic;

using Xamarin.Forms;

using GalleryApp.Models;

namespace GalleryApp
{
    public partial class AlbumPage : ContentPage
    {
        ViewModels.AlbumViewModel albumViewModel;

        public AlbumPage(int GalleryItemId)
        {
            InitializeComponent();
            albumViewModel = new ViewModels.AlbumViewModel(GalleryItemId);
            AlbumStackLayout.BindingContext = albumViewModel;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Entity tappedEntity = (Entity)e.Item;
            if(tappedEntity.Type == "album")
            {
                OpenNewAlbumPage(tappedEntity.Id);
            } else if (tappedEntity.Type == "photo")
            {
                DisplayAlert("You've tapped a photo", "carry on", "Ok");
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

    }
}
