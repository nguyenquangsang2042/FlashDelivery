package crc64e602ad2e5aec8cac;


public class AdapterItemChildViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FlashDelivery.Present.Adapter.AdapterItemChildViewHolder, FlashDelivery", AdapterItemChildViewHolder.class, __md_methods);
	}


	public AdapterItemChildViewHolder ()
	{
		super ();
		if (getClass () == AdapterItemChildViewHolder.class)
			mono.android.TypeManager.Activate ("FlashDelivery.Present.Adapter.AdapterItemChildViewHolder, FlashDelivery", "", this, new java.lang.Object[] {  });
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
