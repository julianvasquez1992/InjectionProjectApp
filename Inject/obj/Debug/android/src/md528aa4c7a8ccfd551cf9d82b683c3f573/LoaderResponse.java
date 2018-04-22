package md528aa4c7a8ccfd551cf9d82b683c3f573;


public class LoaderResponse
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Inject.Loaders.LoaderResponse, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoaderResponse.class, __md_methods);
	}


	public LoaderResponse ()
	{
		super ();
		if (getClass () == LoaderResponse.class)
			mono.android.TypeManager.Activate ("Inject.Loaders.LoaderResponse, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public LoaderResponse (java.lang.Exception p0)
	{
		super ();
		if (getClass () == LoaderResponse.class)
			mono.android.TypeManager.Activate ("Inject.Loaders.LoaderResponse, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.Exception, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
