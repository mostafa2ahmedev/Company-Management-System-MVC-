using El_sheikh.MVC.BLL.Common.Services.Attachments;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.BLL.Services.Employees;
using El_sheikh.MVC.DAL.Entities.Identity;
using El_sheikh.MVC.DAL.Persistence.Data;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using El_sheikh.MVC.DAL.UnitOfWork;
using El_sheikh.MVC.PL.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace El_sheikh.MVC.PL
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
        
            #region Configure Services
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>(serviceProvider =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionsBuilder.UseSqlServer("Server=.;Database=IKEA;Trusted_Connection=True;TrustServerCertificate=True");

            //    var options = optionsBuilder.Options;
            //    return options;

            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder => {

                //optionsBuilder.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Business Services
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            //AttachmentService
            builder.Services.AddScoped<IAttachmentService , AttachmentService>();
            //UnitOfWork
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

            //Auto Mapper Package
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));


            //Security Services

            //builder.Services.AddScoped<UserManager<ApplicationUser>>();
            //builder.Services.AddScoped<SignInManager<ApplicationUser>>();
            //builder.Services.AddScoped<RoleManager<IdentityRole>>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = true;    //#$
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;


                options.User.RequireUniqueEmail = true;
                //options.User.AllowedUserNameCharacters 

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
            
            }).AddEntityFrameworkStores<ApplicationDbContext>();



            
            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Account/SignIn";    // from here (base) go to /Account/SignIn
                options.AccessDeniedPath = "/Home/Error"; // if the user doesn't have the specified Role

                options.ExpireTimeSpan = TimeSpan.FromDays(5);

            });
            #endregion


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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
