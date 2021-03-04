using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using System;
using WindowsAzure.Messaging.NotificationHubs;

namespace InsiteSanboxNotification
{
    public class AzureListener : Java.Lang.Object, INotificationListener
    {
        public void OnPushNotificationReceived(Context context, INotificationMessage message)
        {
            var intent = new Intent(context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID);

            var title = message.Title;
            var content = message.Body;

            notificationBuilder.SetContentTitle(title)
                        .SetSmallIcon(Resource.Mipmap.ic_launcher)
                        .SetContentText(content)
                        .SetAutoCancel(true)
                        .SetShowWhen(true)
                        .SetContentIntent(pendingIntent)
                        .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                        .SetVisibility((int)NotificationVisibility.Public);

            // Build the notification:
            var notification = notificationBuilder.Build();

            // Get the notification manager:
            var notificationManager = NotificationManager.FromContext(context);
            // Publish the notification:
            var notificationId = new Random().Next(0, int.MaxValue);
            notificationManager.Notify(notificationId, notification);
        }
    }
}