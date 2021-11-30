using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
    {
        public class SalesOrderModel
        {
            [Key]
            public int SOID { get; set; }

            public int CustomerID { get; set; }

            [BindProperty, DataType(DataType.Date)]
            public DateTime CreationDate { get; set; }


            [BindProperty, DataType(DataType.Date)]
            public DateTime PostingDate { get; set; }


            [BindProperty, DataType(DataType.Date)]
            public DateTime DocumentDate { get; set; }


            public string SalesOrderNumber { get; set; }
            public string CreatedByUser { get; set; }

            public virtual List<SalesLineModel> SalesLines { get; set; } = new List<SalesLineModel>();
            public virtual List<CustomerViewModel> Customers { get; set; } = new List<CustomerViewModel>();
            public virtual List<Item> Items { get; set; } = new List<Item>();
        }
    }


