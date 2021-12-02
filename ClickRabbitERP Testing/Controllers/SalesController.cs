
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClickRabbitERP_Testing.Controllers
{
    [Authorize(Roles = "Admin,Sales")]
    public class SalesController : Controller
    {
        //private readonly ERPDbContext _db;
        public int PRID;
        private readonly ERPDbContext _db;//danish panjuta
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHost;


        public SalesController(ERPDbContext db, IConfiguration configuration, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IncomingDocs()
        {

            return View();
        }


        [HttpGet]
        public IActionResult SalesEntry(int? id)
        {

            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            List<CustomerViewModel> vList;
            List<Item> ilist;
            vList = _db.CustomerMaster.ToList();
            ilist = _db.ItemMaster.ToList();
            //ilist = ItemList;
            vList.Insert(0, new CustomerViewModel { CompID = 0, CompName = "select" });
            ilist.Insert(0, new Item { ProductCode = 0, ProductName = "select" });
            ViewBag.ActList = vList;
            ViewBag.ilist = ilist.AsEnumerable().ToList();
            if (id == null || id == 0)
            {
                //var ItemList = (from u in _db.ItemMaster select u).ToList();
                SalesOrderModel salesorder = new SalesOrderModel();



                salesorder.SalesLines.Add(new SalesLineModel() { DocLineNumber = 1000, CreationDate = DateTime.Today, TransactionID = 0 });

                salesorder.CreationDate = DateTime.Today;
                salesorder.PostingDate = DateTime.Today;
                salesorder.DocumentDate = DateTime.Today;

                return View(salesorder);
            }
            else
            {
                SalesOrderModel salesorder = _db.SalesOrderMaster.Include(e => e.SalesLines).Where(po => po.SOID == id).FirstOrDefault();
                if (salesorder.SalesLines.Count == 0)
                {
                    salesorder.SalesLines.Add(new SalesLineModel() { DocLineNumber = 1000, CreationDate = DateTime.Today, TransactionID = 0 });

                }
                return View(salesorder);
            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalesEntry(SalesOrderModel salesorder)
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            if(salesorder.SOID == 0)
            {
            _db.Add(salesorder);
            }
            else
            {
                _db.Update(salesorder);

            }
            _db.SaveChanges();
            return RedirectToAction("Salesorder");
        }


        public IActionResult updatePO(SalesOrderModel salesorder)
        {

            _db.Update(salesorder);
            _db.SaveChanges();


            return RedirectToAction("Salesorder");

        }

        [HttpPost]
        public IActionResult updatePOLine(PurchaseLineModel salesorder)
        {
            _db.Update(salesorder);
            _db.SaveChanges();
            return RedirectToAction("Salesorder");

        }
        ////
        //public JsonResult DeletePurchaseLines(int? id)
        //{
        //    bool result = false;
        //    PurchaseLineModel s = _db.PurchaseLineMaster.Where(x => x.TransactionID == id).SingleOrDefault();
        //    if (s != null)
        //    {
        //        _db.Remove(s);
        //        _db.SaveChanges();
        //        result = true;
        //    }
        //    return Json(result);
        //}

        public IActionResult DeleteSalesLines(int? id, string returnUrl)
        {
            bool result = false;
            SalesLineModel s = _db.SalesLineMaster.Where(x => x.TransactionID == id).SingleOrDefault();
            if (s != null)
            {
                _db.Remove(s);
                _db.SaveChanges();
                result = true;
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Salesorder");
            }
        }

        ////
        //[NonAction]
        //public PurchaseViewModel FetchPurchaseOrdByID(int? id)
        //{
        //    PurchaseViewModel purchaseord = new PurchaseViewModel();
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("PurchaseOrderAddorEdit", con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("POID", id);
        //        da.Fill(dt);
        //        if (dt.Rows.Count == 1)
        //        {
        //            purchaseord.POID = Convert.ToInt32(dt.Rows[0]["POID"].ToString());
        //            purchaseord.VendorID = Convert.ToInt32(dt.Rows[0]["VendorID"].ToString());
        //            purchaseord.CreationDate = dt.Rows[0]["CreationDate"].ToString();
        //            purchaseord.CreationDate = DateTime.Now.ToShortDateString();
        //           // DateTime d = DateTime.ParseExact(dt.Rows[0]["PostingDate"].ToString(), "dd/mm/ yyyy", CultureInfo.InvariantCulture);

        //            purchaseord.PostingDate = dt.Rows[0]["PostingDate"].ToString();
        //            purchaseord.DocumentDate = (dt.Rows[0]["DocumentDate"].ToString());
        //            purchaseord.VendorOrderNumber = dt.Rows[0]["VendorOrderNumber"].ToString();
        //            purchaseord.VendorInvoiceNumber = dt.Rows[0]["VendorInvoiceNumber"].ToString();
        //            purchaseord.CreatedByUser = (dt.Rows[0]["CreatedByUser"].ToString());

        //        }
        //        return purchaseord;

        //    }

        //}
     

        public IActionResult DeletePo(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.SalesOrderMaster.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.SaveChanges();
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePoPost(int? id)
        {
            var obj = _db.SalesOrderMaster.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.SalesOrderMaster.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Salesorder");
        }

        public IActionResult Salesorder()
        {
            List<SalesOrderModel> PoList;
            PoList = _db.SalesOrderMaster.ToList();
            return View(PoList);
        }

        public IActionResult PostedPurchaseInvoice()
        {
            return View();
        }
        public IActionResult PostedCreditMemo()
        {
            return View();
        }
        public IActionResult BlancketOrders()
        {
            return View();
        }

        public IActionResult PurchaseRecipts()
        {
            return View();
        }

        public IActionResult ReturnOrders()
        {
            return View();
        }

        public IActionResult ReturnShipments()
        {
            return View();
        }

        public IActionResult PostedPurchaseReturnShipment()
        {
            return View();
        }


    }
}

