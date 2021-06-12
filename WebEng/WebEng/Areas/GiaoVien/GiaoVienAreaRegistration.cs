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
              "GiaoVien_chi-tiet",
              "GiaoVien/chi-tiet/{id}",
              new { action = "ChiTiet", controller = "QLLopHoc", id = UrlParameter.Optional },
              new[] { "WebEng.Areas.GiaoVien.Controllers" }
          );
            context.MapRoute(
                "GiaoVien_default",
                "GiaoVien/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "QLLopHoc" },
                new[] { "WebEng.Areas.GiaoVien.Controllers" }
            );
        }
    }
}