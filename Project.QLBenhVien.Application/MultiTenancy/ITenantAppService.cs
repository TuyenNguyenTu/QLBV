using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.QLBenhVien.MultiTenancy.Dto;

namespace Project.QLBenhVien.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
