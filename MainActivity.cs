using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.AppCompat.App;
using FlashDelivery.Present.Fragment;

namespace FlashDelivery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,Icon = "@drawable/logoFlashApp")]
    public class MainActivity : AppCompatActivity
    {
        FragmentStartView StartView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout_main);
            StartView = new FragmentStartView();
            ShowFragment(FragmentManager, StartView, "StartView");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void ShowFragment(Android.App.FragmentManager fm, Android.App.Fragment fragToShow, string fragTag)
        {

            string previousFragTag = "";
            Fragment previousFrag = null;
            try
            {
              

                Android.App.FragmentTransaction fragmentTx;
                fragmentTx = fm.BeginTransaction();
                fragmentTx.Replace(Resource.Id.frmMain, fragToShow, fragTag);
                if(fm.FindFragmentByTag(fragTag)==null)
                {  
                fragmentTx.AddToBackStack(fragTag);
                }
                fragmentTx.SetTransition(FragmentTransit.FragmentFade);
                fragmentTx.Commit();
                FragmentManager.ExecutePendingTransactions();
               
            }
            catch (Java.Lang.Exception ex)
            {
               

            }
            finally
            {
            }
        }
        public void ReShowFragment(Android.App.FragmentManager fm, Android.App.Fragment fragToShow, string fragTag)
        {

            string previousFragTag = "";
            Fragment previousFrag = null;
            try
            {


                Android.App.FragmentTransaction fragmentTx;
                fragmentTx = fm.BeginTransaction();
                
                if (fm.FindFragmentByTag(fragTag) != null)
                {
                    fragmentTx.Remove(fm.FindFragmentByTag(fragTag)).Commit();
                    fragmentTx.Replace(Resource.Id.frmMain, fragToShow, fragTag);
                    
                }
                fragmentTx.SetTransition(FragmentTransit.FragmentFade);
                fragmentTx.Commit();
                FragmentManager.ExecutePendingTransactions();

            }
            catch (Java.Lang.Exception ex)
            {


            }
            finally
            {
            }
        }
        public void HideKeyboard(View _rootview)
        {
            InputMethodManager imm = InputMethodManager.FromContext(_rootview.Context);

            imm.HideSoftInputFromWindow(_rootview.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}