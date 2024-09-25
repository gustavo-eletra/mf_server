using System.Reflection.Metadata.Ecma335;
var abnt_c_queue = new Queue<ABNTUserData>();
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

app.MapPost("/command", (ABNTUserData data) =>
{
    abnt_c_queue.Enqueue(data);
    Console.WriteLine(data.ToString);
    Console.WriteLine("Hit");
    return "bitch";
});

app.MapGet("/node/{id}", () => 
{
    return "what";
});

app.Run();