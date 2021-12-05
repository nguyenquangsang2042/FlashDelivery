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
    public class FragmentListShip : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private RecyclerView recyclerViewDashBoard;
        private List<BeanItemDetails> lstBeanItemDetail = new List<BeanItemDetails>();
        private FirebaseHelpdesk firebaseHelpdesk = new FirebaseHelpdesk();
        private DashBoardAdapter dashBoardAdapter;
        private RadioButton radioMoney, radioKM;
        private ImageButton _btnGotoListShip;
        private TextView textViewTitle;
        
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
            _rootView = inflater.Inflate(Resource.Layout.layout_dashboard, null);
            recyclerViewDashBoard = _rootView.FindViewById<RecyclerView>(Resource.Id.recyclerViewDashBoard);
            radioMoney = _rootView.FindViewById<RadioButton>(Resource.Id.radioMoneyDB);
            radioKM = _rootView.FindViewById<RadioButton>(Resource.Id.radioKMDB);
            _btnGotoListShip = _rootView.FindViewById<ImageButton>(Resource.Id.btnGotoListShip);
            _btnGotoListShip.Visibility = ViewStates.Gone;
            textViewTitle = _rootView.FindViewById<TextView>(Resource.Id.textViewTitle);
            textViewTitle.Text = "LIST SHIP";
            initValue();
            
            radioMoney.Click += RadioMoney_Click;
            radioMoney.Checked = true;
            radioKM.Click += RadioKM_Click;
            return _rootView;
        }

        

        private void RadioMoney_Click(object sender, EventArgs e)
        {
            if (lstBeanItemDetail.Count != 0 && lstBeanItemDetail != null)
            {

                lstBeanItemDetail = lstBeanItemDetail.OrderByDescending(x => x.Money).ToList();
                dashBoardAdapter = new DashBoardAdapter(mainAct, lstBeanItemDetail,true);
                recyclerViewDashBoard.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewDashBoard.NestedScrollingEnabled = false;
                recyclerViewDashBoard.SetAdapter(dashBoardAdapter);
            }
        }

        private void RadioKM_Click(object sender, EventArgs e)
        {
            if (lstBeanItemDetail.Count != 0 && lstBeanItemDetail != null)
            {

                lstBeanItemDetail = lstBeanItemDetail.OrderBy(x => x.kilomet).ToList();
                dashBoardAdapter = new DashBoardAdapter(mainAct, lstBeanItemDetail,true);
                recyclerViewDashBoard.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewDashBoard.NestedScrollingEnabled = false;
                recyclerViewDashBoard.SetAdapter(dashBoardAdapter);
            }
        }

        private async void initValue()
        {

            lstBeanItemDetail = await firebaseHelpdesk.GetAllBeanListShip();
            lstBeanItemDetail = await firebaseHelpdesk.GetAllBeanListShip();
            if (lstBeanItemDetail.Count != 0 && lstBeanItemDetail != null)
            {
                lstBeanItemDetail = lstBeanItemDetail.Where(x => x.user == CmmVariable.user && x.pass == CmmVariable.pass).ToList();
                lstBeanItemDetail = lstBeanItemDetail.OrderByDescending(x => x.Money).ToList();
                dashBoardAdapter = new DashBoardAdapter(mainAct, lstBeanItemDetail,true);
                recyclerViewDashBoard.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewDashBoard.NestedScrollingEnabled = false;
                recyclerViewDashBoard.SetAdapter(dashBoardAdapter);
            }



        }
    }
}
