
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FlashDelivery.Class;
using FlashDelivery.Class.Bean;
using FlashDelivery.Present.Adapter;
using Microcharts;
using Microcharts.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlashDelivery.Present.Fragment
{
    [Obsolete]
    public class Fragment_ReportList : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private RecyclerView recyclerViewDashBoard;
        private List<BeanReport> lstBeanItemDetail = new List<BeanReport>();
        private FirebaseHelpdesk firebaseHelpdesk = new FirebaseHelpdesk();
        private AdapterReport dashBoardAdapter;
        private RadioButton radioMoney, radioKM;
        private ImageButton _btnGotoListShip;
        private AndroidX.AppCompat.Widget.Toolbar btnLeftMenu;
        private DrawerLayout drawerLayout;
        private NavigationView navigationView;
        private ChartView my_chart_report;
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
            _rootView = inflater.Inflate(Resource.Layout.Layout_ReportlistForShipper, null);
            recyclerViewDashBoard = _rootView.FindViewById<RecyclerView>(Resource.Id.recyclerViewDashBoard);
            radioMoney = _rootView.FindViewById<RadioButton>(Resource.Id.radioMoneyDB);
            radioKM = _rootView.FindViewById<RadioButton>(Resource.Id.radioKMDB);
            _btnGotoListShip = _rootView.FindViewById<ImageButton>(Resource.Id.btnGotoListShip);
            my_chart_report = _rootView.FindViewById<ChartView>(Resource.Id.chartView1);
            initValue();
            _btnGotoListShip.Click += _btnGotoListShip_Click;
            radioMoney.Click += RadioMoney_Click;
            radioMoney.Checked = true;
            radioKM.Click += RadioKM_Click;
            mainAct.lockAndUnlockNavBar(false, "REPORT");
            return _rootView;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        private void _btnGotoListShip_Click(object sender, EventArgs e)
        {
            FragmentListShip fragmentListShip = new FragmentListShip();
            mainAct.ShowFragment(mainAct.FragmentManager, fragmentListShip, "");
        }

        private void RadioMoney_Click(object sender, EventArgs e)
        {
            if (lstBeanItemDetail.Count != 0 && lstBeanItemDetail != null)
            {

                lstBeanItemDetail = lstBeanItemDetail.OrderByDescending(x => x.Money).ToList();
                dashBoardAdapter = new AdapterReport(mainAct, lstBeanItemDetail);
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
                dashBoardAdapter = new AdapterReport(mainAct, lstBeanItemDetail);
                recyclerViewDashBoard.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewDashBoard.NestedScrollingEnabled = false;
                recyclerViewDashBoard.SetAdapter(dashBoardAdapter);
            }
        }

        private async void initValue()
        {

            lstBeanItemDetail = await firebaseHelpdesk.GetAllListReport();
            lstBeanItemDetail = await firebaseHelpdesk.GetAllListReport();
            if (CmmVariable.userType == CmmVariable.AdminCode)
            {

            }
            else
            {
                lstBeanItemDetail = lstBeanItemDetail.Where(x => x.user == CmmVariable.user && x.TypeSHip!=2).ToList();
            }
            if (lstBeanItemDetail.Count != 0 && lstBeanItemDetail != null)
            {

                lstBeanItemDetail = lstBeanItemDetail.OrderByDescending(x => x.Money).ToList();
                dashBoardAdapter = new AdapterReport(mainAct, lstBeanItemDetail);
                recyclerViewDashBoard.SetLayoutManager(new LinearLayoutManager(_rootView.Context));
                recyclerViewDashBoard.NestedScrollingEnabled = false;
                recyclerViewDashBoard.SetAdapter(dashBoardAdapter);
            }
            var countSuccec = lstBeanItemDetail.Where(x => x.TypeSHip == 1).Count();
            var counterror = lstBeanItemDetail.Where(x => x.TypeSHip != 1 && x.TypeSHip != 2).Count();
            var count_return = lstBeanItemDetail.Where(x => x.TypeSHip == 2).Count();
            if (CmmVariable.userType == CmmVariable.AdminCode)
            {
                var entries = new[]
            { new ChartEntry(counterror)
                 {
                     Label = "Fails",
                     ValueLabel = counterror.ToString(),
                     Color=SkiaSharp.SKColor.Parse("#e03143"),
                     ValueLabelColor=SkiaSharp.SKColor.Parse("#e03143"),

                 },
                 new ChartEntry(countSuccec)
                 {
                     Label = "Success",
                     ValueLabel = countSuccec.ToString(),
                     Color=SkiaSharp.SKColor.Parse("#3254a8"),
                     ValueLabelColor=SkiaSharp.SKColor.Parse("#3254a8")
                 },
                 new ChartEntry(countSuccec)
                 {
                     Label = "Return for Customer",
                     ValueLabel = count_return.ToString(),
                     Color=SkiaSharp.SKColor.Parse("#56fc03"),
                     ValueLabelColor=SkiaSharp.SKColor.Parse("#56fc03")
                 },
                 };
                var chart = new DonutChart() { Entries = entries };

                my_chart_report.Chart = chart;
            }
            else
            {
                var entries = new[]
            { new ChartEntry(counterror)
                 {
                     Label = "Fails",
                     ValueLabel = counterror.ToString(),
                     Color=SkiaSharp.SKColor.Parse("#e03143"),
                     ValueLabelColor=SkiaSharp.SKColor.Parse("#e03143"),

                 },
                 new ChartEntry(countSuccec)
                 {
                     Label = "Success",
                     ValueLabel = countSuccec.ToString(),
                     Color=SkiaSharp.SKColor.Parse("#3254a8"),
                     ValueLabelColor=SkiaSharp.SKColor.Parse("#3254a8")
                 },
            };
                var chart = new DonutChart() { Entries = entries };

                my_chart_report.Chart = chart;
            }
            my_chart_report.Chart.LabelTextSize = 30;


        }
    }
}
