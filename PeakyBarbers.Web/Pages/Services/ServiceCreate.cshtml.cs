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
    public class ServiceCreateModel : PageModel
    {
        public ServicesService ServicesService { get; }

        public ServiceCreateModel(ServicesService servicesService)
        {
            ServicesService = servicesService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceCreate ServiceToCreate { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { 
                return Page();
            }

            await ServicesService.PostCreateService(ServiceToCreate);

            return RedirectToPage("./ServiceList");
        }
    }
}
