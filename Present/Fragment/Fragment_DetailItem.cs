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
using System.Threading.Tasks;
using static Android.App.ActionBar;

namespace FlashDelivery.Present.Fragment
{
    [Obsolete]
    public class Fragment_DetailItem : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private ImageButton BtnbackDetailItem;
        private BeanItemDetails beanItemDetails;
        private BeanReport beanItemDetails1;
        private EditText edtNamePakage;
        private EditText edtLocation;
        private EditText edtKM;
        private EditText edtMoney;
        private ItemChildAdapter itemChildAdapter;
        private RecyclerView recyclerViewItemchild;
        private List<ItemChild> lstItemChild = new List<ItemChild>();
        private Button btnAddtoListShip;
        private Button btnCancel;
        private Button btnSuccess;
        private FirebaseHelpdesk firebaseHelpdesk = new FirebaseHelpdesk();
        bool isListShip;
        private LinearLayout linearLayoutListSHip;
        private Dialog popupDialog;
        private EditText edt_Noidunfreport;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public Fragment_DetailItem(BeanItemDetails beanItemDetails, bool isListShip = false)
        {
            this.beanItemDetails = beanItemDetails;
            this.isListShip = isListShip;
        }
        public Fragment_DetailItem(BeanReport beanItemDetails, bool isListShip = false)
        {
            this.beanItemDetails1 = beanItemDetails;
            this.isListShip = isListShip;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            mainAct = (MainActivity)this.Activity;
            _inflater = inflater;
            _rootView = inflater.Inflate(Resource.Layout.layout_detailitem, null);
            BtnbackDetailItem = _rootView.FindViewById<ImageButton>(Resource.Id.backDetailItem);

            edtNamePakage = _rootView.FindViewById<EditText>(Resource.Id.edtNamePakage);
            edtLocation = _rootView.FindViewById<EditText>(Resource.Id.edtLocation);
            edtKM = _rootView.FindViewById<EditText>(Resource.Id.edtKM);
            edtMoney = _rootView.FindViewById<EditText>(Resource.Id.edtMoney);
            recyclerViewItemchild = _rootView.FindViewById<RecyclerView>(Resource.Id.recyclerViewItemchild);
            btnAddtoListShip = _rootView.FindViewById<Button>(Resource.Id.btnAdd);
            btnSuccess = _rootView.FindViewById<Button>(Resource.Id.btnSuccess);
            btnCancel = _rootView.FindViewById<Button>(Resource.Id.btnCancel);
            linearLayoutListSHip = _rootView.FindViewById<LinearLayout>(Resource.Id.linearLayoutListSHip);

            initValue();
            if (isListShip)
            {
                btnAddtoListShip.Visibility = ViewStates.Gone;
                linearLayoutListSHip.Visibility = ViewStates.Visible;
            }
            else
            {
                if (beanItemDetails1 == null)
                {
                    btnAddtoListShip.Visibility = ViewStates.Visible;
                    linearLayoutListSHip.Visibility = ViewStates.Gone;
                }
                else if (beanItemDetails1.TypeSHip == 0)
                {
                    btnAddtoListShip.Visibility = ViewStates.Visible;
                    linearLayoutListSHip.Visibility = ViewStates.Gone;
                }
                else if(beanItemDetails1.TypeSHip!=0)
                {
                    btnAddtoListShip.Visibility = ViewStates.Gone;
                    linearLayoutListSHip.Visibility = ViewStates.Gone;
                }    
            }
            BtnbackDetailItem.Click += BtnbackDetailItem_Click;
            btnAddtoListShip.Click += BtnAddtoListShip_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSuccess.Click += BtnSuccess_Click;
            return _rootView;
        }

        private void BtnSuccess_Click(object sender, EventArgs e)
        {
            BeanReport beanReport = new BeanReport
            {
                DateTime = DateTime.Now,
                kilomet = beanItemDetails.kilomet,
                ListItemChild = beanItemDetails.ListItemChild,
                location = beanItemDetails.location,
                Money = beanItemDetails.Money,
                pakage_Name = beanItemDetails.pakage_Name,
                user = beanItemDetails.user,
                pass = beanItemDetails.pass,
                TypeSHip = 0,
                DetailReport = "Thanh cong"
            };
            firebaseHelpdesk.AddItemToReport(beanReport);
            firebaseHelpdesk.DeleteItemListShipToMoveReport(beanItemDetails);

            if (isListShip)
            {
                FragmentListShip fragmentListShip = new FragmentListShip();
                mainAct.ShowFragment(FragmentManager, fragmentListShip, "");
            }
            else
            {
                Fragment_ReportList fragment_ReportList = new Fragment_ReportList();
                mainAct.ShowFragment(FragmentManager, fragment_ReportList, "");
            }
            Toast.MakeText(this.Activity, "Update Success", ToastLength.Short).Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            popupDialog = new Dialog(this.Activity);
            popupDialog.SetContentView(Resource.Layout.layout_Popup_Report);
            popupDialog.Window.SetLayout(LayoutParams.MatchParent, LayoutParams.WrapContent);
            popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            popupDialog.Show();
            edt_Noidunfreport = popupDialog.FindViewById<EditText>(Resource.Id.edt_Noidunfreport);
            Button btnSendReport = popupDialog.FindViewById<Button>(Resource.Id.btnSendReport);
            btnSendReport.Click += BtnSendReport_Click;

        }

        private void BtnSendReport_Click(object sender, EventArgs e)
        {
            BeanReport beanReport = new BeanReport
            {
                DateTime = DateTime.Now,
                kilomet = beanItemDetails.kilomet,
                ListItemChild = beanItemDetails.ListItemChild,
                location = beanItemDetails.location,
                Money = beanItemDetails.Money,
                pakage_Name = beanItemDetails.pakage_Name,
                user = beanItemDetails.user,
                pass = beanItemDetails.pass,
                TypeSHip = 1,
                DetailReport = edt_Noidunfreport.Text
            };
            firebaseHelpdesk.AddItemToReport(beanReport);
            firebaseHelpdesk.DeleteItemListShipToMoveReport(beanItemDetails);
            popupDialog.Dismiss();

            if (isListShip)
            {
                FragmentListShip fragmentListShip = new FragmentListShip();
                mainAct.ShowFragment(FragmentManager, fragmentListShip, "");
            }
            else
            {
                Fragment_ReportList fragment_ReportList = new Fragment_ReportList();
                mainAct.ShowFragment(FragmentManager, fragment_ReportList, "");
            }
            Toast.MakeText(this.Activity, "Update Success", ToastLength.Short).Show();

        }

        private void BtnAddtoListShip_Click(object sender, EventArgs e)
        {
            if(beanItemDetails1!=null)
            {
                firebaseHelpdesk.DeleteItemReport(beanItemDetails1);
                beanItemDetails1.TypeSHip = 2;
                firebaseHelpdesk.AddItemToReport(beanItemDetails1);
                Fragment_ReportList fragment_ReportList = new Fragment_ReportList();
                mainAct.ShowFragment(FragmentManager, fragment_ReportList, "");
            } 
            else
            {
                Toast.MakeText(this.Context, "Move to list ship success", ToastLength.Short).Show();
                BeanItemShip beanItemShip = new BeanItemShip
                {
                    user = CmmVariable.user,
                    pass = CmmVariable.pass,
                    kilomet = beanItemDetails.kilomet,
                    ListItemChild = beanItemDetails.ListItemChild,
                    location = beanItemDetails.location,
                    Money = beanItemDetails.Money,
                    pakage_Name = beanItemDetails.pakage_Name

                };
                firebaseHelpdesk.AddItemToListShip(beanItemShip);
                firebaseHelpdesk.DeleteItemToListDashBoard(beanItemDetails);
                FragmentDashBoard fragmentDashBoard = new FragmentDashBoard();
                mainAct.ShowFragment(FragmentManager, fragmentDashBoard, "");
            }
            

        }

        private void initValue()
        {
            edtNamePakage.Enabled = false;
            edtLocation.Enabled = false;
            edtKM.Enabled = false;
            edtMoney.Enabled = false;
            recyclerViewItemchild.Enabled = false;
            if (beanItemDetails != null)
            {
                edtNamePakage.Text = beanItemDetails.pakage_Name;
                edtLocation.Text = beanItemDetails.location;
                edtKM.Text = beanItemDetails.kilomet.ToString();
                edtMoney.Text = beanItemDetails.Money.ToString();
                lstItemChild.AddRange(beanItemDetails.ListItemChild);
                itemChildAdapter = new ItemChildAdapter(lstItemChild);
                recyclerViewItemchild.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewItemchild.NestedScrollingEnabled = false;
                recyclerViewItemchild.SetAdapter(itemChildAdapter);
            }

            if (beanItemDetails1 != null)
            {
                edtNamePakage.Text = beanItemDetails1.pakage_Name;
                edtLocation.Text = beanItemDetails1.location;
                edtKM.Text = beanItemDetails1.kilomet.ToString();
                edtMoney.Text = beanItemDetails1.Money.ToString();
                lstItemChild.AddRange(beanItemDetails1.ListItemChild);
                itemChildAdapter = new ItemChildAdapter(lstItemChild);
                recyclerViewItemchild.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewItemchild.NestedScrollingEnabled = false;
                recyclerViewItemchild.SetAdapter(itemChildAdapter);
                btnAddtoListShip.Text = "Remove to Trash";
                if (beanItemDetails1.TypeSHip == 0)
                {
                    btnAddtoListShip.Visibility = ViewStates.Gone;
                }
                else
                {
                    if(CmmVariable.userType!=CmmVariable.AdminCode)
                        btnAddtoListShip.Visibility = ViewStates.Gone;
                }

            }

        }
        private void BtnbackDetailItem_Click(object sender, EventArgs e)
        {
            if (beanItemDetails1!=null)
            {
                Fragment_ReportList fragment_ReportList = new Fragment_ReportList();
                mainAct.ShowFragment(FragmentManager, fragment_ReportList, "");
            }
            else
            {
                if(isListShip)
                {
                    FragmentListShip fragmentListShip = new FragmentListShip();
                    mainAct.ShowFragment(FragmentManager, fragmentListShip, "");
                }   
                else
                {
                    FragmentDashBoard fragmentDashBoard = new FragmentDashBoard();
                    mainAct.ShowFragment(FragmentManager, fragmentDashBoard, "");
                }    
            }

        }
    }
}