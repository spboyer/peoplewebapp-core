using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference;

namespace peoplewebapp_core.Pages
{
  public class PeopleModel : PageModel
  {
    public IList<Person> People;
    public async Task OnGetAsync()
    {
      var server = Environment.GetEnvironmentVariable("SERVICE_URL");
      var serviceUrl =  $"http://{server}/People.svc";
      var client = new GetPeopleServiceClient(GetPeopleServiceClient.EndpointConfiguration.BasicHttpBinding_IGetPeopleService, serviceUrl);
      People = await client.GetPeopleDataAsync(12);
    }
  }
}
