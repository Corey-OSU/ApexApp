using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.UI.WebControls;
using ApexApp.Models;


namespace ApexApp.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Report()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Report(DateTime startDate, DateTime endDate)
        {
            //GetRecords(startDate, endDate);
            return View(GetRecords(startDate, endDate));
            //return View();
        }


        public IList<Record> GetRecords(DateTime startDate, DateTime endDate)
        {

            using (SalesRecordDataContext db = new SalesRecordDataContext(new SqlConnection(Databases.AdventureWorksConnectionString)))
            {
               


                var result = (from soh in db.SalesOrderHeaders
                    where soh.OrderDate >= startDate && soh.OrderDate <= endDate
                    join store in db.Stores on soh.SalesPersonID equals store.SalesPersonID
                    join sod in db.SalesOrderDetails on soh.SalesOrderID equals sod.SalesOrderID
                    join cust in db.Customers on soh.CustomerID equals cust.CustomerID
                    join prod in db.Products on sod.ProductID equals prod.ProductID
                    join person in db.Persons on cust.PersonID equals person.BusinessEntityID
                    orderby soh.DueDate

                    select new Record()
                    {
                        soldAt = store.Name,
                        soldTo = person.FirstName + " " + person.LastName,
                        acctNum = cust.AccountNumber,
                        invoiceNum = soh.SalesOrderNumber,
                        customerPoNum = soh.PurchaseOrderNumber,
                        orderDate = soh.OrderDate,
                        dueDate = soh.DueDate,
                        invoiceTotal = soh.TotalDue,
                        productNum = prod.ProductNumber,
                        orderQty = sod.OrderQty,
                        unitNet = sod.UnitPrice - sod.UnitPriceDiscount, //Assumed this was what this line represents
                        lineTotal = sod.LineTotal

                    }).ToList();


                var testing2 = result; 

                return result;
            }



        }
    }
}


