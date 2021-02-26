using System.Web;
using System.Web.Mvc;

namespace n01397767_Assignment2_WebApiMethods
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
