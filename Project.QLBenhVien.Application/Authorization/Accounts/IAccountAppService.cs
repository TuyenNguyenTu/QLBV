using System.Threading.Tasks;
using Abp.Application.Services;
using Project.QLBenhVien.Authorization.Accounts.Dto;

namespace Project.QLBenhVien.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
