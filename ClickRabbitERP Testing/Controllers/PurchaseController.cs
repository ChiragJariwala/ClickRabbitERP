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
using System.Text;

namespace ClickRabbitERP_Testing.Controllers
{
    [Authorize(Roles = "Admin,Purchase")]
    public class PurchaseController : Controller
    {
        //private readonly ERPDbContext _db;
        public int PRID;
        private readonly ERPDbContext _db;//danish panjuta
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHost;


        public PurchaseController(ERPDbContext db, IConfiguration configuration, IWebHostEnvironment webHost)
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
        public IActionResult PurchaseEntry(int? id)
        {

            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            List<VendorViewModel> vList;
            List<Item> ilist;
            vList = _db.VendorMaster.ToList();
            ilist = _db.ItemMaster.ToList();
            //ilist = ItemList;
            vList.Insert(0, new VendorViewModel { CompID = 0, CompName = "---Select Company---"});
            ilist.Insert(0, new Item { ProductCode = 0, ProductName = "---Select Items---" });
            ViewBag.ActList = vList;
            ViewBag.ilist = ilist.AsEnumerable().ToList();
            if (id == null || id == 0)
            {
                //var ItemList = (from u in _db.ItemMaster select u).ToList();
                PurchaseOrderModel purchaseOrder = new PurchaseOrderModel();

                purchaseOrder.PurchaseLines.Add(new PurchaseLineModel() { DocLineNumber = 1000 ,CreationDate = DateTime.Today,TransactionID=0});

                purchaseOrder.CreationDate = DateTime.Today;
                purchaseOrder.PostingDate = DateTime.Today;
                purchaseOrder.DocumentDate = DateTime.Today;

                return View(purchaseOrder);
            }
            else
            {
                PurchaseOrderModel purchaseOrder = _db.PurchaseOrderMaster.Include(e => e.PurchaseLines).Where(po => po.POID == id).FirstOrDefault();
                if(purchaseOrder.PurchaseLines.Count == 0)
                {
                purchaseOrder.PurchaseLines.Add(new PurchaseLineModel() { DocLineNumber = 1000, CreationDate = DateTime.Today, TransactionID = 0 });

                }
                return View(purchaseOrder);
            }
            
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseEntry(PurchaseOrderModel purchaseOrder)
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            _db.Add(purchaseOrder);
            _db.SaveChanges();
            return RedirectToAction("PurchaseOrders");
        }


        public IActionResult updatePO(PurchaseOrderModel purchaseOrder)
        {
            
                _db.Update(purchaseOrder);
                _db.SaveChanges(); 
                 return RedirectToAction("PurchaseOrders");

        }

        [HttpPost]
        public IActionResult updatePOLine(PurchaseLineModel purchaseOrder)
        {
            _db.Update(purchaseOrder);
            _db.SaveChanges();
            return RedirectToAction("PurchaseOrders");

        }
        

        public IActionResult DeletePurchaseLines(int? id, string returnUrl)
        {
            bool result = false;
            PurchaseLineModel s = _db.PurchaseLineMaster.Where(x => x.TransactionID == id).SingleOrDefault();
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
                return RedirectToAction("PurchaseOrders");
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
        //            DateTime d = DateTime.ParseExact(dt.Rows[0]["PostingDate"].ToString(), "dd/mm/ yyyy", CultureInfo.InvariantCulture);

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
            if(id== null || id==0)
            {
                return NotFound();
            }
            var obj =_db.PurchaseOrderMaster.Find(id);
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
            var obj = _db.PurchaseOrderMaster.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PurchaseOrderMaster.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("PurchaseOrders");
        }

        public IActionResult PurchaseOrders()
        {
            List<PurchaseOrderModel> PoList;
            List<VendorViewModel> vlist;
            vlist = _db.VendorMaster.ToList();
            ViewBag.vlist = vlist;
            PoList = _db.PurchaseOrderMaster.ToList();
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

        [HttpGet]
        public JsonResult updateLineRate(int? cid)
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    con.Open();
            //    SqlDataAdapter da = new SqlDataAdapter("ItemDislplySelected", con);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    da.SelectCommand.Parameters.AddWithValue("POID", cid);
            //    da.Fill(dt);
            //    int price = Convert.ToInt32(dt.Rows[0]["ProducrPrice"].ToString());
            //    DataTableToJsonObj(dt);
            //}
            var list1 = _db.ItemMaster.Find(cid);
            //var output = [{ "id :" + price}];
            return Json(list1);
        }

        public string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
