using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickRabbitERP_Testing.Models
{
    public class Item
    {
        [Key]
        public int ProductCode { get; set; }

        public String ProductName { get; set; }
        public String MenuFacturerCode { get; set; }
        public int CatagoryCode { get; set; }
        [ForeignKey("CatagoryCode")]
        public virtual ItemCategoryModel catgid { get; set; }
        public float TradePrice { get; set; }
        public float ManufactureDiscount { get; set; }
        public string ProductLicenceNumber{ get; set; }
        public float SGST{ get; set; }
        public float CGST { get; set; }
        public int HSNCode { get; set; }
    }
}
