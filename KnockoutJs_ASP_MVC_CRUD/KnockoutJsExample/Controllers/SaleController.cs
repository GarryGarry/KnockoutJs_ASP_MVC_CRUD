using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutJsExample.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.Entity;


namespace KnockoutJsExample.Controllers
{
    public class SaleController : Controller
    {

        databaseContext db = new databaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllSales()
        {
            using (databaseContext db = new databaseContext())
            {
                List<SalesViewModel> List = db.ProductSolds.Select(x => new SalesViewModel
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId,
                    StoreId =x.StoreId,
                    CName = x.Customer.CName,
                    PName = x.Product.PName,
                    SName = x.Store.SName,
                    DateSold = x.DateSold
                }).ToList();

                return Json(List, JsonRequestBehavior.AllowGet); 
            };
        }

        public ActionResult GetCustomers()
        {
            using (databaseContext db = new databaseContext())
            {
                var List = db.Customers.Select(x => new CustomerViewModel {
                    Id = x.Id,
                    CName = x.CName,
                    Address = x.Address
                }).ToList();

                return Json(List, JsonRequestBehavior.AllowGet);
            };
        }
        public ActionResult GetProducts()
        {
            using (databaseContext db = new databaseContext())
            {
                var List = db.Products.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    PName = x.PName,
                    Price = x.Price
                }).ToList();

                return Json(List, JsonRequestBehavior.AllowGet);
            };
        }

        public ActionResult GetStores()
        {
            using (databaseContext db = new databaseContext())
            {
                var List = db.Stores.Select(x => new StoreViewModel
                {
                    Id = x.Id,
                    SName = x.SName,
                    Address = x.Address
                }).ToList();

                return Json(List, JsonRequestBehavior.AllowGet);
            };
        }
        public ActionResult Save(ProductSold model)
        {

            var result = false;
            try
            {
                if (model.Id > 0)      //Updating
                {
                    ProductSold pro = db.ProductSolds.SingleOrDefault(x => x.Id == model.Id);

                    if (model.ProductId == 0)   //Changes not made for this field --- put a check here isempty isnull (value will be sent null from form if it has not been changed) if valkue is changed in form modal it will apear here
                    {
                        pro.ProductId = pro.ProductId;
                    }
                    else
                    {
                        pro.ProductId = model.ProductId;
                    }
                    if (model.CustomerId == 0)
                    {

                        pro.CustomerId = pro.CustomerId;
                    }
                    else
                    {

                        pro.CustomerId = model.CustomerId;
                    }
                    if (model.StoreId == 0)
                    {

                        pro.StoreId = pro.StoreId;
                    }
                    else
                    {

                        pro.StoreId = model.StoreId;
                    }
                    pro.DateSold = model.DateSold;
                    db.Entry(pro).State = EntityState.Modified;
                    db.SaveChanges();
                    result = true;

                }
                else     //Adding
                {
                    ProductSold pro = new ProductSold();
                    pro.ProductId = model.ProductId;
                    pro.CustomerId = model.CustomerId;
                    pro.StoreId = model.StoreId;
                    pro.DateSold = model.DateSold;
                    db.ProductSolds.Add(pro);                   
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}