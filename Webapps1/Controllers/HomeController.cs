using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Webapps1.Models;

namespace Webapps1.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {
            List<Flyplass> listeFlyPlasser = db.Flyplasser.ToList();
            return View(listeFlyPlasser);        
        }
        public ActionResult ListeRuter()
        {
    
            List<Rute> listeRuter = db.Ruter.ToList();
            return View(listeRuter);
      
   
        }

        public ActionResult NyBillett(Billett nyBillett)
        {
         
            db.Billetter.Add(nyBillett);
            db.SaveChanges();
                //return RedirectToAction("Reservasjon"); 
            return View();
        }
        public ActionResult Reservasjon()
        {
            List<Reservasjon> alleReservasjoner = db.Reservasjoner.ToList();
            return View(alleReservasjoner);
        }

        [HttpPost]
        public string HentAlleRuter()
        {
        /*
           List<string> formatert = new List<string>();
           foreach(Rute r in alleRuter)
           {
               formatert.Add(r.Fra.ToString());
               formatert.Add(r.Til.ToString());
               formatert.Add(r.Avgang.ToString());
               formatert.Add(r.Ankomst.ToString());
               formatert.Add(r.Pris.ToString());
           }
        */
            List<Rute> alleRuter = db.Ruter.ToList();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleRuter);
            return json;
        }

        [HttpPost]
        public string HentValgteRuter(string fra, string til)
        {
            List<Rute> alleRuter = db.Ruter.ToList();
            List<Rute> valgteRuter = new List<Rute>();

            valgteRuter = alleRuter.Where(a => a.Fra.Equals(fra) && a.Til.Equals(til)).ToList();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(valgteRuter);
            return json;

        }
 
    }
}