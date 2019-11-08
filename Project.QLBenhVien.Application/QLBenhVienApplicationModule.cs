using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using AutoMapper;
using Project.QLBenhVien.Authorization.Roles;
using Project.QLBenhVien.Authorization.Users;
using Project.QLBenhVien.BenhNhans.DTO;
using Project.QLBenhVien.Models;
using Project.QLBenhVien.Roles.Dto;
using Project.QLBenhVien.Users.Dto;

namespace Project.QLBenhVien
{
    [DependsOn(typeof(QLBenhVienCoreModule), typeof(AbpAutoMapperModule))]
    public class QLBenhVienApplicationModule : AbpModule
    {
        [System.Obsolete]
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                #region Benh Nhan
                mapper.CreateMap<CreateBenhNhanInput, BenhNhan>().ReverseMap();
                mapper.CreateMap<List<BenhNhan>, List<GetBenhNhanOutput>>().ReverseMap();
                mapper.CreateMap<UpdateBenhNhanInput, BenhNhan>().ReverseMap();
                mapper.CreateMap<BenhNhan, GetBenhNhanOutput>();

                #endregion

            });
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateBenhNhanInput, BenhNhan>();
                cfg.CreateMap<BenhNhan, GetBenhNhanOutput>();
                cfg.CreateMap<BenhNhan, GetBenhNhanOutput>();
                cfg.CreateMap<UpdateBenhNhanInput, BenhNhan>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
