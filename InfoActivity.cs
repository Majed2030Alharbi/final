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
    [Activity(Label = "InfoActivity")]
    public class InfoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_info);



            var show = FindViewById<TextView>(Resource.Id.show);

            var logout = FindViewById<Button>(Resource.Id.logout);
            var search = FindViewById<Button>(Resource.Id.search);
            var sq = new UserOperations();

            search.Click += delegate
            {
                var tables = sq.Search(City.Text);
                string data = "";
                foreach (var s in tables)
                    data += s.Id + "\t" + s.Username + "\t" + s.Password + "\t" + s.City + "\n";
                show.Text = data;
            };

            logout.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

        }
    }
}