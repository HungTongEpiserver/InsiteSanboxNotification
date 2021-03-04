using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsiteSanboxNotification
{
    public static class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://insitesandbox.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=Ec62MmNAPPEY/djraDyMTtpsoyOyyazhB0zU2DhE1dA=";
        public const string NotificationHubName = "mobiledevhub";
    }
}