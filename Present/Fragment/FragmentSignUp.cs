using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FlashDelivery.Class;
using FlashDelivery.Class.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashDelivery.Present.Fragment
{
    public class FragmentSignUp : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private ImageView btnBack;
        private EditText _edtUser_SU;
        private EditText _edtPass_SU;
        private EditText _edtNumType_SU;
        private EditText _edtNName_SU;
        private RadioButton rdMale, rdFemale;
        private EditText _edtPhone_SU;
        private EditText _edtBirthDay_SU;
        private EditText _edtLocation_SU;
        private Button _btnRegister_SU;
        private BeanUser beanUser;
        private FirebaseHelpdesk firebaseHelpdesk;
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
            _rootView = inflater.Inflate(Resource.Layout.layout_SignUp, null);
            InitFindbyID();
            firebaseHelpdesk = new FirebaseHelpdesk();
            #region Event
            InitdatatoSent();
            _btnRegister_SU.Click += _btnRegister_SU_Click;
            #endregion
            return _rootView;
        }

        private async void _btnRegister_SU_Click(object sender, EventArgs e)
        {        
            if (string.IsNullOrEmpty(_edtUser_SU.Text) || string.IsNullOrEmpty(_edtPass_SU.Text) 
                || string.IsNullOrEmpty(_edtNumType_SU.Text) || string.IsNullOrEmpty(_edtNName_SU.Text)||
                string.IsNullOrEmpty(_edtPhone_SU.Text) || string.IsNullOrEmpty(_edtBirthDay_SU.Text)
                || string.IsNullOrEmpty(_edtLocation_SU.Text))
            {
                Toast.MakeText(mainAct.ApplicationContext, "Please type all info", ToastLength.Long).Show();
            }
            else
            {
                List<BeanUser> lstBeanUser = await firebaseHelpdesk.GetAllPersonsAsync();
                lstBeanUser = lstBeanUser.Where(x => x.username == _edtUser_SU.Text && x.passWord == _edtPass_SU.Text).ToList();
                if(lstBeanUser.Count!=0)
                {
                    Toast.MakeText(mainAct.ApplicationContext, " Account Exit ", ToastLength.Long).Show();
                }
                else
                {
                    beanUser = new BeanUser
                    {
                        username = _edtUser_SU.Text,
                        Location = _edtLocation_SU.Text,
                        birthDay = _edtBirthDay_SU.Text,
                        fullName = _edtNName_SU.Text,
                        passWord = _edtPass_SU.Text,
                        phoneNumber = _edtPhone_SU.Text,
                        type = Convert.ToInt32(_edtNumType_SU.Text)
                    };
                    if (rdMale.Checked)
                    {
                        beanUser.sex = 1;
                    }
                    if (rdFemale.Checked)
                    {
                        beanUser.sex = 2;
                    }
                    firebaseHelpdesk.RegisterUser(beanUser);
                }
                
            }
        }

        private void InitdatatoSent()
        {
            _edtUser_SU.Text = "1";
            _edtPass_SU.Text = "1";
            _edtNumType_SU.Text = "1";
            _edtNName_SU.Text = "1";
            _edtPhone_SU.Text = "1";
            _edtBirthDay_SU.Text = "1";
            _edtLocation_SU.Text = "1";
            rdMale.Checked = true;
        }
        private void InitFindbyID()
        {
            btnBack = _rootView.FindViewById<ImageView>(Resource.Id.btnBack);
            _edtUser_SU = _rootView.FindViewById<EditText>(Resource.Id.edtUser_SU);
            _edtPass_SU = _rootView.FindViewById<EditText>(Resource.Id.edtPass_SU);
            _edtNumType_SU = _rootView.FindViewById<EditText>(Resource.Id.edtNumType_SU);
            _edtNName_SU = _rootView.FindViewById<EditText>(Resource.Id.edtName_SU);
            _edtPhone_SU = _rootView.FindViewById<EditText>(Resource.Id.edtPhone_SU);
            _edtBirthDay_SU = _rootView.FindViewById<EditText>(Resource.Id.edtBirthDay_SU);
            _edtLocation_SU = _rootView.FindViewById<EditText>(Resource.Id.edtLocation_SU);
            rdMale = _rootView.FindViewById<RadioButton>(Resource.Id.rdMale);
            rdFemale = _rootView.FindViewById<RadioButton>(Resource.Id.rdFemale);
            _btnRegister_SU = _rootView.FindViewById<Button>(Resource.Id.btnRegisterSU);

        }
    }
}