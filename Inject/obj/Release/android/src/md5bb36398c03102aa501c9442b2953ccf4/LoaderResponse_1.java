package md5bb36398c03102aa501c9442b2953ccf4;


public class LoaderResponse_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Inject.Utitlities.LoaderResponse`1, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoaderResponse_1.class, __md_methods);
	}


	public LoaderResponse_1 ()
	{
		super ();
		if (getClass () == LoaderResponse_1.class)
			mono.android.TypeManager.Activate ("Inject.Utitlities.LoaderResponse`1, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
