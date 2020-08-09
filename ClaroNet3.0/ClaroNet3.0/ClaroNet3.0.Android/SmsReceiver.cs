using Android.App;
using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Widget;
using BurgerSpot.Droid;
using ClaroClient2.Helpers;
using ClaroClient2.model;
using Java.Sql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
[assembly: Dependency(typeof(SMSReceiver))]
namespace BurgerSpot.Droid
{

    [BroadcastReceiver(Label = "SMS Receiver")]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SMSReceiver : BroadcastReceiver
    {
        public static readonly string IntentAction = "android.provider.Telephony.SMS_RECEIVED";
      
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (intent.Action != IntentAction) return;

                var bundle = intent.Extras;
                if (bundle == null) return;
                var pdus = bundle.Get("pdus");
                var castedPdus = JNIEnv.GetArray<Java.Lang.Object>(pdus.Handle);
                var msgs = new SmsMessage[castedPdus.Length];
                var sb = new StringBuilder();
                MensajeRecibido mensajeRecibido = new MensajeRecibido();
                string sender = null;
                for (var i = 0; i < msgs.Length; i++)
                {
                    var bytes = new byte[JNIEnv.GetArrayLength(castedPdus[i].Handle)];
                    JNIEnv.CopyArray(castedPdus[i].Handle, bytes);
                    msgs[i] = SmsMessage.CreateFromPdu(bytes);
                    if (sender == null)
                        sender = msgs[i].OriginatingAddress;
                    mensajeRecibido.NumeroOrigen = msgs[i].ServiceCenterAddress;
                    mensajeRecibido.Mensaje = msgs[i].MessageBody;
                    mensajeRecibido.InfoOrigen = msgs[i].OriginatingAddress;
                    mensajeRecibido.TimeStamp = msgs[i].TimestampMillis;

                }
                getAllSms(context);
                Utilities.Notify(Events.SmsRecieved, mensajeRecibido);
             
               
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
                        Inbox.Add( $"Id:{id}.{c.GetString(c.GetColumnIndexOrThrow("BODY"))}{date.ToLongDateString()}.{date.ToShortTimeString()}");               
                    }               
                }
            }



        }
    }
}