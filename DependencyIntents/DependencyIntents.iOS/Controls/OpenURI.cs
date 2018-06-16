﻿using System;
using System.Collections.Generic;
using DependencyIntents.Controls;
using DependencyIntents.iOS.Controls;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenURI))]
namespace DependencyIntents.iOS.Controls
{
    public class OpenURI : IOpenURI
    {
        public void OpenLocation(string title, double latitude, double longitude)
        {
            var uriDict = new Dictionary<string, NSUrl>
            {
                {"Apple Maps", new NSUrl($"maps://?p={latitude},{longitude}")},
                {"Google Maps", new NSUrl($"comgooglemaps://?center={latitude},{longitude}")},
                {"Uber", new NSUrl($"uber://?dropoff[latitude]={latitude}&dropoff[longitude]={longitude}")},
                {"Lyft", new NSUrl($"lyft://?destination[latitude]={latitude}&destination[longitude]={longitude}")}
            };

            var alert = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            foreach (var uri in uriDict)
            {
                if (UIApplication.SharedApplication.CanOpenUrl(uri.Value))
                {
                var action = UIAlertAction.Create(uri.Key.ToString(), UIAlertActionStyle.Default,
                    (s) => { UIApplication.SharedApplication.OpenUrl(uri.Value); });
                alert.AddAction(action);
                }
            }

            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);
            alert.AddAction(cancelAction);

            var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
            controller.PresentViewController(alert, true, null);

        }

        public void Share(string title, string message, string imageUrl = null)
        {
            
        }
    }
}