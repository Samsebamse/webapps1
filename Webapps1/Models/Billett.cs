using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webapps1.Models
{
    public class Billett
    {
        [Key]
        public int BillettId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public virtual Reservasjon Reservasjon { get; set; }
    }
}