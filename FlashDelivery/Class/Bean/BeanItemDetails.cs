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

namespace FlashDelivery.Class.Bean
{
    public class BeanItemDetails
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string key { get; set; }
        public string pakage_Name { get; set; }
        public string location { get; set; }
        public int kilomet { get; set; }
        public int Money { get; set; }
        public List<ItemChild> ListItemChild { get; set; }
    }
}