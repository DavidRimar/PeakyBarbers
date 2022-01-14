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
    public class ServiceEditModel : PageModel
    {
        public ServicesService ServicesService { get; }

        public ServiceEditModel(ServicesService service)
        {
            ServicesService = service;
        }

        [BindProperty]
        public ServiceEdit ServiceToEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            await LoadAsync(id);

            if (ServiceToEdit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                await LoadAsync(ServiceToEdit.Id);

                return Page();
            }

            await ServicesService.PostEditService(ServiceToEdit);

            return new RedirectToPageResult("./ServiceList");
        }

        private async Task LoadAsync(int id) {

            ServiceToEdit = await ServicesService.GetServiceToEditByIdAsync(id);

        }
    }
}
