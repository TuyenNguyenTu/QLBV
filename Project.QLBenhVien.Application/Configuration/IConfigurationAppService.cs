using System.Threading.Tasks;
using Abp.Application.Services;
using Project.QLBenhVien.Configuration.Dto;

namespace Project.QLBenhVien.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}