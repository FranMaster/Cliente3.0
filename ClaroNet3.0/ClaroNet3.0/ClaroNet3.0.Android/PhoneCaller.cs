using Android.Content;
using ClaroClient3.Droid;
using ClaroNet3.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCaller))]
namespace ClaroClient3.Droid
{
    public class PhoneCaller : IServiceCaller
    {
        //pin fran 2232
        public  void RealizarLLamadaRecarga(string phone, string monto,string pin)
        {
            try
            {
                string Combinacion = $"*321*1*{phone}*{monto}*{pin}*1#";
                var uri = string.Empty;
                var ussd = string.Format("tel:{0}", Combinacion);
                foreach (char c in ussd.ToCharArray())
                {
                    if (c == '#')                    
                        uri += Android.Net.Uri.Encode("#");                    
                    else                    
                       uri += c;                    
                }
                var Uri = Android.Net.Uri.Parse(uri);
                var intent = new Intent(Intent.ActionCall, Uri);
                intent.SetFlags(ActivityFlags.NewTask);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                Android.App.Application.Context.StartActivity(intent);

            }
            catch (System.Exception e )
            {
                throw;
            }
        }

        public  void RealizarLLamadaSaldo(string pin)
        {
            try
            {
                string Combinacion = $"*321*6*3*{pin}#";
                var uri = string.Empty;
                var ussd = string.Format("tel:{0}", Combinacion);
                foreach (char c in ussd.ToCharArray())
                {
                    if (c == '#')                    
                        uri += Android.Net.Uri.Encode("#");                    
                    else                    
                        uri += c;                    
                }
                var Uri = Android.Net.Uri.Parse(uri);
                var intent = new Intent(Intent.ActionCall, Uri);
                intent.SetFlags(ActivityFlags.NewTask);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                Android.App.Application.Context.StartActivity(intent);

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}