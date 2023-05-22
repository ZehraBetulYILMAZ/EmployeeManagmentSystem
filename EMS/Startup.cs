using EMS.business.Abstract;
using EMS.business.Concrete;
using EMS.data.Abstract;
using EMS.data.Concrete.EFCore;
using EMS.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EMS.WebUI
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
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql("Server=localhost;Port=5432;Database=EMSDemo;User Id=postgres;Password=hello123"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => {
                // password
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequiredLength = 6;
                //options.Password.RequireNonAlphanumeric = true;

                // Lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
              //  options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/admin/index";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".EMS.Security.Cookie"
                };
            });
            services.AddScoped<IEmployeeRepository,EfCoreEmployeeRepository>(); 
            services.AddScoped<IEmployeeService,EmployeeManager>(); 
            services.AddScoped<IActivityRepository, EfCoreActivityRepository>();
            services.AddScoped<IPayrollRepository, EfCorePayrollRepository>();
            services.AddScoped<IPayrollService, PayrollManager>();
            services.AddScoped<IActivityService, ActivityManager>();
            services.AddScoped<ITaskRepository, EfCoreTaskRepository>();
            services.AddScoped<ITaskService, TaskManager>();
            services.AddControllersWithViews();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "employeeprofile",
                   pattern: "employee/profile/details/{id?}",
                   defaults: new {controller="Employee",action="ProfileDetails"});
                endpoints.MapControllerRoute(
                    name: "employeeviewtask",
                    pattern: "employee/viewtask/{id?}",
                    defaults: new { controller = "Employee", action = "ViewTask" }
                );

            });
         
        }
    }
}