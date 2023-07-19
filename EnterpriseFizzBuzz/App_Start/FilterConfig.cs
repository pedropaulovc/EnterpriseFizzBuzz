using System.Web;
using System.Web.Mvc;

namespace EnterpriseFizzBuzz
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
