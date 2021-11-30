using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Models
{
    public class ItemCategoryModel
    {
        [Key]
        public int CatgID { get; set; }
        public string CatgName { get; set; }
    }
}
