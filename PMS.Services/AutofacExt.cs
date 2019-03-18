using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PMS.Infrastructure.Cache;
using PMS.Repository;
using PMS.Repository.Interfaces;
using System.Linq;
using System.Reflection;

namespace PMS.Services
{
    public static class AutofacExt
    {
        private static IContainer _container;
        public static IContainer InitAutofac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            //注册数据库基础操作和工作单元
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //services.AddScoped(typeof(IUnitWork), typeof(UnitWork));

            //services.AddScoped(typeof(IAuth), typeof(LocalAuth));
            //如果想使用WebApi SSO授权，请使用下面这种方式
            //services.AddScoped(typeof(IAuth), typeof(ApiAuth));

            //注册app层
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            //防止单元测试时已经注入
            if (services.All(u => u.ServiceType != typeof(ICacheContext)))
            {
                services.AddScoped(typeof(ICacheContext), typeof(CacheContext));
            }

            if (services.All(u => u.ServiceType != typeof(IHttpContextAccessor)))
            {
                services.AddScoped(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            }

            builder.Populate(services);

            _container = builder.Build();
            return _container;

        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
