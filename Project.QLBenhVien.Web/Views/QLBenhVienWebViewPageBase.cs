using Abp.Web.Mvc.Views;

namespace Project.QLBenhVien.Web.Views
{
    public abstract class QLBenhVienWebViewPageBase : QLBenhVienWebViewPageBase<dynamic>
    {

    }

    public abstract class QLBenhVienWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected QLBenhVienWebViewPageBase()
        {
            LocalizationSourceName = QLBenhVienConsts.LocalizationSourceName;
        }
    }
}