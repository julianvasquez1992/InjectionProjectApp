package md5ec05146fe5d8d808dfe4e01e77053df8;


public class FingerPrintActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Inject.Activities.FingerPrintActivity, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FingerPrintActivity.class, __md_methods);
	}


	public FingerPrintActivity ()
	{
		super ();
		if (getClass () == FingerPrintActivity.class)
			mono.android.TypeManager.Activate ("Inject.Activities.FingerPrintActivity, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
