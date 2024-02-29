using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor06.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Razor06.Pages
{
    public class ContactRequestModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public UserContact user { get; set; }
       
        private readonly ILogger<ContactRequestModel> _logger;
        public ContactRequestModel(ILogger<ContactRequestModel> logger) {
            _logger = logger;
            _logger.LogInformation("init contact...");
            //Console.WriteLine("init contact...");
        }
        public double Tong(double a, double b)
        {
            return (a + b);
        }
        public void OnPost()
        {
            Console.WriteLine(this.user.Email);
        }
    }
}
