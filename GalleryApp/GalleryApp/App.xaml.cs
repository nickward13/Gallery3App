using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

using GalleryApp.Pages;

namespace GalleryApp
{
	public partial class App : Application
	{
        static NavigationPage _mainNavigation;

        public static NavigationPage MainNavigation
        {
            get { return _mainNavigation ?? (_mainNavigation = new NavigationPage(new MainPage()
            {
                Title = "Gallery3"
            })); }
        }

		public App ()
		{
			InitializeComponent();

            MobileCenter.Start("android=cad2b569-91fe-41f8-9652-deb6ddfb089f;" +
                   "ios=9ee90fd3-6d44-4db1-be00-98614aa7051f;",
                   typeof(Analytics), typeof(Crashes));

            MainPage = MainNavigation;
		}

		protected override async void OnStart ()
		{
            await Analytics.SetEnabledAsync(true);
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
