
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
using Android.Content.PM;
using Android.Support.V7.Widget;
using Square.Picasso;
using Inject.Test.Share.Container;
using Inject.Test.Share.Interfaces;
using Xamarin.Auth;
using AlertDialog = Android.App.AlertDialog;
using Unity.Attributes;
using Unity;

namespace Inject.Activities
{
  [Activity(MainLauncher = true, 
            ScreenOrientation = ScreenOrientation.Portrait,
           //NoHistory = true,
           LaunchMode = LaunchMode.SingleTask)]
  public class LoginActivity : Activity
  {

    private AppCompatEditText userText;
    private AppCompatEditText passText;
    private Button loginButton;
    private ImageView imageLogin;
    private Picasso picasso;
    private Account account;

    [Dependency]
    public ILogin Login { get; set; }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      picasso = Picasso.With(this);
      SetContentView(Resource.Layout.LoginLayout);

      //auth = ContainerClass.Container.Resolve
      //(typeof(AuthenticationLogin), nameof(AuthenticationLogin)) as AuthenticationLogin;
      account = AccountStore.Create().FindAccountsForService(nameof(LoginActivity)).FirstOrDefault();

      if (account != null)
        RunNewActivity();

      if (Login == null)
        Login = ContainerClass.Container.Resolve<ILogin>();

      userText = FindViewById<AppCompatEditText>(Resource.Id.EmailText);
      passText = FindViewById<AppCompatEditText>(Resource.Id.PasswordText);
      loginButton = FindViewById<Button>(Resource.Id.LoginButton);
      imageLogin = FindViewById<ImageView>(Resource.Id.ImageLogin);

      picasso.Load(Resource.Drawable.Csharp).Into(imageLogin);

      loginButton.Click += LoginClick;

      // Create your application here
    }

    private void LoginClick(object sender, EventArgs e)
    {
      account = new Account();

      if (Login.ToDoLogin(userText.Text, passText.Text))
      {
        account.Username = userText.Text;
        AccountStore.Create().Save(account, nameof(LoginActivity));
        RunNewActivity();
      }
      else
      {
        AlertDialog.Builder alert = new AlertDialog.Builder(this, Resource.Style.DialogStyle);
        alert.SetTitle(Resource.String.AlertDialogTitle);
        alert.SetMessage(Resource.String.ProblemsLogIn);
        alert.SetPositiveButton(GetString(Resource.String.OkButton), (source, args) => { 
          //Toast.MakeText(this, GetString(Resource.String.OkButton), ToastLength.Long).Show();
        });

        Dialog dialog = alert.Create();
        dialog.Show();
      }
    }

    private void RunNewActivity()
    {
      Intent mainActivity = MainActivity.NewIntent(this);
      //mainActivity.SetFlags(ActivityFlags.NoHistory);
      StartActivity(mainActivity);
      Finish();
    }
  }
}
