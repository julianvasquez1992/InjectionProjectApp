package md528aa4c7a8ccfd551cf9d82b683c3f573;


public class ListLoader
	extends android.support.v4.content.AsyncTaskLoader
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_loadInBackground:()Ljava/lang/Object;:GetLoadInBackgroundHandler\n" +
			"";
		mono.android.Runtime.register ("Inject.Loaders.ListLoader, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListLoader.class, __md_methods);
	}


	public ListLoader (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ListLoader.class)
			mono.android.TypeManager.Activate ("Inject.Loaders.ListLoader, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object loadInBackground ()
	{
		return n_loadInBackground ();
	}

	private native java.lang.Object n_loadInBackground ();

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
