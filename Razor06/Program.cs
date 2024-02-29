using Razor06.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProductService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
 Cach tao Razor Page bang lenh dotnet
dotnet new page -h
- ProductPage
dotnet new page -na ProductPage -o Pages -p:n Razor06.Pages


- Model Biding: Liên kết dữ liệu
Dữ liệu gửi đến:(key,value)

Nguồn: 
    - Form HTML(post) : HttpRequest.Form["key"]
    - Query(form html -get) : HttpRequest.Query["key"]
    - Header :HttpRequest.Header["key"]
    - Route Data: HttpRequest.RouteValues["key"]
    - Upload
    - Body 
Đọc dữ liệu HttpRequest(Controller, PageModel, View)
 

-Attributes: Parameter Binding, Property Biding

Parameter Binding:

Property Biding:  [BindProperty]-post
 */
