using System;
using System.Collections.Generic;
using Inject.Test.Share.Implements;
using Inject.Test.Share.Interfaces;
using Unity;
using Unity.Extension;
using Unity.Lifetime;
using Unity.Registration;
using Unity.Resolution;

namespace Inject.Test.Share.Container
{
  public class ContainerClass
  {
    public static IUnityContainer Container { get; set; }

    public ContainerClass()
    {
      Container = new UnityContainer();
      Container.RegisterType<IMessage, Message>();
      Container.RegisterType<ITest, Implements.Test>();
      Container.RegisterType<ILogin, Login>(new ContainerControlledLifetimeManager());
      //Container.RegisterType<ILogin, Login>();
      Container.RegisterType<IConfiguration, Configuration>();
    }
  }
}
