using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Inject.Test.Share.Entities;
using Inject.Test.Share.Interfaces;
using Newtonsoft.Json;

namespace Inject.Test.Share.Implements
{
  public class GetData : IGetdata
  {
    private HttpClient httpClient;

    public async Task<IEnumerable<ExampleEntities>> GetTestAsync()
    {
      httpClient = new HttpClient();
      //var uri = new Uri("https://jsonplaceholder.typicode.com/posts");
      var uri = "https://vikyproduction.azurewebsites.net/viky-rest-api-0.0.1-SNAPSHOT/public/api/event/51/agenda";
      IEnumerable<ExampleEntities> responseAgendaList;
      var request = new HttpRequestMessage(HttpMethod.Get, uri);
      string responseContent = string.Empty;
      try
      {
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        responseContent = await response.Content.ReadAsStringAsync();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"{ex.InnerException.Message}");
      }

      responseAgendaList = JsonConvert.DeserializeObject<IEnumerable<ExampleEntities>>(responseContent);

      return responseAgendaList;

      //var uri = new Uri("https://jsonplaceholder.typicode.com/posts");
      //var response = await httpClient.GetAsync(uri);
      //if (response.IsSuccessStatusCode)
      //{
      //  var content = await response.Content.ReadAsStringAsync();
      //  responseAgendaList = JsonConvert.DeserializeObject<IEnumerable<ExampleEntities>>(content);
      //  return responseAgendaList;
      //}

      //throw new ArgumentNullException();
    }
  }
}
