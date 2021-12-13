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
    public class FragmentSignInSignUp : Android.App.Fragment
    {
        private MainActivity mainAct;
        private View _rootView;
        private LayoutInflater _inflater;
        private Button _btnRegister, _btnLogin;
        private EditText _edtUser, _edtPass;
        private TextView _tvForgotPW;
        private FirebaseHelpdesk firebaseHelpdesk;
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
        public FragmentSignInSignUp()
        {

        }
        public FragmentSignInSignUp(bool isback)
        {
            this.isback = isback;
        }
        private void InitView()
        {
            _edtUser = _rootView.FindViewById<EditText>(Resource.Id.edtUser);
            _edtPass = _rootView.FindViewById<EditText>(Resource.Id.edtPass);
            _btnLogin = _rootView.FindViewById<Button>(Resource.Id.btnLogin);
            _btnRegister = _rootView.FindViewById<Button>(Resource.Id.btnRegister);
            _tvForgotPW = _rootView.FindViewById<TextView>(Resource.Id.tvForgotPassword);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            mainAct = (MainActivity)this.Activity;
            _inflater = inflater;
            _rootView = inflater.Inflate(Resource.Layout.layout_SignIn_SignUp, null);
            firebaseHelpdesk = new FirebaseHelpdesk();
            InitView();
            _btnRegister.Click += _btnRegister_Click;
            _btnLogin.Click += _btnLogin_Click;
            _tvForgotPW.Click += _tvForgotPW_Click;
            mainAct.lockAndUnlockNavBar(true, "");
            return _rootView;
        }

        private void _tvForgotPW_Click(object sender, EventArgs e)
        {

        }

        private async void _btnLogin_Click(object sender, EventArgs e)
        {
            mainAct.HideKeyboard(_rootView);
            if (_edtUser.Text != "" && _edtPass.Text != "")
            {
                CmmVariable.user = _edtUser.Text;
                CmmVariable.pass = _edtPass.Text;
                List<BeanUser> lstBeanUser = await firebaseHelpdesk.GetAllPersonsAsync();
                lstBeanUser = lstBeanUser.Where(x => x.username == _edtUser.Text && x.passWord == _edtPass.Text).ToList();
                if (lstBeanUser.Count == 0)
                {
                    Toast.MakeText(mainAct.ApplicationContext, "Don't found your account", ToastLength.Long).Show();
                }
                else
                {
                    if (lstBeanUser[0].type == CmmVariable.AdminCode)
                    {
                        CmmVariable.userType = CmmVariable.AdminCode;

                        FragmentAdminCreateItem fragmentAdminCreateItem = new FragmentAdminCreateItem();
                        mainAct.ShowFragment(FragmentManager, fragmentAdminCreateItem, "");
                    }
                    else
                    {
                        CmmVariable.userType = 0;
                        FragmentDashBoard fragmentDashBoard = new FragmentDashBoard();
                        mainAct.ShowFragment(FragmentManager, fragmentDashBoard, "");
                    }

                }

            }
            else
            {
                try
                {

                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(mainAct);
                    alert.SetTitle("Alert");
                    alert.SetMessage("Your user/password incorect");
                    alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                    {
                        _edtPass.Text = "";
                        _edtUser.Text = "";
                        alert.Dispose();
                    });
                    Dialog dialog = alert.Create();
                    dialog.SetCanceledOnTouchOutside(false);
                    dialog.Show();
                }
                catch (Exception ex)
                { }
            }
        }

        private void _btnRegister_Click(object sender, EventArgs e)
        {
            FragmentSignUp fragmentSignUp = new FragmentSignUp();
            mainAct.ShowFragment(FragmentManager, fragmentSignUp, "");
        }


    }
}