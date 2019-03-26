using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.Infrastructure.Cache;
using PMS.Repository;
using PMS.Repository.Interfaces;
using PMS.Services.Implements;
using PMS.Services.Interfaces;

namespace PMS
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //此lambda确定对于给定请求是否需要用户同意非必要cookie。
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None; //Affects the cookie's same site attribute.
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";

                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "mvc";
                    options.SaveTokens = true;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //连接sql server数据库
            services.AddDbContext<PMSDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PMSDbContext")));

            //支持跨域
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://www.jsclient.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //service注入
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICacheContext), typeof(CacheContext));
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IOrgService, OrgService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
