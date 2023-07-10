using Plugin.LocalNotification;

namespace UONetLoginerCrossPlatform.Local_Notification
{
    public class LocalPushNotification
    {
        public async Task ShowNotification(string title, string subtitle, string description)
        {
            var notificationRequest = new NotificationRequest
            {
                NotificationId = 1,
                Title = title,
                Subtitle = subtitle,
                Description = description,
                BadgeNumber = 1,
            };

            await LocalNotificationCenter.Current.Show(notificationRequest);
        }
    }
}
