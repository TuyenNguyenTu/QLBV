using Abp.Authorization;
using Project.QLBenhVien.Authorization.Roles;
using Project.QLBenhVien.Authorization.Users;

namespace Project.QLBenhVien.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
