package crc64e602ad2e5aec8cac;


public class ItemChildAdapter_ItemChildViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FlashDelivery.Present.Adapter.ItemChildAdapter+ItemChildViewHolder, FlashDelivery", ItemChildAdapter_ItemChildViewHolder.class, __md_methods);
	}


	public ItemChildAdapter_ItemChildViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ItemChildAdapter_ItemChildViewHolder.class)
			mono.android.TypeManager.Activate ("FlashDelivery.Present.Adapter.ItemChildAdapter+ItemChildViewHolder, FlashDelivery", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
