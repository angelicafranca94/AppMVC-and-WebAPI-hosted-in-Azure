using FiapSchoolSystem.Client;
using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Http Client
builder.Services.AddHttpClient<IAlunoService, AlunoService>();
builder.Services.AddHttpClient<ITurmaService, TurmaService>();
builder.Services.AddHttpClient<IAlunoTurmaService, AlunoTurmaService>();

SD.FiapSystemAPIBase = builder.Configuration["ServiceUrls:FiapSchoolAPI"];

// Add Injeção de dependência
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
