using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android;
using Android.Widget;
using Android.Runtime;

namespace ArcGISAppDemo
{
    [Activity(Label = "ArcGISAppDemo", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected async override void OnCreate(Bundle bundle)
        {

            await TryToGetPermissions();
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        #region RunTimePermissions
        async Task TryToGetPermissions()
        {
            if((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }
        }
        const int RequestLocationId = 0;
        readonly string[] PermissonsGroupLocation =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };
        async Task GetPermissionsAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            if(CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                Toast.MakeText(this, "Special Permissions granted", ToastLength.Short).Show();
                return;
            }
            if (ShouldShowRequestPermissionRationale(permission))
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application needs special permissions to function");
                alert.SetPositiveButton("request permission", (senderAlert, args) =>
                 {
                     RequestPermissions(PermissonsGroupLocation, RequestLocationId);
                 });
                alert.SetNegativeButton("Cancel", (sendAlert, args) =>
                {
                    Toast.MakeText(this, "canceled", ToastLength.Short).Show();
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }
            RequestPermissions(PermissonsGroupLocation, RequestLocationId);

        }
        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Special permissions granted", ToastLength.Short).Show();

                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Special permissions denied", ToastLength.Short).Show();

                        }
                    }
                    break;
            }
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion
    }
}

