using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Java.Lang;
using AsyncTaskLoader = Android.Support.V4.Content.AsyncTaskLoader;
using Unity.Attributes;
using Inject.Test.Share.Interfaces;
using Inject.Test.Share.Container;
using Unity;
using Inject.Test.Share.Entities;
using System.Collections.Generic;
using Inject.Utitlities;

namespace Inject.Loaders
{
  public class ListLoader : AsyncTaskLoader
  {

    [Dependency]
    public IGetdata Getdata { get; set; }

    public ListLoader(Context context) : base(context)
    {
      Getdata = ContainerClass.Container.Resolve<IGetdata>();
    }

    public override Java.Lang.Object LoadInBackground()
    {
      var data = Getdata.GetTestAsync() as IEnumerable<ExampleEntities>;
      Java.Lang.Object javaObject = new LoaderResponse<ExampleEntities>(data);
      var retrieve = (LoaderResponse<ExampleEntities>)data;
      return javaObject;
    }

		protected override void OnStartLoading()
		{
      ForceLoad();
		}

		public override void DeliverResult(Java.Lang.Object data)
		{
			base.DeliverResult(data);
		}

	}
}
