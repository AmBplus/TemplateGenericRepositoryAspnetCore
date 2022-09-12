using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Endpoint.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;
        public IndexModel(IUserService userService)
        {
            this.userService = userService;
        }  
        public async Task<IActionResult> OnGet()
        {
            var user = await userService.Get(1, true);
            var userDto = await userService.Get(1);
            var users = await userService.GetAll();
            return Page();
        }
    }
}