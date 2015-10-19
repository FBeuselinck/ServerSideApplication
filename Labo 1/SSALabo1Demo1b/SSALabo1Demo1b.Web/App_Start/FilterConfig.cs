using System.Web;
using System.Web.Mvc;

namespace SSALabo1Demo1b.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}