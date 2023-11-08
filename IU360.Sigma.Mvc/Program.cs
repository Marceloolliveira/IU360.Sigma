using Auth0.AspNetCore.Authentication;
using IU360.Sigma.Mvc.repositories;
using Microsoft.EntityFrameworkCore;

namespace IU360.Sigma.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
            .AddAuth0WebAppAuthentication(options => {
                options.Domain = builder.Configuration["Auth0:Domain"];
                options.ClientId = builder.Configuration["Auth0:ClientId"];
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CadastroDeProdutoDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"))
                    );

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
        }
    }
}