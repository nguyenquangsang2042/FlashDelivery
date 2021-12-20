package crc649a572e598068d0a7;


public class Fragment_Profile
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onAttach:(Landroid/app/Activity;)V:GetOnAttach_Landroid_app_Activity_Handler\n" +
			"n_onDetach:()V:GetOnDetachHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FlashDelivery.Present.Fragment.Fragment_Profile, FlashDelivery", Fragment_Profile.class, __md_methods);
	}


	public Fragment_Profile ()
	{
		super ();
		if (getClass () == Fragment_Profile.class)
			mono.android.TypeManager.Activate ("FlashDelivery.Present.Fragment.Fragment_Profile, FlashDelivery", "", this, new java.lang.Object[] {  });
	}

	public Fragment_Profile (boolean p0)
	{
		super ();
		if (getClass () == Fragment_Profile.class)
			mono.android.TypeManager.Activate ("FlashDelivery.Present.Fragment.Fragment_Profile, FlashDelivery", "System.Boolean, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onAttach (android.app.Activity p0)
	{
		n_onAttach (p0);
	}

	private native void n_onAttach (android.app.Activity p0);


	public void onDetach ()
	{
		n_onDetach ();
	}

	private native void n_onDetach ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
