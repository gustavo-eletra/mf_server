using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapPost("/mouse_entered", () => 
{
    Console.WriteLine("Here!");
    return "<p>[Bitch]</p>";
});

app.MapPost("/clicked", () => 
{
    Console.WriteLine("There!");
    return "<button hx-post='/clicked' hx-swap='outerHTML'> This! </button>";
});

app.MapGet("/graph", () => 
{
    return "what";
});

app.Run();