using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace Time_lapse_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.menu_layout);

            var photoModeButton = FindViewById<Button>(Resource.Id.photoModeButton);
            var videoModeButton = FindViewById<Button>(Resource.Id.videoModeButton);
            var aboutButton = FindViewById<Button>(Resource.Id.aboutButton);

            photoModeButton.Click += PhotoModeButton_Click;



        }

        private void PhotoModeButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(PhotoOptionsMenuActivity));
        }
    }
}
