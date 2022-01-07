using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.BLL.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeakyBarbers.Web.Pages
{
    public class IndexModel : PageModel
    {
        // PROPERTIES
        public IReadOnlyCollection<BarberHeader> BarberList { get; set; }
        public BarbersService BarbersService { get; }

        public IList<string> PeakyBarberNames { get; set; }

        // CONSTRUCTOR
        public IndexModel(BarbersService barbersService)
        {
            BarbersService = barbersService;
        }

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
