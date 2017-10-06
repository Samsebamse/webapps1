using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webapps1.Models
{
    public class Rute
    {
        [Key]
        public int RuteId { get; set; }
        public virtual List<Billett> Billetter { get; set; }
        public string Fra { get; set; }    
        public string Til { get; set; }
        public string Avgang { get; set; }
        public string Ankomst { get; set; }
        public int Pris { get; set; }

    }
    
}