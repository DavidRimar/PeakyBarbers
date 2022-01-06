using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Services
{
    public class ServiceListModel : PageModel
    {
        // PROPERTIES
        public IList<ServiceHeader> ServiceList { get; set; }
        public ServicesService ServicesService { get; }

        // CONSTRUCTOR
        public ServiceListModel(ServicesService servicesService)
        {
            ServicesService = servicesService;
        }

        // METHODS
        public async Task OnGetAsync()
        {
            ServiceList = await ServicesService.GetAllServicesListViewAsync();
        }
    }
}
