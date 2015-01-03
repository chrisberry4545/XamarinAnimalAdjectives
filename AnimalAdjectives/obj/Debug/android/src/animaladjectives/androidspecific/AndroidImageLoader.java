package animaladjectives.androidspecific;


public class AndroidImageLoader
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AnimalAdjectives.AndroidSpecific.AndroidImageLoader, AnimalAdjectives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AndroidImageLoader.class, __md_methods);
	}


	public AndroidImageLoader () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AndroidImageLoader.class)
			mono.android.TypeManager.Activate ("AnimalAdjectives.AndroidSpecific.AndroidImageLoader, AnimalAdjectives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public AndroidImageLoader (android.widget.ImageView p0, android.view.View p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == AndroidImageLoader.class)
			mono.android.TypeManager.Activate ("AnimalAdjectives.AndroidSpecific.AndroidImageLoader, AnimalAdjectives, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Widget.ImageView, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

	java.util.ArrayList refList;
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
