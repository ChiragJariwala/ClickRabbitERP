
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
    {
        public class CustomerViewModel
        {
            [Key]
            public int CompID { get; set; }
            public string CompName { get; set; }
            public string Compphone { get; set; }
            public string Owner { get; set; }

            public DateTime Creationdate { get; set; }
            public DateTime Activationdate { get; set; }

            public string CompType { get; set; }
            public string RelType { get; set; }

        }
    }


