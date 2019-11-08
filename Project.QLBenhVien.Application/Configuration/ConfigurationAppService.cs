using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Project.QLBenhVien.Configuration.Dto;

namespace Project.QLBenhVien.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QLBenhVienAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
