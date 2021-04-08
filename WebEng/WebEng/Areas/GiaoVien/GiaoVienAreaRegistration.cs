using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien
{
    public class GiaoVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GiaoVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GiaoVien_default",
                "GiaoVien/{controller}/{action}/{id}",
                new { action = "GiaoVien", id = UrlParameter.Optional, controller = "GiaoVien" },
                new[] { "WebEng.Areas.GiaoVien.Controllers" }
            );
        }
    }
}