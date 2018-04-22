using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inject.Test.Share.Interfaces
{
  public interface IGetdata
  {
    Task<IEnumerable<Entities.ExampleEntities>> GetTestAsync();
  }
}
