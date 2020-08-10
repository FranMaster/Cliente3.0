
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace ClaroNet3._0.Droid
{
    [Activity(Label = "ClaroNet3._0", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            RequestPermissions(new string[]
           {
                Android.Manifest.Permission.CallPhone,
                Android.Manifest.Permission.CallPrivileged,
                Android.Manifest.Permission.BroadcastSms,
                Android.Manifest.Permission.SendSms,
                Android.Manifest.Permission.ReceiveSms,
                Android.Manifest.Permission.ReadSms,
                Android.Manifest.Permission.WriteSms
           }, 0);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}