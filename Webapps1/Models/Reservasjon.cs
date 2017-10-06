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
        public List<Billett> Billetter { get; set; }
        public DateTime Bestilt { get; set; }
    }
}