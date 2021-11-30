using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
{
    public class PurchaseOrderModel
    {
        [Key]
        public int POID { get; set; }

        public int VendorID{ get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }


        [BindProperty, DataType(DataType.Date)]
        public DateTime PostingDate { get; set; }


        [BindProperty, DataType(DataType.Date)]
        public DateTime DocumentDate { get; set; }


        public string VendorOrderNumber { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public string CreatedByUser { get; set; }

        public virtual List<PurchaseLineModel> PurchaseLines { get; set; } = new List<PurchaseLineModel>();
        public virtual List<VendorViewModel> Vendors{ get; set; } = new List<VendorViewModel>();
        public virtual List<Item> Items{ get; set; } = new List<Item>();
    }
}
