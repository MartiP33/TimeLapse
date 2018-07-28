using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Time_lapse_app
{
    [Activity(Label = "OptionsMenuActivity")]
    public class PhotoOptionsMenuActivity : Activity
    {
        int intervalTime = 10;
        int shootingTime = 120;
        


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.photo_options);

            //Iskanje teh zadeu k jih lah prtisnes
            var intervalChangeButton = FindViewById<Button>(Resource.Id.interval_change_button);
            var shootingTimeChangeButton = FindViewById<Button>(Resource.Id.shooting_time_change_button);
            var resolutionChangeButton = FindViewById<Button>(Resource.Id.resolution_change_button);

            intervalChangeButton.Text = (intervalTime).ToString();
            shootingTimeChangeButton.Text = (shootingTime).ToString();


            intervalChangeButton.Click += delegate
            {

                LayoutInflater layoutInflaterAndroid = LayoutInflater.From(this);
                View mView = layoutInflaterAndroid.Inflate(Resource.Layout.user_input_dialog_box, null);
                Android.Support.V7.App.AlertDialog.Builder alerDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                alerDialogBuilder.SetView(mView);

                var userIntervalTime = mView.FindViewById<EditText>(Resource.Id.dialog_edit_text);
                
                alerDialogBuilder.SetCancelable(false)
                .SetPositiveButton("Ok", delegate
                {
                    intervalTime = Convert.ToInt32(userIntervalTime.Text);
                    Toast.MakeText(this, "Interval time set to " + intervalTime + " seconds", ToastLength.Short).Show();
                    intervalChangeButton.Text = (intervalTime).ToString();
                })
                .SetNegativeButton("Cancel", delegate
                {
                    alerDialogBuilder.Dispose();
                });

                Android.Support.V7.App.AlertDialog alertDialogAndroid = alerDialogBuilder.Create();
                alertDialogAndroid.Show();

                
            };

            shootingTimeChangeButton.Click += delegate
            {
                LayoutInflater layoutInflaterAndroid = LayoutInflater.From(this);
                View mView = layoutInflaterAndroid.Inflate(Resource.Layout.user_input_dialog_box, null);
                Android.Support.V7.App.AlertDialog.Builder alerDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                alerDialogBuilder.SetView(mView);

                var userShootingTime = mView.FindViewById<EditText>(Resource.Id.dialog_edit_text);

                alerDialogBuilder.SetCancelable(false)
                .SetPositiveButton("Ok", delegate
                {
                    shootingTime = Convert.ToInt32(userShootingTime.Text);
                    Toast.MakeText(this, "Shooting time set to " + shootingTime + " minutes", ToastLength.Short).Show();
                    intervalChangeButton.Text = (shootingTime).ToString();
                })
                .SetNegativeButton("Cancel", delegate
                {
                    alerDialogBuilder.Dispose();
                });

                Android.Support.V7.App.AlertDialog alertDialogAndroid = alerDialogBuilder.Create();
                alertDialogAndroid.Show();
            };

            

        }
    }
}