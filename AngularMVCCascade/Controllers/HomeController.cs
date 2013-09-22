using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVCCascade.Models;
namespace AngularMVCCascade.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
     
        public JsonResult GetCountries()
        {
            
            using (MyDatabaseEntities context = new MyDatabaseEntities()) {
                var ret = context.Countries.Select(x=>new { x.CountryId,x.CountryName}).ToList();
                return Json(ret, JsonRequestBehavior.AllowGet);             
            }            
        }
      
        [HttpPost]
        public JsonResult GetStates(int countryId)
        {
            using (MyDatabaseEntities context = new MyDatabaseEntities())
            {
                var ret = context.States.Where(x => x.CountryId == countryId).Select(x => new { x.StateId, x.StateName }).ToList();
                return Json(ret);
            }
        }
     
        public JsonResult GetAll()
        {
            using (MyDatabaseEntities context = new MyDatabaseEntities())
            {

                var ret = context.Countries.Include("State").Select(x => new { x.CountryName, x.CountryId, States = x.States.Select( y=>new { y.StateId,y.StateName }) }).ToList();
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
