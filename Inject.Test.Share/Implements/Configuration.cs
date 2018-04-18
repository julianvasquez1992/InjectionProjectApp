using System;
using Inject.Test.Share.Interfaces;

namespace Inject.Test.Share.Implements
{
  public class Configuration : IConfiguration
  {
    public string StringConnection() => "StringConnection";
  }
}
