using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace The_final_test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var homenumber = FindViewById<EditText>(Resource.Id.homenumber);
            var city = FindViewById<EditText>(Resource.Id.city);
            var Go = FindViewById<Button>(Resource.Id.go);
            var Add = FindViewById<Button>(Resource.Id.add);

            Go.Click += delegate
            {
                if (!string.IsNullOrEmpty(homenumber.Text) && !string.IsNullOrEmpty(city.Text))
                {
                    var sq = new UserOperations();
                    var user = sq.GoAddress(homenumber.Text, city.Text);
                    if (user != null)
                    {
                        Intent i = new Intent(this, typeof(InfoActivity));
                        i.PutExtra("Id", user.Id + "");
                        StartActivity(i);
                    }
                    else
                        Toast.MakeText(this, "Username or Password is not correct !!!", ToastLength.Long).Show();
                }
                else
                    Toast.MakeText(this, "Username or Password is Empty !!!", ToastLength.Long).Show();
            };



            Add.Click += delegate
            {
                var i = new Intent(this, typeof(AddActivity));
                StartActivity(i);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}