using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeakyBarbers.Data.Entities;

namespace PeakyBarbers.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var userCustomData = await _userManager.GetUserAsync(User);

            Username = userName;

            Input = new InputModel
            {
                FirstName = userCustomData.FirstName,
                LastName = userCustomData.LastName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userCustomData = await _userManager.GetUserAsync(User);

            // if FirstName changed
            if (Input.FirstName != userCustomData.FirstName)
            {
                // set user FirstName to the newly typed name
                user.FirstName = Input.FirstName;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set First Name.";
                    return RedirectToPage();
                }
            }

            // if LastName changed
            if (Input.LastName != userCustomData.LastName)
            {
                // set user FirstName to the newly typed name
                user.LastName = Input.LastName;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set Last Name.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            
            StatusMessage = "Your profile has been updated";
            
            return RedirectToPage();
        }
    }
}
