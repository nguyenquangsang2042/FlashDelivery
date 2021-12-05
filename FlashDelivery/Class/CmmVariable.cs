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

namespace FlashDelivery.Class
{
    public class CmmVariable
    {
        public static string URL_Firebase = "https://xamarinfashdeli-default-rtdb.firebaseio.com/";
        public static int AdminCode = 123;
        public static string user { get; set; }
        public static string pass { get; set; }
        public static string id_firebae { get; set; }

    }
}