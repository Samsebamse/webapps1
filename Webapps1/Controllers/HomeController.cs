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
            var rId = (int)(Session["ruteId"]);

            if (ModelState.IsValid)
            {
                Billett nyBillett = new Billett()
                {
                    Fornavn = billett.Fornavn,
                    Etternavn = billett.Etternavn,
                    RuteId = rId,
                };

                db.Billetter.Add(nyBillett);
                db.SaveChanges();
                var id = nyBillett.BillettId;
                return RedirectToAction("VisKvittering", new {id = id});
            }
           
            
            return View();
        }
        public ActionResult AvbrytBestilling()
        {
            Session["ruteId"] = null;
            Session.Remove("ruteId");
            return RedirectToAction("Index");
        }


        public ActionResult VisKvittering(int id)
        {
            Billett dinBillett = db.Billetter.Find(id);
            return View(dinBillett);
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