using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GalleryApp
{
	public partial class MainPage : ContentPage
	{
        ViewModels.GalleryViewModel gallery = new ViewModels.GalleryViewModel();

		public MainPage()
		{
			InitializeComponent();
		}
	}
}
