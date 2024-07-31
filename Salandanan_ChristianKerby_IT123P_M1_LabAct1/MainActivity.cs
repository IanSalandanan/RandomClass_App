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
    [Activity(Label = "Randomizer", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private Intent intent;
        private TextView textDisplay;
        private ImageView img1, img2;
        private EditText textInput;
        private Button bt0, bt1, bt2, bt3;

        private Randomizer rar;

        private string[] countries = { "USA", "SKOR", "PH", "JAPAN", "ITALY", "GREECE", "GERMANY", "FRANCE", "EGYPT", "BRAZIL" };
        private string[] items = {"1","2","3","4","5"};
        private string[] texts = {"Hello There", "Annyeonghaseyo", "Kumusta", "Kon'nichiwa", "Ciao", "Yassou", "Hallo!", "Bonjour", "Salaam 'alei-kum", "Olá"};

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.MainApp);

            textDisplay = FindViewById<TextView>(Resource.Id.tv1);
            img1 = FindViewById<ImageView>(Resource.Id.iv1);
            img2 = FindViewById<ImageView>(Resource.Id.iv2);
            textInput = FindViewById<EditText>(Resource.Id.userInp);
            bt0 = FindViewById<Button>(Resource.Id.bt0);
            bt1 = FindViewById<Button>(Resource.Id.bt1);
            bt2 = FindViewById<Button>(Resource.Id.bt2);
            bt3 = FindViewById<Button>(Resource.Id.bt3);

            InitiateApp();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitiateIntent()
        {
            intent = new Intent(this, typeof(HomeActivity));
            StartActivity(intent);
        }

        public void ApplyInterval()
        {
            rar.SetSpeed(int.Parse(textInput.Text.ToString()));
        }

        public void InitiateApp()
        {
            rar = new Randomizer(textDisplay, img1, img2, countries, items, texts);

            bt0.Click += delegate
            {
                InitiateIntent();
            };

            bt1.Click += delegate
            {
                rar.Bt1_Response();
            };

            bt2.Click += delegate
            {

                if (!string.IsNullOrEmpty(textInput.Text))
                {
                    ApplyInterval();
                    rar.Bt2_Response(); 
                }
                else
                {
                    rar.ShowToastMessage(this);
                }

            };

            bt3.Click += delegate
            {
                rar.Pause();
            };
        }
    }
}