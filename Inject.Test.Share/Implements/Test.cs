using System;
using Inject.Test.Share.Interfaces;

namespace Inject.Test.Share.Implements
{
  public class Test : ITest
  {
    public string GetMessage(string messageFromUser) => messageFromUser;
  }
}
