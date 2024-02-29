using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor06.Models;
using Razor06.Services;

namespace Razor06.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;
        public readonly ProductService productService;
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
        {
            _logger = logger;
             productService = _productService;
        }


        public Product product { set; get; }


        //OnGet, OnPost, OnGetABC...(Handler) dua vao HttpRequest  
        // return void / IActionResult

        //[FromForm]
        //[FromRoute]
        //[FromQuery]
        //[FromHeader]
        //[FromBody]
        public void OnGet(int? id,[Bind("Id", "Name")] Product product)
        {
            Console.WriteLine("Name: "+product.Name);
            Console.WriteLine("Id: "+product.Id);
            //var data =  this.Request.Form["id"]; 
            //var data = this.Request.Query["id"];
            //var data = this.Request.RouteValues["id"];
            //var data = this.Request.Headers["id"];

            //var data = this.Request.Headers["User-Agent"];
            //if(!string.IsNullOrEmpty(data)) {
            //Console.WriteLine(data);
            //}

            if (id != null)   //Request.RouteValues["id"] != null)
            {
                //int id = Convert.ToInt32(Request.RouteValues["id"]);
                ViewData["Title"] = $"San pham ID = {id}";
                product = productService.SearchProduct(id.Value);
            }
            else
            {
                ViewData["Title"] = "Danh sach san pham";
            }
             
           
        }
        // /product/{id:int?}?handler=lastproduct
        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = "San pham cuoi";
            product = productService.GetProducts().LastOrDefault();
            if (product != null)
            {
               return Page();
            }
            else
            {
                return this.Content("Khong tim thay sna pham");
            }
            
        }
        public IActionResult OnGetRemove()
        {
            productService.GetProducts().Clear();
           return RedirectToPage("ProductPage");
        }
        public IActionResult OnGetLoad()
        {
            productService.LoadProduct();
            return RedirectToPage("ProductPage");
        }
        public IActionResult OnPostDelete(int? id)
        {
            if (id != null)
            {
                product = productService.SearchProduct(id.Value);
                if(product != null)
                {
                    productService.GetProducts().Remove(product);
                }
            }
            return RedirectToPage("ProductPage", new {id= string.Empty});
        }
    }
}
