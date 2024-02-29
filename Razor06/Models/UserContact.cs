using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Razor06.Models
{
    public class UserContact
    {
        [BindProperty(SupportsGet = true)]
        [DisplayName("Nhap ID")]
        [Range(2, 10, ErrorMessage = "Nhap sai")]
        public int UserId { get; set; }
        [BindProperty(SupportsGet = true)]
        [DisplayName("Nhap Email")]
        [EmailAddress(ErrorMessage = "Email sai")]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}
