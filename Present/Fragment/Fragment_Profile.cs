
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FlashDelivery.Class;

namespace FlashDelivery.Present.Fragment
{
    public class Fragment_Profile : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private Button _btnRegister, _btnLogin;
        private EditText _edtUser, _edtPass;
        private TextView _tvForgotPW;
        private FirebaseHelpdesk firebaseHelpdesk;
        private TextView tvFullname;
        private TextView tvUsername;
        private TextView tvTypeAccoumt;
        private TextView tv_sex;
        private TextView tvBirthday;
        private TextView tv_location;
        private TextView tv_numberphone;
        bool isback = false;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override void OnAttach(Activity activity)
        {
            base.OnAttach(activity);

        }
        public override void OnDetach()
        {
            base.OnDetach();

        }
        public override void OnResume()
        {
            base.OnResume();

        }
        public Fragment_Profile()
        {

        }
        public Fragment_Profile(bool isback)
        {
            this.isback = isback;
        }
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            mainAct = (MainActivity)this.Activity;
            _inflater = inflater;
            _rootView = inflater.Inflate(Resource.Layout.layout_profile, null);           
            return _rootView;
        }

        

    }
}
