using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FlashDelivery;
using FlashDelivery.Class.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlashDelivery.Present.Adapter
{
    [Activity(Label = "ItemChildAdapter")]
    class ItemChildAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private Context context;
        ItemChildViewHolder vh;

        private MainActivity mainAct;
        private List<ItemChild> itemchild;
        public ItemChildAdapter(List<ItemChild> itemchild)
        {
            this.itemchild = itemchild;
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
            vh = holder as ItemChildViewHolder;
            vh.Num.Text = itemchild[position].Count_Item.ToString();
            vh.Detail.Text = itemchild[position].Details.ToString();
            


        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
            Inflate(Resource.Layout.layout_childItem, parent, false);
            ItemChildViewHolder notifyViewHolder = new ItemChildViewHolder(itemView);
            return notifyViewHolder;
        }

        class ItemChildViewHolder : RecyclerView.ViewHolder
        {
            //public TextView tv_pilot_name1 { get; private set; }
            
       
            public MainActivity mainAct;
            public TextView Detail { get; set; }
            public TextView Num { get; set; }
           
            public ItemChildViewHolder(View itemView) : base(itemView)
            {

                Num = itemView.FindViewById<TextView>(Resource.Id.tv_CountChild);
                Detail = itemView.FindViewById<TextView>(Resource.Id.tv_DetailChild);


                




            }


            
            
        }
    }

}