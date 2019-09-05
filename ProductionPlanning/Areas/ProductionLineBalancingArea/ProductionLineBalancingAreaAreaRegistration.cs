using System.Web.Mvc;

namespace CRM.Areas.ProductionLineBalancingArea
{
    public class ProductionLineBalancingAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ProductionLineBalancingArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ProductionLineBalancingArea_default",
                "ProductionLineBalancingArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
