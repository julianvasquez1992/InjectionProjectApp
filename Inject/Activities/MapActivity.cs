
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Inject.Activities
{
  [Activity(Label = "MapActivity")]
  public class MapActivity : AppCompatActivity, IOnMapReadyCallback, ILocationListener
  {

    private TextView textDistance;
    private TextView textLoading;

    private MapFragment mapFragment;
    private GoogleMap googleMap;

    private Location currentLocation;
    private Location destinatonLocation;
    private LocationManager locationManager;
    private MarkerOptions markerDestination;
    private MarkerOptions myPositionMarket;
    private string locationProvider = string.Empty;

    private bool locationActive = true;

    private HttpClient httpClient;

    public static Intent NewIntent(Context caller)
    {
      if (caller == null)
        throw new ArgumentNullException(nameof(caller));

      return new Intent(caller, typeof(MapActivity));
    }

    public void OnMapReady(GoogleMap map)
    {
      googleMap = map;
      googleMap.MapClick += GoogleMap_MapClick;
      //googleMap.MarkerClick += MapOnMarkerClick;
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.MapLayout);

      textDistance = FindViewById<TextView>(Resource.Id.TextDistance);
      textLoading = FindViewById<TextView>(Resource.Id.TextLoading);

      mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
      if (mapFragment == null)
      {
        GoogleMapOptions mapOptions = new GoogleMapOptions()
            .InvokeMapType(GoogleMap.MapTypeNormal)
            .InvokeZoomControlsEnabled(false)
            .InvokeCompassEnabled(true);

        FragmentTransaction fragTx = FragmentManager.BeginTransaction();
        mapFragment = MapFragment.NewInstance(mapOptions);
        fragTx.Add(Resource.Id.map, mapFragment, "map");
        fragTx.Commit();
      }
      mapFragment.GetMapAsync(this);

      InitializeLocationManager();

      if (currentLocation == null)
      {
        System.Diagnostics.Debug.WriteLine("Current location is null");
      }

    }

    protected override void OnResume()
    {
      base.OnResume();
      locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
    }

    private void InitializeLocationManager()
    {
      locationManager = (LocationManager)GetSystemService(LocationService);
      Criteria criteriaForLocationService = new Criteria { Accuracy = Accuracy.Fine };

      IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);

      if (acceptableLocationProviders.Any())
      {
        locationProvider = acceptableLocationProviders.First();
        System.Diagnostics.Debug.WriteLine($"Location provider: {locationProvider}");
      }
    }

    void GoogleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
    {
      if (currentLocation == null)
        return;

      if (destinatonLocation == null)
      {
        destinatonLocation = new Location(locationProvider);
        markerDestination = new MarkerOptions();
        destinatonLocation.Latitude = e.Point.Latitude;
        destinatonLocation.Longitude = e.Point.Longitude;
        markerDestination.SetPosition(new LatLng(e.Point.Latitude, e.Point.Longitude));
        markerDestination.SetTitle(GetString(Resource.String.DestinationLocation));
        markerDestination.Draggable(true);
        googleMap.AddMarker(markerDestination);

        textDistance.Text = $"{(destinatonLocation.DistanceTo(currentLocation) / 1000).ToString()} KMS";

        googleMap.TrafficEnabled = true;

        PolylineOptions points = new PolylineOptions();
        points.Points.Add(new LatLng(destinatonLocation.Latitude, destinatonLocation.Longitude));
        points.Points.Add(new LatLng(currentLocation.Latitude, currentLocation.Longitude));

        Polyline route = googleMap.AddPolyline(points);

        googleMap.MarkerDragStart += GoogleMap_MarkerDragStart; ;
        googleMap.MarkerDragEnd += GoogleMap_MarkerDragEnd;

      }

    }

    //private void MapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs markerClickEventArgs)
    //{

    //}

    public void OnLocationChanged(Location location)
    {
      currentLocation = location;

      if (locationActive)
      {
        LatLng myLocation = new LatLng(location.Latitude, location.Longitude);
        CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
        builder.Target(myLocation);
        builder.Zoom(15);
        //builder.Bearing(155);
        //builder.Tilt(65);
        CameraPosition cameraPosition = builder.Build();
        CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

        myPositionMarket = new MarkerOptions();
        myPositionMarket.SetPosition(new LatLng(location.Latitude, location.Longitude));
        myPositionMarket.SetTitle(GetString(Resource.String.MyLocation));
        googleMap.AddMarker(myPositionMarket);

        //MapFragment mapFrag = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
        //mapFrag.GetMapAsync(this);
        googleMap.MoveCamera(cameraUpdate);

        locationActive = false;

        OnProviderDisabled(locationProvider);

        textLoading.Visibility = ViewStates.Gone;

      }
      else
      {
        //Toast.MakeText(mapFragment.Context, Resource.String.FindLocation, ToastLength.Short);
      }

    }

    public void OnProviderDisabled(string provider)
    {

    }

    public void OnProviderEnabled(string provider)
    {
      throw new NotImplementedException();
    }

    public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
    {

    }

    void GoogleMap_MarkerDragStart(object sender, GoogleMap.MarkerDragStartEventArgs e)
    {

    }

    void GoogleMap_MarkerDragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
    {
      googleMap.Clear();
      destinatonLocation = new Location(locationProvider);
      markerDestination = new MarkerOptions();
      destinatonLocation.Latitude = e.Marker.Position.Latitude;
      destinatonLocation.Longitude = e.Marker.Position.Longitude;
      markerDestination.SetPosition(new LatLng(destinatonLocation.Latitude, destinatonLocation.Longitude));
      markerDestination.SetTitle(GetString(Resource.String.DestinationLocation));
      markerDestination.Draggable(true);
      googleMap.AddMarker(markerDestination);
      googleMap.AddMarker(myPositionMarket);

      textDistance.Text = $"{(destinatonLocation.DistanceTo(currentLocation) / 1000).ToString()} KMS";

      googleMap.TrafficEnabled = true;

      PolylineOptions points = new PolylineOptions();
      points.Points.Add(new LatLng(destinatonLocation.Latitude, destinatonLocation.Longitude));
      points.Points.Add(new LatLng(currentLocation.Latitude, currentLocation.Longitude));

      Polyline route = googleMap.AddPolyline(points);

      googleMap.MarkerDragStart += GoogleMap_MarkerDragStart; ;
      googleMap.MarkerDragEnd += GoogleMap_MarkerDragEnd;
    }

    private async void GetRoute()
    {
      string strOrigin = $"origin={currentLocation.Latitude},{currentLocation.Longitude}";
      string strDest = $"destination={destinatonLocation.Latitude},{destinatonLocation.Longitude}";
      string sensor = "sensor=false";
      string parameters = $"{strOrigin}&{strDest}&{sensor}";
      string output = "json";

      string urlRoute = $"https://maps.googleapis.com/maps/api/directions/{output}?{parameters}";
      httpClient = new HttpClient();
      var request = new HttpRequestMessage(HttpMethod.Get, urlRoute);
      //var response = await httpClient.SendAsync(request);
      //response.EnsureSuccessStatusCode();
      //var responseContent = response.Content.ReadAsStringAsync();
      var response = await httpClient.GetStringAsync(urlRoute);

    }
  }
}