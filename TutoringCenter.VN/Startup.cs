using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TutoringCenter.VN.EF;
using TutoringCenter.VN.Models;
using TutoringCenter.VN.Models.DataManager;
using TutoringCenter.VN.Models.Repository;

namespace TutoringCenter.VN
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
            services.AddDbContext<TutoringCenterDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TutoringCenterDb")));
            services.AddScoped<IDataRepository<AboutUs>, AboutUsManager>();
            services.AddScoped<IDataRepository<Course>, CourseManager>();
            services.AddScoped<IDataRepository<Feedback>, FeedbackManager>();
            services.AddScoped<IDataRepository<News>, NewsManager>();
            services.AddScoped<IDataRepository<NewsCategory>, NewsCategoryManager>();
            services.AddScoped<IDataRepository<Teacher>, TeacherManager>();
            services.AddScoped<IDataRepository<Student>, StudentManager>();
            services.AddScoped<IDataRepository<User>, UserManager>();
            services.AddScoped<IDataRepository<CommonQuestion>, CommonQuestionManager>();
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.LoginPath = "/Admin/Login";
                option.Cookie.Name = "TutoringCenterCookie";
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(30);//You can set Time   
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Admin_default",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
