using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace FshHfEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class FileSystemHelperDemo : Activity
    {
        private Button myButton;
        private TextView myText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.fshDemo);

            myButton = FindViewById<Button>(Resource.Id.buttonFHP);
            myText = FindViewById<TextView>(Resource.Id.textViewFHP);

            myButton.Click += MyButton_Click;
        }

        [Obsolete]
        private async void MyButton_Click(object sender, EventArgs e)
        {
            const string filename = "Shin.txt";
            using (var stream = await FileSystem.OpenAppPackageFileAsync(filename)) 
            {
                using (var reader = new StreamReader(stream)) 
                {
                    myText.Text = await reader.ReadToEndAsync();
                }
            
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}