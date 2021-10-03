using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories;
using Repositories.Impl;
using Services;
using Services.Impl;

namespace Task12
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
            services.AddDbContext<DataContext>(options =>
                //options.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=task9;Trusted_Connection=True;"));
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=task12;Trusted_Connection=True;"));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();


            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserTypeRepository, UserTypeRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<ITypeService, TypeServices>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IReportService, ReportService>();

            services.AddControllers();
            //services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task12", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task12 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
