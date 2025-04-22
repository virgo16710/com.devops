using com.devops.modelos;
using com.devops.persistencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
   options.AddPolicy("Cors", cor =>
   {
       string dominio = builder.Configuration["Dominio:Url"];
       cor.WithOrigins(
           dominio,
           "http://localhost:44300")
       .AllowAnyMethod()
       .AllowAnyHeader();
   })
);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(com.devops.Aplicacion.Paises.Queries.GetAllPaisesQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(com.devops.Aplicacion.Paises.Queries.GetPaisIDQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(com.devops.Aplicacion.Paises.Commdand.CreatePaisCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(com.devops.Aplicacion.Usuarios.Command.CreateUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(com.devops.Aplicacion.Usuarios.Command.LoginUserCommand).Assembly);

});
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty; // Para que Swagger esté en la raíz
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();   
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
