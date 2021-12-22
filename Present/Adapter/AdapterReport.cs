using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FlashDelivery;
using FlashDelivery.Class.Bean;
using FlashDelivery.Present.Fragment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlashDelivery.Present.Adapter
{
    [Activity(Label = "AdapterReport")]
    class AdapterReport : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private Context context;
        DashBoardViewHolder vh;
        private bool isListShip;
        private MainActivity mainAct;
        private List<BeanReport> itemchild;
        public AdapterReport(MainActivity mainAct, List<BeanReport> itemchild, bool isListShip = false)
        {
            this.itemchild = itemchild;
            this.mainAct = mainAct;
            this.isListShip = isListShip;
        }
        public override int ItemCount
        {
            get
            {
                if (itemchild != null)
                {
                    return itemchild.Count;

                }
                else return 0;
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            vh = holder as DashBoardViewHolder;
            vh.beanItemDetails = itemchild[position];
            vh.NamePackage.Text = itemchild[position].pakage_Name;
            vh.Money.Text = itemchild[position].Money.ToString();
            vh.KM.Text = itemchild[position].kilomet.ToString();
            vh.Loaction.Text = itemchild[position].location;
            if (position % 2 != 0)
            {
                vh.linearLayoutDashBoard.SetBackgroundColor(Color.ParseColor("#d4d5d6"));
            }
            vh.isListShip = isListShip;
            vh.mainAct = mainAct;

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
            Inflate(Resource.Layout.layout_ItemDashBoard, parent, false);
            DashBoardViewHolder notifyViewHolder = new DashBoardViewHolder(itemView);
            return notifyViewHolder;
        }

        class DashBoardViewHolder : RecyclerView.ViewHolder
        {
            //public TextView tv_pilot_name1 { get; private set; }


            public MainActivity mainAct { get; set; }
            public TextView NamePackage { get; set; }
            public TextView Loaction { get; set; }
            public TextView Money { get; set; }
            public TextView KM { get; set; }
            public LinearLayout linearLayoutDashBoard { get; set; }
            public BeanReport beanItemDetails { get; set; }
            public bool isListShip { get; set; }

            public DashBoardViewHolder(View itemView) : base(itemView)
            {

                NamePackage = itemView.FindViewById<TextView>(Resource.Id.tv_NamePakehe_DB);
                Loaction = itemView.FindViewById<TextView>(Resource.Id.tv_LocationDB);
                Money = itemView.FindViewById<TextView>(Resource.Id.tv_MoneyDB);
                KM = itemView.FindViewById<TextView>(Resource.Id.tvKMDB);
                linearLayoutDashBoard = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayoutDashBoard);

                linearLayoutDashBoard.Click += LinearLayoutDashBoard_Click;






            }

            private void LinearLayoutDashBoard_Click(object sender, EventArgs e)
            {
               
                    Fragment_DetailItem fragment_DetailItem = new Fragment_DetailItem(beanItemDetails, isListShip);
                    mainAct.ShowFragment(mainAct.FragmentManager, fragment_DetailItem, "");
                
            }


        }
    }

}