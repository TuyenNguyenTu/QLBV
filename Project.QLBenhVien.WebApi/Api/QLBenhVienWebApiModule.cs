using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web;
using Abp.WebApi;
using Project.QLBenhVien.BenhNhans;
using Swashbuckle.Application;

namespace Project.QLBenhVien.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(QLBenhVienApplicationModule))]
    public class QLBenhVienWebApiModule : AbpModule
    {
        public override void Initialize()
        {
           Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(QLBenhVienApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(QLBenhVienApplicationModule)), "app")
                .Build();
            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //    .For<IBenhNhanAppService>("app/benhNhan")
            //    .ForMethod("Create").DontCreateAction().Build();

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .For<IBenhNhanAppService>("app/benhNhan")
                .ForMethod("ListAll").WithVerb(HttpVerb.Post)
                .ForMethod("Update").WithVerb(HttpVerb.Get)
                .ForMethod("Delete").WithVerb(HttpVerb.Get)
                .ForMethod("Create").WithVerb(HttpVerb.Get)
                .ForMethod("GetBenhNhanById").WithVerb(HttpVerb.Get)
                .Build();
            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //    .For<IBenhNhanAppService>("app/benhNhan")
            //    .ForMethod("Update").WithVerb(HttpVerb.Put)
            //    .Build();
            //Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //    .For<IBenhNhanAppService>("app/benhNhan")
            //    .ForMethod("Delete").WithVerb(HttpVerb.Delete)
            //    .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            ConfigureSwaggerUi();
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "QLBenhVien.WebApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    c.InjectJavaScript(Assembly.GetAssembly(typeof(QLBenhVienWebApiModule)), "QLBenhVien.WebApi.Api.Scripts.Swagger-Custom.js");
                });
        }
    }
}
