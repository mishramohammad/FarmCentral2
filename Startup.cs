using FarmCentral2.Data;
using FarmCentral2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace FarmCentral2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<FarmCentral2Context>();

            services.AddRazorPages();
          

            services.AddControllersWithViews();
            services.AddDbContext<FarmCentral2Context>(options =>
   options.UseSqlServer("Server=LAPTOP-B41IIIGC;Database=FarmCentral2;Trusted_Connection=True;"));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        internal struct NewStruct
        {
            public object Item1;
            public object Item2;

            public NewStruct(object item1, object item2)
            {
                Item1 = item1;
                Item2 = item2;
            }

            public override readonly bool Equals(object obj)
            {
                return obj is NewStruct other &&
                       EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
                       EqualityComparer<object>.Default.Equals(Item2, other.Item2);
            }

            public override readonly int GetHashCode()
            {
                return HashCode.Combine(Item1, Item2);
            }

            public readonly void Deconstruct(out object item1, out object item2)
            {
                item1 = Item1;
                item2 = Item2;
            }

            public static implicit operator (object, object)(NewStruct value)
            {
                return (value.Item1, value.Item2);
            }

            public static implicit operator NewStruct((object, object) value)
            {
                return new NewStruct(value.Item1, value.Item2);
            }
        }
    }
}

