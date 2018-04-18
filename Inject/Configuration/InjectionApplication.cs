using System;
using AltBeaconOrg.BoundBeacon;
using AltBeaconOrg.BoundBeacon.Powersave;
using AltBeaconOrg.BoundBeacon.Startup;
using Android.App;
using Inject.Activities;
using Inject.Test.Share.Container;

namespace Inject.Configuration
{
  [Application()]
  public class InjectionApplication : Application
  {

    const string TAG = "AndroidProximityReferenceApplication";

    BeaconManager _beaconManager;

    RegionBootstrap regionBootstrap;
    Region _backgroundRegion;
    BackgroundPowerSaver backgroundPowerSaver;
    bool haveDetectedBeaconsSinceBoot = false;

    MainActivity mainActivity = null;
    public MainActivity MainActivity
    {
      get { return mainActivity; }
      set { mainActivity = value; }
    }

    public ContainerClass Container { get; set; }

    public InjectionApplication(IntPtr handle, Android.Runtime.JniHandleOwnership transfer)
      : base(handle, transfer) {
    }

    public InjectionApplication() { }

    public override void OnCreate()
    {
      base.OnCreate();
      Container = new ContainerClass();
    }
  }
}
