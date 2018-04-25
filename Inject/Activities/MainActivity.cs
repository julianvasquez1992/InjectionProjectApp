
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Inject.Test.Share.Container;
using Inject.Test.Share.Interfaces;
using Unity.Attributes;
using BottomNavigationBar;
using Unity;
using BottomNavigationBar.Listeners;
using Inject.Fragments;
using Xamarin.Auth;
using ILoaderCallbacks = Android.Support.V4.App.LoaderManager.ILoaderCallbacks;
using Inject.Loaders;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Java.Lang;
using Inject.Utitlities;
using Inject.Test.Share.Entities;

namespace Inject.Activities
{
  [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
           AlwaysRetainTaskState = true)]
  public class MainActivity : AppCompatActivity, IOnMenuTabClickListener, ILoaderCallbacks
  {
    [Dependency]
    public ILogin Login { get; set; }

    private BottomBar bottomBar;
    private HomeFragment homeFragment;
    private HelpFragment helpFragment;
    private SettingsFragment settingsFragment;
    private BeaconsFragment beaconsFragment;
    private Fragments.ListFragment listFragment;

    private enum Loaders
    {
      ListLoader
    }

    public static Intent NewIntent(Context caller)
    {
      if (caller == null)
        throw new ArgumentNullException(nameof(caller));

      return new Intent(caller, typeof(MainActivity));
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.MainLayout);

      homeFragment = HomeFragment.Newinstance();
      helpFragment = HelpFragment.Newinstance();
      beaconsFragment = BeaconsFragment.Newinstance();
      settingsFragment = SettingsFragment.Newinstance();
      listFragment = Fragments.ListFragment.NewInstance();

      Login = ContainerClass.Container.Resolve<ILogin>();

      SupportFragmentManager
        .BeginTransaction()
        .Add(Resource.Id.FragmentContainer, homeFragment)
        .Commit();

      bottomBar = BottomBar.Attach(this, savedInstanceState);
      bottomBar.SetItems(Resource.Menu.MenuBottomDesing);
      bottomBar.SetOnMenuTabClickListener(this);
      bottomBar.MapColorForTab(0, Android.Graphics.Color.ParseColor("#143A5E"));
      bottomBar.MapColorForTab(1, Android.Graphics.Color.ParseColor("#143A5E"));
      bottomBar.MapColorForTab(2, Android.Graphics.Color.ParseColor("#143A5E"));
      bottomBar.MapColorForTab(3, Android.Graphics.Color.ParseColor("#143A5E"));

      //SupportLoaderManager.InitLoader((int)Loaders.ListLoader, null, this).ForceLoad();
      SupportLoaderManager.InitLoader((int)Loaders.ListLoader, null, this);
    }

		public void OnMenuTabSelected(int menuItemId)
    {
      switch (menuItemId)
      {
        case Resource.Id.StartButtom:
          SupportFragmentManager
            .BeginTransaction()
            .Replace(Resource.Id.FragmentContainer, homeFragment)
            .Commit();
          break;

        case Resource.Id.ListButton:
          SupportFragmentManager
            .BeginTransaction()
            .Replace(Resource.Id.FragmentContainer, listFragment)
            .Commit();
          break;

        case Resource.Id.ConnectBeaconsButton:

          break;

        case Resource.Id.SettingsButton:
          SupportFragmentManager
            .BeginTransaction()
            .Replace(Resource.Id.FragmentContainer, settingsFragment)
            .Commit();
          break;

        default:
          break;
      }
    }

    public void OnMenuTabReSelected(int menuItemId)
    {
      //throw new NotImplementedException();
    }

    Android.Support.V4.Content.Loader ILoaderCallbacks.OnCreateLoader(int id, Bundle args)
    {
      switch (id)
      {
        case (int)Loaders.ListLoader:
          return new ListLoader(this);
      }

      throw new NotImplementedException();
    }


    public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
    {
      //var response = (LoaderResponse<IEnumerable<ExampleEntities>>)data;
    }

    public void OnLoaderReset(Android.Support.V4.Content.Loader loader)
    {
      
    }
  }
}
