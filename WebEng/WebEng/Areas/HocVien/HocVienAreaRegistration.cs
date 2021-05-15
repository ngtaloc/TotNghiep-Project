using System.Web.Mvc;

namespace WebEng.Areas.HocVien
{
    public class HocVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HocVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
           
            context.MapRoute(
               "HocVien_chi-tiet",
               "HocVien/chi-tiet/{id}",
               new { action = "chitietlophoc", controller = "Tim", id = UrlParameter.Optional },
               new[] { "WebEng.Areas.HocVien.Controllers" }
           );
           
            context.MapRoute(
                "HocVien_default",
                "HocVien/{controller}/{action}/{id}",
                new { action = "Index", controller = "Tim", id = UrlParameter.Optional },
                new[] { "WebEng.Areas.HocVien.Controllers" }
            );
           
        }
    }
}