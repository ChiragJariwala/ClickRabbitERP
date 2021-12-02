using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ClickRabbitERP_Testing.Controllers
{
    [Authorize]
    public class VendorsController : Controller
    {
        private readonly ERPDbContext _db;//danish panjuta
        private readonly IConfiguration _configuration;

        public VendorsController(IConfiguration configuration, ERPDbContext db)
        {
            this._configuration = configuration;
            this._db = db;
        }
        [Authorize(Roles = "Admin,Purchase")]
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("vendorAll", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);

            }
            return View(dt);

            //List<VendorViewModel> Vendors;
            //Vendors = _db.VendorMaster.ToList();
            //return View(Vendors);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create(int? id)
        {
            VendorViewModel VendorModel = new VendorViewModel();
            if (id > 0)
            {
                VendorModel = FetchItemByID(id);
            }
            return View(VendorModel);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, [Bind("CompID,CompName,Compphone,Owner,Creationdate,Activationdate,CompType,RelType")] VendorViewModel VendorModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("VendorAddorEdit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CompID", VendorModel.CompID);
                    cmd.Parameters.AddWithValue("CompName", VendorModel.CompName);
                    cmd.Parameters.AddWithValue("Compphone", VendorModel.Compphone);
                    cmd.Parameters.AddWithValue("Owner", VendorModel.Owner);
                    cmd.Parameters.AddWithValue("Creationdate", VendorModel.Creationdate);
                    cmd.Parameters.AddWithValue("Activationdate", VendorModel.Activationdate);
                    cmd.Parameters.AddWithValue("CompType", VendorModel.CompType);
                    cmd.Parameters.AddWithValue("RelType", VendorModel.RelType);
                    cmd.ExecuteNonQuery();

                }
                return View(VendorModel);
            }
            return View(VendorModel);
        }



        [NonAction]
        public VendorViewModel FetchItemByID(int? id)
        {
            VendorViewModel itemmodel = new VendorViewModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("VendorDislplySelected", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("CompID", id);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    itemmodel.CompID = Convert.ToInt32(dt.Rows[0]["CompID"].ToString());
                    itemmodel.CompName = dt.Rows[0]["CompName"].ToString();
                    itemmodel.Compphone = dt.Rows[0]["Compphone"].ToString();
                    itemmodel.Owner = dt.Rows[0]["Owner"].ToString();
                    CultureInfo cul = new CultureInfo("en-US");
                    itemmodel.Creationdate = Convert.ToDateTime(dt.Rows[0]["Creationdate"], cul); 
                    itemmodel.Activationdate = Convert.ToDateTime(dt.Rows[0]["Activationdate"],cul);
                    itemmodel.CompType = dt.Rows[0]["CompType"].ToString();
                    itemmodel.RelType = (dt.Rows[0]["RelType"].ToString());
                
                }
                return itemmodel;

            }

        }

     

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var obj = _db.VendorMaster.Find(id);
            _db.VendorMaster.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}

