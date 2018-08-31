using System.Web;
using System.Web.Mvc;

namespace labQuiz_TARATHEP_ORA03
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
