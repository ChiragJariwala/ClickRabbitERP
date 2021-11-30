using Microsoft.AspNetCore.Mvc;
using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ClickRabbitERP_Testing.Controllers
{
    [Authorize]

    public class ItemsController : Controller
    {
        //private readonly ERPDbContext _db;//danish panjuta
        private readonly IConfiguration _configuration;

        public ItemsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        //public ItemsController(ERPDbContext db)
        //{
        //    _db = db;
        //}

        [Authorize]
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("ItemDislplyAll", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);

            }
            return View(dt);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create(int? id)
        {
            Item itemModel = new Item();
            if(id>0)
            {
                itemModel = FetchItemByID(id);
            }
            return View(itemModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(int id,[Bind("ProductCode,ProductName,MenuFacturerCode,CatagoryCode,TradePrice,ManufactureDiscount,ProductLicenceNumber,SGST,CGST,HSNCode")] Item itemModel)
        {
            if(ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ItemAddorEdit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ProductCode",itemModel.ProductCode);
                    cmd.Parameters.AddWithValue("ProductName", itemModel.ProductName);
                    cmd.Parameters.AddWithValue("MenuFacturerCode", itemModel.MenuFacturerCode);
                    cmd.Parameters.AddWithValue("CatagoryCode", itemModel.CatagoryCode);
                    cmd.Parameters.AddWithValue("TradePrice", itemModel.TradePrice);
                    cmd.Parameters.AddWithValue("ManufactureDiscount", itemModel.ManufactureDiscount);
                    cmd.Parameters.AddWithValue("ProductLicenceNumber", itemModel.ProductLicenceNumber);
                    cmd.Parameters.AddWithValue("SGST", itemModel.SGST);
                    cmd.Parameters.AddWithValue("CGST", itemModel.CGST);
                    cmd.Parameters.AddWithValue("HSNCode", itemModel.HSNCode);
                    cmd.ExecuteNonQuery();

                }
                return RedirectToAction("Index");
                //return View(itemModel);
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        public Item FetchItemByID(int? id)
        {
            Item itemmodel = new Item();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("ItemDislplySelected", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("ProductCode",id);
                da.Fill(dt);
                if(dt.Rows.Count == 1)
                {
                    itemmodel.ProductCode = Convert.ToInt32(dt.Rows[0]["ProductCode"].ToString());
                    itemmodel.ProductName = dt.Rows[0]["ProductName"].ToString();
                    itemmodel.MenuFacturerCode = dt.Rows[0]["MenuFacturerCode"].ToString();
                    itemmodel.CatagoryCode = Convert.ToInt32(dt.Rows[0]["CatagoryCode"].ToString());
                    itemmodel.TradePrice = Convert.ToInt32(dt.Rows[0]["TradePrice"].ToString());
                    itemmodel.ManufactureDiscount = Convert.ToInt32(dt.Rows[0]["ManufactureDiscount"].ToString());
                    itemmodel.ProductLicenceNumber = dt.Rows[0]["ProductLicenceNumber"].ToString();
                    itemmodel.ProductCode = Convert.ToInt32(dt.Rows[0]["ProductCode"].ToString());
                    itemmodel.SGST = Convert.ToInt32(dt.Rows[0]["SGST"].ToString());
                    itemmodel.CGST = Convert.ToInt32(dt.Rows[0]["CGST"].ToString());
                    itemmodel.HSNCode = Convert.ToInt32(dt.Rows[0]["HSNCode"].ToString());
                }
                return itemmodel;

            }

        }


    }
}
