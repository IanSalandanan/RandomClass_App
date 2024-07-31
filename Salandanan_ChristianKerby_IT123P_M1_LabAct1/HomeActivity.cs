using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using System;

namespace Salandanan_ChristianKerby_IT123P_M1_LabAct1
{
    [Activity(Label = "Lobby", Theme = "@style/AppTheme", MainLauncher = true)]
    public class HomeActivity : AppCompatActivity
    {
        ImageView homeImg;
        Button homeBtn1, homeBtn2;
        Intent intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.Home);

            homeImg = FindViewById<ImageView>(Resource.Id.ivh);
            homeBtn1 = FindViewById<Button>(Resource.Id.btnh1);
            homeBtn2 = FindViewById<Button>(Resource.Id.btnh2);

            AssignVal();
        }

        private void InitiateIntent()
        {
            intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void AssignVal()
        {
            int resourceId = (int)typeof(Resource.Drawable).GetField("LOGO").GetValue(null);
            homeImg.SetImageResource(resourceId);

            homeBtn1.Click += delegate
            {
                InitiateIntent();
            };

            homeBtn2.Click += delegate
            {
                FinishAffinity();
            };
        }
    }
}