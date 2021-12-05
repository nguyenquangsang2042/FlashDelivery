package crc64e602ad2e5aec8cac;


public class DashBoardAdapter_DashBoardViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FlashDelivery.Present.Adapter.DashBoardAdapter+DashBoardViewHolder, FlashDelivery", DashBoardAdapter_DashBoardViewHolder.class, __md_methods);
	}


	public DashBoardAdapter_DashBoardViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == DashBoardAdapter_DashBoardViewHolder.class)
			mono.android.TypeManager.Activate ("FlashDelivery.Present.Adapter.DashBoardAdapter+DashBoardViewHolder, FlashDelivery", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
