using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FlashDelivery.Class;
using FlashDelivery.Class.Bean;
using FlashDelivery.Present.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashDelivery.Present.Fragment
{
    [Obsolete]
    public class FragmentAdminCreateItem : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private LinearLayout _lnbtlAdd;
        private TextView tvPublish;
        private EditText edtNamePakage;
        private EditText edtLocation;
        private EditText edtKM;
        private EditText edtMoney;
        private List<ItemChild> lstItemChild = new List<ItemChild>();
        private ItemChildAdapter itemChildAdapter;
        private RecyclerView recyclerViewItemchild;
        FirebaseHelpdesk firebaseHelpdesk = new FirebaseHelpdesk();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            mainAct = (MainActivity)this.Activity;
            _inflater = inflater;
            _rootView = inflater.Inflate(Resource.Layout.layout_Admin_Create, null);
            _lnbtlAdd = _rootView.FindViewById<LinearLayout>(Resource.Id.btlAdd);
            tvPublish = _rootView.FindViewById<TextView>(Resource.Id.tvPublish);

            edtNamePakage = _rootView.FindViewById<EditText>(Resource.Id.edtNamePakage);
            edtLocation = _rootView.FindViewById<EditText>(Resource.Id.edtLocation);
            edtKM = _rootView.FindViewById<EditText>(Resource.Id.edtKM);
            edtMoney = _rootView.FindViewById<EditText>(Resource.Id.edtMoney);
            recyclerViewItemchild = _rootView.FindViewById<RecyclerView>(Resource.Id.recyclerViewItemchild);
            tvPublish.Click += TvPublish_Click;
            _lnbtlAdd.Click += _lnbtlAdd_Click;
            mainAct.initNavMenu_to_Admin(2);
            mainAct.lockAndUnlockNavBar(false, "Create Item to dashboard");
            initValue();

            return _rootView;
        }

        private void initValue()
        {
            edtNamePakage.Text = "Pakagename";
            edtLocation.Text = "Location";
            edtKM.Text = "10";
            edtMoney.Text = "1000000";
            lstItemChild.Add(new ItemChild { Count_Item = 2, Details = "detaild1 1" });
            lstItemChild.Add(new ItemChild { Count_Item = 2, Details = "detaild1 2" });
            itemChildAdapter = new ItemChildAdapter(lstItemChild);
            recyclerViewItemchild.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
            recyclerViewItemchild.NestedScrollingEnabled = false;
            recyclerViewItemchild.SetAdapter(itemChildAdapter);

        } 
        private void initnull()
        {
            edtNamePakage.Text = "";
            edtLocation.Text = "";
            edtKM.Text = "";
            edtMoney.Text = "";
            lstItemChild.Clear();
            itemChildAdapter = new ItemChildAdapter(lstItemChild);
            recyclerViewItemchild.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
            recyclerViewItemchild.NestedScrollingEnabled = false;
            recyclerViewItemchild.SetAdapter(itemChildAdapter);

        }

        private void TvPublish_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(edtNamePakage.Text)
                || string.IsNullOrEmpty(edtLocation.Text)
                || string.IsNullOrEmpty(edtKM.Text)
                || string.IsNullOrEmpty(edtMoney.Text))
            {
                Toast.MakeText(mainAct.ApplicationContext, "Some thing is null ", ToastLength.Short).Show();
            } 
            else
            {
                try
                {
                    BeanItemDetails beanItemDetails = new BeanItemDetails
                    {
                        pakage_Name = edtNamePakage.Text,
                        location = edtLocation.Text,
                        kilomet = Convert.ToInt32(edtKM.Text),
                        Money = Convert.ToInt32(edtMoney.Text),
                        ListItemChild = lstItemChild
                    };
                    firebaseHelpdesk.AddItem(beanItemDetails);
                    initnull();
                }
                catch (Exception exception)
                {
                    Toast.MakeText(mainAct.ApplicationContext, "Some thing is wrong ", ToastLength.Short).Show();

                }
            }    
            

            
        }

        private void _lnbtlAdd_Click(object sender, EventArgs e)
        {
            View popupImage = _inflater.Inflate(Resource.Layout.layout_popupAddDetails, null);
            TextView tvAddChildItem = popupImage.FindViewById<TextView>(Resource.Id.tvAddChildItem);
            EditText tvAdd_DetailItem = popupImage.FindViewById<EditText>(Resource.Id.tvAdd_DetailItem);
            EditText tvAdd_DetailCountItem = popupImage.FindViewById<EditText>(Resource.Id.tvAdd_DetailCountItem);
            Dialog dig = new Dialog(_rootView.Context);
            if (popupImage != null)
            {
                
                Window window = dig.Window;
                dig.RequestWindowFeature(1);
                dig.SetCanceledOnTouchOutside(true);
                dig.SetCancelable(true);
                window.SetGravity(GravityFlags.Center);

                DisplayMetrics dm = Resources.DisplayMetrics;
                ViewGroup.LayoutParams pa = popupImage.LayoutParameters;
                dig.SetContentView(popupImage);
                dig.Show();
                WindowManagerLayoutParams s = window.Attributes;
                s.Width = dm.WidthPixels;
                window.Attributes = s;
            }
            tvAddChildItem.Click += (s, e) =>
            {
                if(!string.IsNullOrEmpty(tvAdd_DetailItem.Text)&& !string.IsNullOrEmpty(tvAdd_DetailCountItem.Text))
                {
                    lstItemChild.Add(new ItemChild { Count_Item = Convert.ToInt32(tvAdd_DetailCountItem.Text), Details = tvAdd_DetailItem.Text });
                    itemChildAdapter = new ItemChildAdapter(lstItemChild);
                    recyclerViewItemchild.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                    recyclerViewItemchild.NestedScrollingEnabled = false;
                    recyclerViewItemchild.SetAdapter(itemChildAdapter);
                    dig.Dismiss();
                }
                else
                {
                    // show alert can't null
                }
            };
            
        }

    }
}