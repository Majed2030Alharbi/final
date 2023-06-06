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
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var name = FindViewById<EditText>(Resource.Id.name);
            var homenumber = FindViewById<EditText>(Resource.Id.homenumber);
            var city = FindViewById<EditText>(Resource.Id.city);

            var add = FindViewById<Button>(Resource.Id.add);
            var cancel = FindViewById<Button>(Resource.Id.cancel);
            // Create your application here
            add.Click += delegate
            {
                if (!string.IsNullOrEmpty(homenumber.Text) && !string.IsNullOrEmpty(city.Text))
                {
                    var user = new UserOperations.Address()
                    {
                        Name = name.Text,
                        Homenumber = homenumber.Text,
                        City = city.Text,
                    };
                    var sq = new UserOperations();
                    sq.InsertAddress(user);

                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                }
                else
                    Toast.MakeText(this, " HomeNumber or City is empty", ToastLength.Short).Show();

                cancel.Click += delegate
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                };
            };
        }
            }
}