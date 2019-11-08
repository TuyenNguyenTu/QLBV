using System.Threading.Tasks;
using Abp.Application.Services;
using Project.QLBenhVien.Sessions.Dto;

namespace Project.QLBenhVien.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
