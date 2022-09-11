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
        public void OnGet()
        {
            //   userService.Get(1);
            var users = userService.GetAll().Result.ToList();
            
        }
    }
}