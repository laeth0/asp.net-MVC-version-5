using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication2.Context;
using WebApplication2.Repository;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//put in it my configure services which will run by dependency injection and add services of the project that i work on 
        {
            //services.AddControllers();//this add services of API
            //services.AddRazorPages();////this add services of Razor Page
            //services.AddMvc();//this add services of MVC and API and Razor Page


            services.AddControllersWithViews();//this add services of MVC
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudentRepository, StudentRepository>();//send a new copy for every request to the controller 
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }


        // This method gets called at the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)// in this method i make configure for the request (HTTP and middleware)
        {
            if (env.IsDevelopment())// this method go to launchSettings.json in Properties and check ASPNETCORE_ENVIRONMENT
            {
                app.UseDeveloperExceptionPage();// if i in development environment then skip the first middleware which is put every exception in page
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            app.UseStaticFiles();// this middleware use to use static files like css and js and images and i use it to enable the bootstrap in my project

            app.UseRouting();// this is the second middleware which check if the route that comes (URL) is right or not

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(// this method create a new route for the project
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");// attention=> no spaces in the pattern(URL)
            });
        }
    }
}
