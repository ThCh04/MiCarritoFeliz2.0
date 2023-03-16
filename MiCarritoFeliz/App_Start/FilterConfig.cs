using MiCarritoFeliz.Filters;
using System.Web;
using System.Web.Mvc;

namespace MiCarritoFeliz
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificadorSession());
        }
    }
}
