using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
{
    public class VendorViewModel
    {
        [Key]
        public int CompID { get; set; }
        public string CompName { get; set; }
        public string Compphone { get; set; }
        public string Owner { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime Creationdate { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime Activationdate { get; set; }

        public string CompType { get; set; }
        public string RelType { get; set; }

    }
}
