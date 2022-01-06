using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Services
{
    public class ServiceDeleteModel : PageModel
    {
        public ServicesService ServicesService { get; }

        public ServiceDeleteModel(ServicesService servicesService)
        {
            ServicesService = servicesService;
        }

        [BindProperty]
        public ServiceDelete ServiceToDelete { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {

            ServiceToDelete = await ServicesService.GetServiceToDeleteByIdAsync(id);

            if (ServiceToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await ServicesService.PostDeleteService(id.Value);

            // TODO: To Confirm Delete on Page, and not redirect

            return RedirectToPage("./ServiceList");
        }
    }
}
