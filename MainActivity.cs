using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;
using FlashDelivery.Class;
using FlashDelivery.Present.Fragment;

namespace FlashDelivery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@drawable/logoFlashApp")]
    public class MainActivity : AppCompatActivity
    {
        FragmentStartView StartView;
        public DrawerLayout drawer_layout;
        public Toolbar toolbar_app;
        public NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout_main);

            // init navigation bar


            lockAndUnlockNavBar(true, "");

            StartView = new FragmentStartView();
            ShowFragment(FragmentManager, StartView, "");
        }
        // mode 1 user 2 addimi
        public void initNavMenu_to_Admin(int mode)
        {
            if (mode == 2)
            {
                navigationView.Menu.FindItem(Resource.Id.navDashBoard).SetVisible(false);
                navigationView.Menu.FindItem(Resource.Id.navListShip).SetVisible(false);
                navigationView.Menu.FindItem(Resource.Id.navAddItem).SetVisible(true);

            }
            else
            {
                navigationView.Menu.FindItem(Resource.Id.navAddItem).SetVisible(false);
                navigationView.Menu.FindItem(Resource.Id.navDashBoard).SetVisible(true);
                navigationView.Menu.FindItem(Resource.Id.navListShip).SetVisible(true);
            }

        }
        public void lockAndUnlockNavBar(bool Lock, string headerNameToolbar)
        {
            drawer_layout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            toolbar_app = FindViewById<Toolbar>(Resource.Id.toolbar_app);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView1);


            if (Lock)
            {
                drawer_layout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
                toolbar_app.Visibility = ViewStates.Gone;
            }
            else
            {
                drawer_layout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
                toolbar_app.Visibility = ViewStates.Visible;
                SetSupportActionBar(toolbar_app);
                SupportActionBar.Title = headerNameToolbar;
                AndroidX.AppCompat.App.ActionBar actionBar = SupportActionBar;
                toolbar_app.SetTitleTextColor(Color.White);
                actionBar.SetDisplayHomeAsUpEnabled(false);
                navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;


            }

        }

        [System.Obsolete]
        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            if (e.MenuItem.ItemId == Resource.Id.navDashBoard)
            {
                FragmentDashBoard fragmentDashBoard = new FragmentDashBoard();
                ShowFragment(FragmentManager, fragmentDashBoard, "");
                drawer_layout.CloseDrawers();
            }
            if (e.MenuItem.ItemId == Resource.Id.navAddItem)
            {
                FragmentAdminCreateItem fragmentDashBoard = new FragmentAdminCreateItem();
                ShowFragment(FragmentManager, fragmentDashBoard, "");
                drawer_layout.CloseDrawers();
                SupportActionBar.Title = "Add item to dashboard";

            }
            if (e.MenuItem.ItemId == Resource.Id.navProfile)
            {
                Fragment_Profile fragmentDashBoard = new Fragment_Profile();
                ShowFragment(FragmentManager, fragmentDashBoard, "");
                drawer_layout.CloseDrawers();
                SupportActionBar.Title = "PROFILE";

            }
            if (e.MenuItem.ItemId == Resource.Id.navListShip)
            {
                FragmentListShip fragmentListShip = new FragmentListShip();
                ShowFragment(FragmentManager, fragmentListShip, "");
                drawer_layout.CloseDrawers();
                SupportActionBar.Title = "LISTSHIP";
            }
            if (e.MenuItem.ItemId == Resource.Id.navSummary)
            {
                Fragment_ReportList fragment_ReportList = new Fragment_ReportList();
                ShowFragment(FragmentManager, fragment_ReportList, "");
                drawer_layout.CloseDrawers();
                SupportActionBar.Title = "Report";

            }
            if (e.MenuItem.ItemId == Resource.Id.navLogout)
            {
                FragmentSignInSignUp fragmentSignInSignUp = new FragmentSignInSignUp();
                ShowFragment(FragmentManager, fragmentSignInSignUp, "");

                drawer_layout.CloseDrawers();

            }

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawer_layout.OpenDrawer((int)GravityFlags.Start);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);

            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [System.Obsolete]
        public void ShowFragment(Android.App.FragmentManager fm, Android.App.Fragment fragToShow, string fragTag)
        {

            string previousFragTag = "";
            Fragment previousFrag = null;
            try
            {


                Android.App.FragmentTransaction fragmentTx;
                fragmentTx = fm.BeginTransaction();
                fragmentTx.Replace(Resource.Id.frmMain, fragToShow, fragTag);
                if (fm.FindFragmentByTag(fragTag) == null)
                {
                    if (!string.IsNullOrEmpty(fragTag))
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