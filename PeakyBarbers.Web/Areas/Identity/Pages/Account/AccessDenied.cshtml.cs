using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PeakyBarbers.Web.Areas.Identity.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {

        public string CustomMessage { get; set; }
        public void OnGet(string message)
        {
            CustomMessage = message;
        }
    }
}

