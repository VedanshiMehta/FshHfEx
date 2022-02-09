using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace FshHfEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button bFsh;
        private Button bHf;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            bFsh = FindViewById<Button>(Resource.Id.button1);
            bHf = FindViewById<Button>(Resource.Id.button2);

            bFsh.Click += BFsh_Click;
            bHf.Click += BHf_Click;
        }

        private void BHf_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(this, typeof(HapticFeedbackDemo));
            StartActivity(j);
        }

        private void BFsh_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(FileSystemHelperDemo));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}