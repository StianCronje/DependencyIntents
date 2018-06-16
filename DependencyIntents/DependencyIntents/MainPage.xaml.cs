using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DependencyIntents.Controls;
using Xamarin.Forms;

namespace DependencyIntents
{
	public partial class MainPage : ContentPage
	{
	    private IOpenURI _uriManager;

		public MainPage()
		{
			InitializeComponent();

		    _uriManager = DependencyService.Get<IOpenURI>();

		}

	    private async Task GeoClicked(object sender, EventArgs eventArgs)
	    {
//            switch (Device.RuntimePlatform)
//            {
//                case Device.Android:
            _uriManager.OpenLocation("Open With...", 19.076, 72.877);
//                    break;
//                case Device.iOS:
//                    var result = await DisplayActionSheet("Open With...", "Cancel", null, "Apple Maps", "Google Maps", "Uber", "Lyft");
//                    Debug.WriteLine(result);
//                    break;
//                }
        }
        private void ShareClicked(object sender, EventArgs eventArgs)
	    {
	        var str = !string.IsNullOrEmpty(shareEntry.Text) ? shareEntry.Text : "";
            _uriManager.Share("Share With...", str);
	    }

    }
}
