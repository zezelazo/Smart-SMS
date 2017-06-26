using Android.App;
using Android.Content;

namespace SmartSMS.Droid
{
    [BroadcastReceiver]
    public class SMSDeliveredReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            switch ((int)ResultCode)
            {
                case (int)Result.Ok:
                    //Toast.MakeText(Application.Context, "SMS Delivered", ToastLength.Short).Show();

                    break;
                case (int)Result.Canceled:
                    //Toast.MakeText(Application.Context, "SMS not delivered", ToastLength.Short).Show();
                    break;
            }
        }
    }

}

