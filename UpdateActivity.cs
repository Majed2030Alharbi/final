using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_final_test
{
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_update);

            var uid = FindViewById<TextView>(Resource.Id.uid);

            var name = FindViewById<EditText>(Resource.Id.name);
            var homenumber = FindViewById<EditText>(Resource.Id.homenumber);
            var city = FindViewById<EditText>(Resource.Id.city);

            var update = FindViewById<Button>(Resource.Id.update);
            var delete = FindViewById<Button>(Resource.Id.delete);
            var cancel = FindViewById<Button>(Resource.Id.cancel);

            uid.Text = Intent.GetStringExtra("Id");
            var sq = new UserOperations();
            var user = sq.GetAdressById(Convert.ToInt32(uid.Text));

            name.Text = user.Username;
            homenumber.Text = user.homenumber;
            city.Text = user.City;

            update.Click += delegate
            {
                if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(homenumber.Text))
                {
                    user.Username = name.Text;
                    user.homenumber = homenumber.Text;
                    user.City = city.Text;

                    var sq = new UserOperations();
                    sq.UpdateAdress(user);
                    //user = null;
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, " Name or city is empty", ToastLength.Short).Show();
                }
            };
            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(InfoActivity));
                i.PutExtra("Id", user.Id + "");
                StartActivity(i);
            };
            delete.Click += delegate
            {
                var sq = new UserOperations();
                sq.DeleteAdress(user);
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };
        }
    }
}