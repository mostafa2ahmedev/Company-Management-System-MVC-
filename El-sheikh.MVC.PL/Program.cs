using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.BLL.Services.Employees;
using El_sheikh.MVC.DAL.Persistence.Data;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
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
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
