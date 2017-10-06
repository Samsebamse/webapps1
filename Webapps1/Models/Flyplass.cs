using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webapps1.Models
{
    public class Flyplass
    {
        [Key]
        public int FlyplassId { get; set; }
        public string By { get; set; }


    }

}