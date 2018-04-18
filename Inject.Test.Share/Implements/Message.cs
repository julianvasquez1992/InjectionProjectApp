using System;
using Inject.Test.Share.Interfaces;

namespace Inject.Test.Share.Implements
{
  public class Message : IMessage
  {
    public string MessageHelloWorld() => "Hello world!";
  }
}
