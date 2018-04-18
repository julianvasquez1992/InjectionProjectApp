using System;
using System.Diagnostics;
using Inject.Test.Share.Interfaces;
using Unity.Attributes;

namespace Inject.Test.Share.Implements
{
  public class Login : ILogin
  {
    private bool userIsLogged = false;
    private IConfiguration configuration;

    [InjectionConstructor]
    public Login(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public bool IsLogin() => userIsLogged;

    public bool Logout() => userIsLogged = false;

    public bool ToDoLogin(string user, string pass)
    {
      if (!string.IsNullOrEmpty(configuration.StringConnection()))
      {
        Debug.WriteLine($"Correct string");
      }

      if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(pass) )
      {
        Debug.WriteLine($"Error: User: {user}\nPass: {pass}");
        return false;
      }

      //if (user == "julian" && pass == "123456")
      //{
      //  Debug.WriteLine($"Accept: User: {user}\nPass: {pass}");
      //  userIsLogged = true;
      //  return true;
      //}

      return true;

    }
  }
}
