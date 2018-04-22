using System;
using System.Collections.Generic;

namespace Inject.Utitlities
{
  public class LoaderResponse<TResponse> : Java.Lang.Object
  {
    public Exception Exception { get; private set; }
    public IEnumerable<TResponse> ResponseEnum { get; private set; }
    public TResponse Response { get; private set; }

    public LoaderResponse(TResponse Response)
    {
      this.Response = Response;
    }

    public LoaderResponse(IEnumerable<TResponse> Response)
    {
      this.ResponseEnum = Response;
    }

    public LoaderResponse(Exception exception)
    {
      Exception = exception;
    }
  }
}
