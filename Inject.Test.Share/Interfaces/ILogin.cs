using System;
namespace Inject.Test.Share.Interfaces
{
  public interface ILogin
  {
    bool IsLogin();
    bool ToDoLogin(string user, string pass);
    bool Logout();
  }
}
