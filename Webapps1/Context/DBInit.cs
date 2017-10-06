using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webapps1.Models;

namespace Webapps1.Context
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            LeggTilFlyplasser(context);
            LeggTilRuter(context);      
        }
        public void LeggTilRuter(DB context)
        {
            Flyplass Flyplasser = new Flyplass();
            List<Rute> ruter = new List<Rute>();
            String format1 = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy hh:mm");
            String format2 = DateTime.Now.AddDays(14).ToString("dd-MM-yyyy hh:mm");
            String format3 = DateTime.Now.AddDays(21).ToString("dd-MM/yyyy hh:mm");
            ruter.Add(new Rute()
            {
                Fra = context.Flyplasser.Find(1).By,
                Til = context.Flyplasser.Find(2).By,
                Avgang = format1,
                Ankomst = format2,
                Pris = 1890
            });
            ruter.Add(new Rute()
            {
                Fra = context.Flyplasser.Find(3).By,
                Til = context.Flyplasser.Find(4).By,
                Avgang = format1,
                Ankomst = format2,
                Pris = 1490
            });
            ruter.Add(new Rute()
            {
                Fra = context.Flyplasser.Find(5).By,
                Til = context.Flyplasser.Find(6).By,
                Avgang = format2,
                Ankomst = format3,
                Pris = 1890
            });
            foreach (Rute nyRute in ruter)
            {
                context.Ruter.Add(nyRute);
            }
            base.Seed(context);
            context.SaveChanges();
        }
        public void LeggTilFlyplasser(DB context)
        {
            List<Flyplass> flyPlasser = new List<Flyplass>();

            flyPlasser.Add(new Flyplass() { By = "Oslo" });
            flyPlasser.Add(new Flyplass() { By = "Trondheim" });
            flyPlasser.Add(new Flyplass() { By = "Stavanger" });
            flyPlasser.Add(new Flyplass() { By = "Bergen" });
            flyPlasser.Add(new Flyplass() { By = "Tromsø" });
            flyPlasser.Add(new Flyplass() { By = "Kristiansand" });

            foreach (Flyplass nyFlyplass in flyPlasser)
            {
                context.Flyplasser.Add(nyFlyplass);
            }
            base.Seed(context);
            context.SaveChanges();
        }
    }
}