package md564ec56a5668a23d83b73cca5407aee50;


public class SettingViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Inject.ViewHolders.SettingViewHolder, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SettingViewHolder.class, __md_methods);
	}


	public SettingViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == SettingViewHolder.class)
			mono.android.TypeManager.Activate ("Inject.ViewHolders.SettingViewHolder, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
