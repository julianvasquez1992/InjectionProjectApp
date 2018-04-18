using System;
using Unity.Attributes;
using Inject.Test.Share.Interfaces;

namespace Inject.Test
{
  public class MessageTest
  {
    IMessage message;
    ITest test;

    [InjectionConstructor]
    public MessageTest(IMessage message, ITest test)
    {
      this.message = message;
      this.test = test;
    }

    public string ReturnMessage()
    {
      return message.MessageHelloWorld();
    }

    public string GetMessage(string message){
      return test.GetMessage(message);
    }
  }
}
