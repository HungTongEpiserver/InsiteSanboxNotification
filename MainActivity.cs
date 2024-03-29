﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using WindowsAzure.Messaging.NotificationHubs;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace InsiteSanboxNotification
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        internal static readonly string CHANNEL_ID = "insitesandbox_notification_channel";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Listen for push notifications
            NotificationHub.SetListener(new AzureListener());

            this.CreateNotificationChannel();

            // Start the SDK
            NotificationHub.Start(this.Application, Constants.NotificationHubName, Constants.ListenConnectionString);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            AppCenter.Start("bef48e04-741d-4c09-8d0a-eb2d2b830ead", typeof(Analytics), typeof(Crashes));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                return;

            var channel = new NotificationChannel(CHANNEL_ID, "InsiteSandboxNotification", NotificationImportance.Default)
            {
                Description = "Insite Sandbox"
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}