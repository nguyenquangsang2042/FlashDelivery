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
    public class BeanUser
    {
        public string username { get; set; }
        public string passWord { get; set; }
        public int type { get; set; }
        public string fullName { get; set; }
        public int sex { get; set; }
        public string phoneNumber { get; set; }
        public string birthDay { get; set; }
        public string Location { get; set; }
    }
}