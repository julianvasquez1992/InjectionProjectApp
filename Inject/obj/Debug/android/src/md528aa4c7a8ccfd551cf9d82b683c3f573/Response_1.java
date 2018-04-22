package md528aa4c7a8ccfd551cf9d82b683c3f573;


public class Response_1
	extends md528aa4c7a8ccfd551cf9d82b683c3f573.LoaderResponse_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Inject.Loaders.Response`1, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Response_1.class, __md_methods);
	}


	public Response_1 ()
	{
		super ();
		if (getClass () == Response_1.class)
			mono.android.TypeManager.Activate ("Inject.Loaders.Response`1, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Response_1 (java.lang.Exception p0)
	{
		super ();
		if (getClass () == Response_1.class)
			mono.android.TypeManager.Activate ("Inject.Loaders.Response`1, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.Exception, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
