using AssignmentDTwo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewSecond.Data;

namespace AssignmentDTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //StartupBase
            // Create Host => my web site
            var builder = WebApplication.CreateBuilder(args);
            var ConStr = builder.Configuration.GetConnectionString("SqlCon");
            // IoC Container ==> Service Provider
            // Add services to the container.
            builder.Services.AddControllersWithViews(); // Framework Services(IServiceCollection)

            // Add Session(Built in Service)
            builder.Services.AddSession(c => {
                c.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
                                                   options.UseSqlServer(ConStr));

            // Register My (Custom Service)
            //builder.Services.AddSingleton<TypeSource, Type Create Instance>

            //builder.Services.AddSingleton<IInstructorRepository, InstructorRepository>(); // Ceate only one Object 
            //builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

            //builder.Services.AddTransient<IInstructorRepository, InstructorRepository>(); // Ceate Objects in the same request 
            //builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>(); // Ceate Objects but in the same request only one 
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(options =>
            //{
            //    options.Cookie.Name = "";
            //    options.Cookie.Path = "/";
            //    options.LoginPath = "/Login";
            //    options.LogoutPath = "/Logout";
            //    options.AccessDeniedPath = "";
            //});


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


            app.UseAuthentication(); // Cookie

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}