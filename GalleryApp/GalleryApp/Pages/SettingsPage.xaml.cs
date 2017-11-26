using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GalleryApp.Models;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            BindingContext = Settings.Gallery3Url;
		}

        protected override void OnDisappearing()
        {
            Settings.Gallery3Url = Gallery3UrlEntryCell.Text;
            base.OnDisappearing();
        }

    }
}