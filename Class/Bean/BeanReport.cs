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
    public class BeanReport
    {
        public string key { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string pakage_Name { get; set; }
        public string location { get; set; }
        public int kilomet { get; set; }
        public int Money { get; set; }
        public List<ItemChild> ListItemChild { get; set; }
        public DateTime DateTime { get; set; }
        public int TypeSHip { get; set; } //=>1 erro , 0 thanh cong
        public string DetailReport { get; set; }
    }
}