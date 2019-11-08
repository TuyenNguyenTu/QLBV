using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Project.QLBenhVien.Authorization.Users;
using Project.QLBenhVien.MultiTenancy;
using Project.QLBenhVien.Users;
using Microsoft.AspNet.Identity;

namespace Project.QLBenhVien
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class QLBenhVienAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected QLBenhVienAppServiceBase()
        {
            LocalizationSourceName = QLBenhVienConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}