using Android.App;
using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Widget;
using BurgerSpot.Droid;
using ClaroNet3.Interfaces;
using ClaroNet3.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static ClaroNet3.Model.EventsUtilities;

[assembly: Dependency(typeof(SMSReceiver))]
namespace BurgerSpot.Droid
{

    [BroadcastReceiver(Label = "SMS Receiver")]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SMSReceiver : BroadcastReceiver,IServiceSms
    {
        public static readonly string IntentAction = "android.provider.Telephony.SMS_RECEIVED";
        public event EventHandler Mensajes;

        public void AvisoMensaje(List<string> MensajeInbox)
        {
            Mensajes.Invoke(MensajeInbox, new EventArgs());
        }

        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (intent.Action != IntentAction) return;
                getAllSms(context);
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long).Show();
            }
        }

        public void getAllSms(Context context)
        {
            List<string> Inbox = new List<string>();
            ContentResolver cr = context.ContentResolver;
            ICursor c = cr.Query(Telephony.Sms.ContentUri, null, null, null, null);
            if (c != null)
            {
                var totalSMS = c.Count;

                while (c.MoveToNext())
                {
                    if (c.GetString(c.GetColumnIndexOrThrow("ADDRESS")).Equals("RecargaCLR"))
                    {
                        var i = c.GetLong(c.GetColumnIndexOrThrow("DATE"));
                        var id = c.GetInt(c.GetColumnIndexOrThrow("_ID"));
                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime date = start.AddMilliseconds(i).ToLocalTime();
                        Inbox.Add($"Id:{id}.{c.GetString(c.GetColumnIndexOrThrow("BODY"))}{date.ToLongDateString()}.{date.ToShortTimeString()}");
                    }
                }
                Utilities.Notify(Events.SmsRecieved, Inbox);
            }



        }
    }
}