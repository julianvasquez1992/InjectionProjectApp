using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace Inject.Fragments
{
  public class BeaconsFragment : Fragment
  {

    public static BeaconsFragment Newinstance()
    {
      return new BeaconsFragment();
    }

    public override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
    }

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
      return inflater.Inflate(Resource.Layout.BeaconsLayout, container, false);
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
      base.OnViewCreated(view, savedInstanceState);
    }
  }
}
