
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Inject.Activities;
using Fragment = Android.Support.V4.App.Fragment;

namespace Inject.Fragments
{
  public class HomeFragment : Fragment
  {

    private CardView cardView;
    private CardView fingerPrint;

    public static HomeFragment Newinstance()
    {
      return new HomeFragment();
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your fragment here
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      // Use this to return your custom view for this Fragment
       return inflater.Inflate(Resource.Layout.HomeLayout, container, false);
    }

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
      cardView = view.FindViewById<CardView>(Resource.Id.MapCardView);
      fingerPrint = view.FindViewById<CardView>(Resource.Id.FingerPrintCardView);

      cardView.Click += CardView_Click;
      fingerPrint.Click += FingerPrint_Click;
		}

    void CardView_Click(object sender, EventArgs e)
    {
      var intent = MapActivity.NewIntent(Activity);
      StartActivity(intent);
    }

    void FingerPrint_Click(object sender, EventArgs e)
    {
      var intent = FingerPrintActivity.NewInstance(Activity);
      StartActivity(intent);
    }

	}
}
