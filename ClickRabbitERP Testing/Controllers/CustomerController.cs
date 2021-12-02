
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClickRabbitERP_Testing.Data;
using ClickRabbitERP_Testing.Models;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace ClickRabbitERP_Testing.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class CustomersController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ERPDbContext _db;//danish panjuta


        public CustomersController(IConfiguration configuration, ERPDbContext db)
        {
            this._configuration = configuration;
            this._db = db;
        }
        [Authorize(Roles ="Admin,Sales")]
        
        public IActionResult Index()
        {
            List<CustomerViewModel> customer;
            customer = _db.CustomerMaster.ToList();
        

           
            return View(customer);
        }
        [Authorize(Roles = "Admin")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(int? id)
        {
            CustomerViewModel VendorModel = new CustomerViewModel();
            if (id > 0)
            {
                VendorModel = FetchItemByID(id);
            }
            return View(VendorModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CustomerViewModel VendorModel)
        {
            if(VendorModel.CompID ==0)
            {
            _db.CustomerMaster.Add(VendorModel);
            }
            else
            {
                _db.CustomerMaster.Update(VendorModel);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult delete(CustomerViewModel Cust)
        {

            
            return RedirectToAction("Index");


        }
        ////
        //[HttpPost]
        //public IActionResult Create(int id, [Bind("CompID,CompName,Compphone,Owner,Creationdate,Activationdate,CompType,RelType")] CustomerViewModel VendorModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("CustomersAddorEdit", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("CompID", VendorModel.CompID);
        //            cmd.Parameters.AddWithValue("CompName", VendorModel.CompName);
        //            cmd.Parameters.AddWithValue("Compphone", VendorModel.Compphone);
        //            cmd.Parameters.AddWithValue("Owner", VendorModel.Owner);
        //            cmd.Parameters.AddWithValue("Creationdate", VendorModel.Creationdate);
        //            cmd.Parameters.AddWithValue("Activationdate", VendorModel.Activationdate);
        //            cmd.Parameters.AddWithValue("CompType", VendorModel.CompType);
        //            cmd.Parameters.AddWithValue("RelType", VendorModel.RelType);
        //            try
        //            {
        //                cmd.ExecuteNonQuery();

        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //        }
        //        return View(VendorModel);
        //    }
        //    return View(VendorModel);
        //}



        [NonAction]
        public CustomerViewModel FetchItemByID(int? id)
        {
            CustomerViewModel itemmodel = new CustomerViewModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("CustomersDislplySelected", con);
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
                    itemmodel.Activationdate = Convert.ToDateTime(dt.Rows[0]["Activationdate"], cul);
                    itemmodel.CompType = dt.Rows[0]["CompType"].ToString();
                    itemmodel.RelType = (dt.Rows[0]["RelType"].ToString());

                }
                return itemmodel;

            }

        }

        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int? id)
        {
            CustomerViewModel vm = new CustomerViewModel();
            return View(vm);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(CustomerViewModel vendor)
        {
            CustomerViewModel vn = _db.CustomerMaster.Where(x => x.CompID == vendor.CompID).First();
            _db.CustomerMaster.Remove(vn);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    
}


