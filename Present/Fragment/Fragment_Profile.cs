
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
            tvFullname = _rootView.FindViewById<TextView>(Resource.Id.tvFullName);
            tvUsername = _rootView.FindViewById<TextView>(Resource.Id.tvUserAccout);
            tvTypeAccoumt = _rootView.FindViewById<TextView>(Resource.Id.TvTYpe);
            tv_sex = _rootView.FindViewById<TextView>(Resource.Id.tvSex);
            tvBirthday = _rootView.FindViewById<TextView>(Resource.Id.tvBirthday);
            tv_location = _rootView.FindViewById<TextView>(Resource.Id.tvLocation);
            tv_numberphone = _rootView.FindViewById<TextView>(Resource.Id.tvPhonenumber);
            initValue();
            return _rootView;
        }

        private void initValue()
        {
            if(CmmVariable.fullname!=null)
            {
                tvFullname.Text = CmmVariable.fullname;
            }
            else { tvFullname.Text = "None"; }
            if (CmmVariable.user != null)
            {
                tvUsername.Text = "Account Name: " + CmmVariable.user;
            }
            else { tvUsername.Text = "None"; }
            if (CmmVariable.userType != 0)
            {
                if (CmmVariable.userType == CmmVariable.AdminCode)
                    tvTypeAccoumt.Text = "Account type: Admin";
                else
                {
                    tvTypeAccoumt.Text = "Account type: Shipper";
                }
            }
            else { tvTypeAccoumt.Text = "None"; }
            if (CmmVariable.sex != 0)
            {
                if (CmmVariable.sex == 1)
                    tv_sex.Text = "Sex: Male";
                else
                    tv_sex.Text = "Sex: Femela";
            }
            else { tv_sex.Text = "None"; }

            if (CmmVariable.birthday != null)
            {
                tvBirthday.Text = "BirthDay :" + CmmVariable.birthday;

            }
            else { tvBirthday.Text = "None"; }
           
            
            if (CmmVariable.location != null)
            {
                tv_location.Text = "Location: " + CmmVariable.location;
            }
            else { tv_location.Text = "None"; }
            if (CmmVariable.phoneNumber != null)
            {
                tv_numberphone.Text = "Phone Number: " + CmmVariable.phoneNumber;
            }
            else { tv_numberphone.Text = "None"; }

          
        }
    }
}
