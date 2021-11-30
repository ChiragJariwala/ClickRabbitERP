using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
    {
        public class SalesLineModel
        {
            [Key]
            public int TransactionID { get; set; }


            public int SourceNumber { get; set; }
            [ForeignKey("SourceNumber")]
            public virtual SalesOrderModel SalesOrderNumber { get; set; } //Importent


            [BindProperty, DataType(DataType.Date)]

            public DateTime CreationDate { get; set; }

            public string ProductID { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Can not be blank")]
            public int ProductQty { get; set; }
            public float ProducrPrice { get; set; }
            public int DocLineNumber { get; set; }
            public int SGST { get; set; }
            public int CGST { get; set; }
            public int QuantityToPost { get; set; }
            public int PostedQty { get; set; }
            // public virtual List<Item> PuschaseItems { get; set; } = new List<Item>();


        }
    }



