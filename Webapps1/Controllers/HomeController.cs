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
            List<Rute> listeRuter = db.Ruter.ToList();
            return View(listeRuter);        
        }
        public ActionResult ListeRuter()
        {
            List<Rute> listeRuter = db.Ruter.ToList();
            return View(listeRuter);
        }

        public ActionResult NyBillett(int ruteId)
        {
            
            Session["ruteId"] = ruteId;

            return View();
        }

        [HttpPost]
        public ActionResult NyBillett(Billett billett)
        {
            var id = Convert.ToInt32(Session["ruteId"]);

            if (ModelState.IsValid)
            {
                Billett nyBillett = new Billett()
                {
                    Fornavn = billett.Fornavn,
                    Etternavn = billett.Etternavn,
                    RuteId = id,
                };

                db.Billetter.Add(nyBillett);
                db.SaveChanges();
                return RedirectToAction("ListeBilletter");
            }
           
            
            return View();
        }
        
        public ActionResult ListeBestillinger()
        {
            var alleBestillinger = from o in db.Billetter join o2 in db.Ruter on o.BillettId equals o2.RuteId where o.RuteId.Equals(o2.RuteId) select new Bestillinger { };
            return View(alleBestillinger);
        }

        [HttpPost]
        public string HentAlleRuter()
        {
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

            valgteRuter = alleRuter.Where(a => a.Fra.Equals(fra, StringComparison.CurrentCultureIgnoreCase) && a.Til.Equals(til, StringComparison.CurrentCultureIgnoreCase)).ToList();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(valgteRuter);
            return json;

        }
    }
}