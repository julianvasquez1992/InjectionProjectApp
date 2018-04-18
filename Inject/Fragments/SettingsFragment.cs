
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
using Inject.Adapters;
using Inject.Test.Share.Entities;
using Square.Picasso;
using Xamarin.Auth;
using Fragment = Android.Support.V4.App.Fragment;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Inject.Fragments
{
  public class SettingsFragment : Fragment
  {

    private Toolbar toolbar;
    private RecyclerView settingsRecyclerView;
    private SettingsAdapter settingsAdapter;
    private Picasso picasso;
    private LinearLayoutManager layoutManager;
    private Account account;

    public static SettingsFragment Newinstance()
    {
      return new SettingsFragment();
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      // Create your fragment here
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      // Use this to return your custom view for this Fragment
       return inflater.Inflate(Resource.Layout.SettingsLayout, container, false);
    }

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);

      picasso = Picasso.With(Activity);
      account = AccountStore.Create().FindAccountsForService(nameof(LoginActivity)).FirstOrDefault();

      toolbar = view.FindViewById<Toolbar>(Resource.Id.SettingsToolbar);
      settingsRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.SettingsRecyclerView);
      toolbar.Title = $"User: {account.Username}";

      layoutManager = new LinearLayoutManager(Activity, LinearLayoutManager.Vertical, false);
      settingsRecyclerView.SetLayoutManager(layoutManager);

      settingsAdapter = new SettingsAdapter(Activity, picasso);
      settingsRecyclerView.SetAdapter(settingsAdapter);

      settingsAdapter.SettingSelected += SettingSelected;

      var newList = new List<SettingEntity>
      {
        new SettingEntity() { IconSetting = Resource.Drawable.lock_black_48dp, TextSetting = "Logout main user" }

      };

      settingsAdapter.AddSettings(newList);
		}

    private void SettingSelected(object sender, SettingEntity e)
    {
      AccountStore.Create().Delete(account, nameof(LoginActivity));
      Activity.Finish();
    }
	}
}
