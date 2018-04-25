package md5ec05146fe5d8d808dfe4e01e77053df8;


public class MainActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.support.v4.app.LoaderManager.LoaderCallbacks
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateLoader:(ILandroid/os/Bundle;)Landroid/support/v4/content/Loader;:GetOnCreateLoader_ILandroid_os_Bundle_Handler:Android.Support.V4.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.Android.Support.Fragment\n" +
			"n_onLoadFinished:(Landroid/support/v4/content/Loader;Ljava/lang/Object;)V:GetOnLoadFinished_Landroid_support_v4_content_Loader_Ljava_lang_Object_Handler:Android.Support.V4.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.Android.Support.Fragment\n" +
			"n_onLoaderReset:(Landroid/support/v4/content/Loader;)V:GetOnLoaderReset_Landroid_support_v4_content_Loader_Handler:Android.Support.V4.App.LoaderManager/ILoaderCallbacksInvoker, Xamarin.Android.Support.Fragment\n" +
			"";
		mono.android.Runtime.register ("Inject.Activities.MainActivity, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity ()
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("Inject.Activities.MainActivity, Inject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.support.v4.content.Loader onCreateLoader (int p0, android.os.Bundle p1)
	{
		return n_onCreateLoader (p0, p1);
	}

	private native android.support.v4.content.Loader n_onCreateLoader (int p0, android.os.Bundle p1);


	public void onLoadFinished (android.support.v4.content.Loader p0, java.lang.Object p1)
	{
		n_onLoadFinished (p0, p1);
	}

	private native void n_onLoadFinished (android.support.v4.content.Loader p0, java.lang.Object p1);


	public void onLoaderReset (android.support.v4.content.Loader p0)
	{
		n_onLoaderReset (p0);
	}

	private native void n_onLoaderReset (android.support.v4.content.Loader p0);

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
