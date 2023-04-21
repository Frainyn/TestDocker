using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

string path = "Static";
DirectoryInfo dirInfo = new DirectoryInfo(path);

if (!dirInfo.Exists)
{
    dirInfo.Create();
}

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Static")),
    RequestPath = "/StaticFiles"
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
