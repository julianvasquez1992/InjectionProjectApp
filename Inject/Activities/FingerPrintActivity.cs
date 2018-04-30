
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Javax.Crypto;

namespace Inject.Activities
{
  [Activity(Label = "FingerPrintActivity")]
  public class FingerPrintActivity : AppCompatActivity
  {
    FingerprintManagerCompat fingerprintManager;
    FingerprintManagerCompat.AuthenticationCallback authenticationCallback;

    public static Intent NewInstance(Context caller)
    {
      if (caller == null)
        throw new ArgumentNullException(nameof(caller));

      return new Intent(caller, typeof(FingerPrintActivity));
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.FingerPrintLayout);
      // context is any Android.Content.Context instance, typically the Activity 

      fingerprintManager = FingerprintManagerCompat.From(this);

      if (!fingerprintManager.IsHardwareDetected)
      {
        Toast.MakeText(this, Resource.String.NoHardware, ToastLength.Long).Show();
      }
      else
      {
        if (!fingerprintManager.HasEnrolledFingerprints)
        {
          
        }

        // The context is typically a reference to the current activity.

        Android.Content.PM.Permission permissionResult = CheckSelfPermission(Manifest.Permission.UseFingerprint);
        if (permissionResult == Android.Content.PM.Permission.Granted)
        {
          // Permission granted - go ahead and start the fingerprint scanner.
          FingerPrintAuthenticationExample();
        }
        else
        {
          Toast.MakeText(this, Resource.String.NoPermission, ToastLength.Long).Show();
        }
      }

    }

    protected void FingerPrintAuthenticationExample()
    {
      const int flags = 0;

      Android.Support.V4.OS.CancellationSignal cancellationSignal = new Android.Support.V4.OS.CancellationSignal();

      FingerprintManagerCompat fingerPrintManager = FingerprintManagerCompat.From(this);

      authenticationCallback = new MyAuthCallbackSample(this);
      authenticationCallback.OnAuthenticationFailed();

      // Start the fingerprint scanner.
      fingerprintManager.Authenticate(null, flags, cancellationSignal, authenticationCallback, null);
    }
  }

  class MyAuthCallbackSample : FingerprintManagerCompat.AuthenticationCallback
  {

    Activity context;
    private TextView fingerPrintText;

    public MyAuthCallbackSample(Activity activity)
    {
      if (activity == null)
      {
        throw new ArgumentNullException(nameof(activity));
      }

      this.context = activity;

    }

    public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
    {
      fingerPrintText = context.FindViewById<TextView>(Resource.Id.FingerListening);
      fingerPrintText.Text =  context.GetString(Resource.String.IsReadFinger);
    }

    public override void OnAuthenticationError(int errMsgId, ICharSequence errString)
    {
      
    }

    public override void OnAuthenticationFailed()
    {
      fingerPrintText = context.FindViewById<TextView>(Resource.Id.FingerListening);
      fingerPrintText.Text = context.GetString(Resource.String.NotReadFinger);
    }

    public override void OnAuthenticationHelp(int helpMsgId, ICharSequence helpString)
    {
      
    }
  }
}
