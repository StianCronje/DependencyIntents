
using Android.App;
using Android.Content;
using Android.Net;
using Android.Service.Chooser;
using DependencyIntents.Controls;
using DependencyIntents.Droid.Controls;
using Java.IO;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenURI))]
namespace DependencyIntents.Droid.Controls
{
    public class OpenURI : IOpenURI
    {
        public void OpenLocation(string title, double latitude, double longitude)
        {
            var uri = $"geo:{latitude},{longitude}";
            var intent = new Intent(Intent.ActionView, Uri.Parse(uri));
            var chooser = Intent.CreateChooser(intent, title);
            MainActivity.Instance.StartActivity(chooser);
        }

        public void Share(string title, string message, string imageUri = null)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, message);
            var chooser = Intent.CreateChooser(intent, title);
            MainActivity.Instance.StartActivity(chooser);
        }
    }
}