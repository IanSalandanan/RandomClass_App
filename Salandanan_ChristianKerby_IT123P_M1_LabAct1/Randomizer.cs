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
using System.Timers;
using Android.Graphics.Drawables;
using Java.Lang;
using static Android.Graphics.ColorSpace;

namespace Salandanan_ChristianKerby_IT123P_M1_LabAct1
{
    public class Randomizer
    {
        private Random rgn;
        private Timer timer;

        private TextView textDisplay;
        private ImageView imageView1, imageView2;

        private int tmrSpeed, index, itemIndex;
        private string itemName;

        private string[] arr_images1;
        private string[] arr_images2;
        private string[] arr_texts;

        public Randomizer(TextView txtD, ImageView im1, ImageView im2, string[] arr1, string[] arr2, string[] arr3)
        {
            arr_images1 = arr1;
            arr_images2 = arr2;
            arr_texts = arr3;

            textDisplay = txtD;
            imageView1 = im1;
            imageView2 = im2;

            rgn = new Random();
            timer = new Timer();
        }

        public void SetSpeed(int userNum)
        {
            tmrSpeed = userNum;
        }

        public void Bt1_Response()
        {
            index = rgn.Next(arr_images1.Length);
            textDisplay.Text = arr_texts[index];
            int resourceId = (int)typeof(Resource.Drawable).GetField(arr_images1[index]).GetValue(null);
            imageView1.SetImageResource(resourceId);
        }

        public void Bt2_Response()
        {
            timer.Interval = tmrSpeed;
            timer.Elapsed += GenerateRandomItem;
            timer.Start();
        }

        private void GenerateRandomItem(object sender, ElapsedEventArgs e)
        {
            itemIndex = rgn.Next(arr_images2.Length);
            itemName = $"{arr_images1[index]}{arr_images2[itemIndex]}";
            int resourceId2 = (int)typeof(Resource.Drawable).GetField(itemName).GetValue(null);
            imageView2.SetImageResource(resourceId2);
        }

        public void ShowToastMessage(Context context)
        {
            Toast.MakeText(context, "Please enter a valid time interval", ToastLength.Short).Show();
        }

        public void Pause()
        {
            timer.Stop();
            timer.AutoReset = true;
        }
    }
}