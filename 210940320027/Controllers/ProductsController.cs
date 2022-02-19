using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _210940320027.Models;

namespace _210940320027.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            SqlConnection cn= new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;";
            cn.Open();

            
            SqlCommand selectcommand = new SqlCommand();
            selectcommand.Connection = cn;
            selectcommand.CommandType = System.Data.CommandType.StoredProcedure;
            selectcommand.CommandText = "[IndexSelect]";

            SqlDataReader dr = selectcommand.ExecuteReader();
            while(dr.Read())
            {
                list.Add(new Product { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() });
            }
            dr.Close();
            cn.Close();

            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;";
            cn.Open();

            Product obj = null;
            SqlCommand selectcommand = new SqlCommand();
            selectcommand.Connection = cn;
            selectcommand.CommandType = System.Data.CommandType.StoredProcedure;
            selectcommand.CommandText = "[FetchByProductId]";
            selectcommand.Parameters.AddWithValue("@ProductId", id);

            SqlDataReader dr = selectcommand.ExecuteReader();
            if (dr.Read())
                obj = new Product { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() };

            cn.Close();
            return View(obj);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;";
            cn.Open();

            
            SqlCommand Updatecommand = new SqlCommand();
            Updatecommand.Connection = cn;
            Updatecommand.CommandType = System.Data.CommandType.StoredProcedure;
            Updatecommand.CommandText = "[UpdateProduct]";

            Updatecommand.Parameters.AddWithValue("@ProductId", obj.ProductId);
            Updatecommand.Parameters.AddWithValue("@ProductName", obj.ProductName);
            Updatecommand.Parameters.AddWithValue("@Rate", obj.Rate);
            Updatecommand.Parameters.AddWithValue("@Description", obj.Description);
            Updatecommand.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

            try
            {
                // TODO: Add update logic here

                Updatecommand.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
