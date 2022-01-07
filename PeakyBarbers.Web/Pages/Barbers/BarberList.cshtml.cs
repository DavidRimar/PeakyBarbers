using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.Web.Pages.Barbers
{
    public class BarberListModel : PageModel
    {
        // PROPERTIES
        public IReadOnlyCollection<BarberHeader> BarberList { get; set; }
        public BarbersService BarbersService { get; }

        public IList<string> PeakyBarberNames { get; set; }

        // CONSTRUCTOR
        public BarberListModel(BarbersService barbersService)
        {
            BarbersService = barbersService;
        }

        // METHODS
        public async Task OnGetAsync()
        {
            BarberList = (IReadOnlyCollection<BarberHeader>)await BarbersService.GetAllBarbersListViewAsync();

            SetPeakyBarberNames();
        }

        private void SetPeakyBarberNames()
        {
            PeakyBarberNames = new List<string>
            {
                "Thomas Shelby",
                "Arthur Shelby",
                "John Shelby"
            };
        }
    }
}
