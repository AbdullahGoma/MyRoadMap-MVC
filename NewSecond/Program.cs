using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewSecond.Data;
using NewSecond.Services;

namespace NewFirst
{

    public class Program
    {
        // Request Come to web Server => Kestrel => Main Method => Startup => Pipeline
        // => Routing Engine(First in Pipeline) if Request have Action and controller => Continue
        // if it hav'nt => short circle and return 404 => before Calling Action it throw on =>
        // Model Binding 


        // Filter 1) Authorize(and Resource => Check type of data). if not =>
        // short circle 2)Action(Executing 'Before'
        // , Excecuted 'After') => 3) Result => 4) Exception
        public static void Main(string[] args)
        {
            //StartupBase
            // Create Host => my web site
            var builder = WebApplication.CreateBuilder(args);
            // Framework Services => IConfiguration => take data from AppSetting, LaunchSetting
            // , CMD, Enviroment Variable 
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

            //builder.Services.AddSingleton<IStudentRepository, StudentRepository>(); // Ceate only one Object 
            //builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

            //builder.Services.AddTransient<IStudentRepository, StudentRepository>(); // Ceate Objects in the same request 
            //builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>(); // Ceate Objects but in the same request only one 
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

            // To Do Requests Faster
            // Configure the HTTP request pipeline. -set of Middleware component

            #region Inline Middleware
            //// Inline Middleware ==> Anonymous function
            //app.Use(async (context, next) =>
            //{
            //    // Can Add or not
            //    await context.Response.WriteAsync("1)Middleware 1_1 \n");
            //    // can call next middler or not "short circle"
            //    await next.Invoke();

            //    await context.Response.WriteAsync("5)Middleware 1_2 \n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    // Can Add or not
            //    await context.Response.WriteAsync("2)Middleware 2_1 \n"); //business
            //    // can call next middler or not "short circle"
            //    await next.Invoke();

            //    await context.Response.WriteAsync("4)Middleware 2_2 \n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("3)Terminate \n");
            //});

            //// Not Run, Because app.Run() do Termenate
            //app.Use(async (context, next) =>
            //{
            //    // Can Add or not
            //    await context.Response.WriteAsync("Middleware 4 \n"); //business
            //    // can call next middler or not "short circle"
            //    await next.Invoke();
            //}); 
            #endregion


            #region Built in Middleware Component
            // Middleware Component
            if (!app.Environment.IsDevelopment())
            {
                //app.UseStatusCodePagesWithRedirects("/home/Error");
                app.UseExceptionHandler("/Home/Error"); // Middleware(Error Exception)
            }
            app.UseStaticFiles(); // Middleware(html,css,js)

            app.UseRouting(); // Middleware(If URL Valid or No) => Take Request and match it 
            // to specific endpoint


            app.UseAuthentication(); // Cookie

            //Check On Cookie
            app.UseAuthorization(); // Middleware(Accessability: if not => 402 not found)

            //Using Sessions
            app.UseSession();

            //app.MapControllerRoute(
            //    name: "default1",
            //    pattern: "Dept/{id?:int:min(100):max(200)}",
            //    defaults: new {controller = "Department", action = "index"});

            // {controller = Home}/{action = Index}/{id:int:min(100)}
            // http://local....:53332/Home/Check/Hello => Status Code:404 Not Found




            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Three Segments 

            app.Run(); // Middleware 
            #endregion
        }
    }
}