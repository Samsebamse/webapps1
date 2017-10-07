using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webapps1.Models
{
    public class Reservasjon
    {
        [Key]
        public int ReservasjonId { get; set; }
        public DateTime Bestilt { get; set; }
        public virtual List<Billett> Billetter { get; set; }
    }
}