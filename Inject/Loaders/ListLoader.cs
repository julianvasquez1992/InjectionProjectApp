using System;
using Android.Content;
using Unity.Attributes;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Inject.Test.Share.Interfaces;
using Inject.Test.Share.Container;
using Unity;
using Inject.Test.Share.Entities;
using Android.App;

namespace Inject.Loaders
{
  public class ListLoader
  {

    [Dependency]
    public IGetdata Getdata { get; set; }

    public ListLoader(Context context)
    {
      Getdata = ContainerClass.Container.Resolve<IGetdata>();
    }

    public IObservable<ExampleEntities> GetObservable()
    {
      IObservable<ExampleEntities> observable = Getdata.GetTestAsync()
                          .ToObservable()
                          .SelectMany(x => x)
                          .Replay()
                          .RefCount()
                          .ObserveOn(Application.SynchronizationContext);

      observable.Subscribe(album => { }, error =>
      {
        observable = null;
      });

      return observable;
    }

	}
}
