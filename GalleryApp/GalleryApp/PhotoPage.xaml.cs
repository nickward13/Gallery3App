using System;
using System.Collections.Generic;

using Xamarin.Forms;
using GalleryApp.ViewModels;

namespace GalleryApp
{
    public partial class PhotoPage : ContentPage
    {
        private PhotoViewModel photoViewModel;

        public PhotoPage()
        {
            InitializeComponent();
        }

        public PhotoPage(int PhotoId)
        {
            InitializeComponent();
            photoViewModel = new PhotoViewModel(PhotoId);
            BindingContext = photoViewModel;
        }
    }
}
