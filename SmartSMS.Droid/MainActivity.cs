using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System.Net;
using System.IO;
using System.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Telephony;

namespace SmartSMS.Droid
{
    [Activity(Label = "SmartSMS.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> _events;
        private SmsManager _smsManager;
        private int _sended;
        private int _delivered;
        private int _expected;
        private BroadcastReceiver _smsSentBroadcastReceiver, _smsDeliveredBroadcastReceiver;
     
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _smsManager = SmsManager.Default;

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private async Task<IEnumerable<PendingSMS>> GetMessages()
        {
            _events.Add("Tratando de obtener mensajes nuevos por enviar");
            string url = "http://dir/api/sms?pending=true";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
                    return (IEnumerable<PendingSMS>)jsonDoc;
                }
            }

        }

        private void SendMenssages(List<PendingSMS> items)
        {
            _expected = items.Count;
            for (int i = 0; i < items.Count - 1; i++)
            {
                _events.Add($"Enviando SMS {i + 1} de {items.Count}");

                var iSent = new Intent("SMS_SENT");
                iSent.PutExtra("Id", "SMSID");
                var piSent = PendingIntent.GetBroadcast(this, 0, iSent, 0);

                var iDelivered = new Intent("SMS_DELIVERED");
                iDelivered.PutExtra("Id", "SMSID");
                var piDelivered = PendingIntent.GetBroadcast(this, 0, iDelivered, 0);


                _smsManager.SendTextMessage("1234567890", null, "Hello from Xamarin.Android", null, null);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            _smsSentBroadcastReceiver = new SMSSentReceiver();
            _smsDeliveredBroadcastReceiver = new SMSDeliveredReceiver();

            RegisterReceiver(_smsSentBroadcastReceiver, new IntentFilter("SMS_SENT"));
            RegisterReceiver(_smsDeliveredBroadcastReceiver, new IntentFilter("SMS_DELIVERED"));
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterReceiver(_smsSentBroadcastReceiver);
            UnregisterReceiver(_smsDeliveredBroadcastReceiver);
        }

    }

}

