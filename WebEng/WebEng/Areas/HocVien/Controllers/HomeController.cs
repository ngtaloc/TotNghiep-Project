using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Controllers;

namespace WebEng.Areas.HocVien.Controllers
{

    [Authorize(Roles = "HocVien")]
    public class HomeController : LayoutController
    {
        // GET: HocVien/Home
      
        [HttpGet]
        public ActionResult Index()
        {
            var dao = new LopHocDAO();
			var model = dao.FindAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Find(string tim =null, bool Listening = false, bool Speaking = false, bool Reading = false, bool Writing = false, string lvListening = null, string lvSpeaking = null, string lvReading = null, string lvWriting = null)
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocIndex(tim ,  Listening,  Speaking,  Reading , Writing ,  lvListening , lvSpeaking , lvReading , lvWriting );
            return View("Index",model);
        }

        public ActionResult chitietlophoc(int id)
		{
            
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);

            return View(model);
		}
		
	}
}