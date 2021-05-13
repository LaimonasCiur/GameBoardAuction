using GameBoardAuction.Common.Configuration;
using GameBoardAuction.Data;
using GameBoardAuction.Entities;
using GameBoardAuction.Repositories.Repositories;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using GameBoardAuction.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GameBoardAuction
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameBoardAuctionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                if (Env.IsDevelopment())
                {
                    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
                    .AddDebug()
                    .AddConsole()))
                    .EnableSensitiveDataLogging();
                }
            });

            services.Configure<ConfigurationSettings>(Configuration);
            services.AddTransient(s => s.GetService<IOptions<ConfigurationSettings>>().Value);

            services.AddDbContext<GameBoardAuctionIdentityContext>(options => options.UseSqlServer(Configuration
                .GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                //.AddRoleManager<IdentityUser>()
                //.AddUserManager<IdentityUser>()
                .AddEntityFrameworkStores<GameBoardAuctionIdentityContext>();

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            //Repositories
            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<IAuctionBetRepository, AuctionBetRepository>();

            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAuctionBetService, AuctionBetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            CreateRoles(services).GetAwaiter().GetResult();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult adminRoleResult;
            bool adminRoleExists = await RoleManager.RoleExistsAsync("Admin");

            if (!adminRoleExists)
            {
                adminRoleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            IdentityUser userToMakeAdmin = await UserManager.FindByNameAsync("admin@test.com");
            await UserManager.AddToRoleAsync(userToMakeAdmin, "Admin");
        }
    }
}
