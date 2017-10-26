using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GalleryApp
{
    public partial class AlbumPage : ContentPage
    {
        ViewModels.AlbumViewModel albumViewModel = new ViewModels.AlbumViewModel();

        public AlbumPage()
        {
            InitializeComponent();
            AlbumStackLayout.BindingContext = albumViewModel;
        }
    }
}
