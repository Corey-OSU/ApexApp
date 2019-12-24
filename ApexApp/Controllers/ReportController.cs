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
                //var result = (from soh in db.SalesOrderHeaders
                //              where soh.OrderDate >= startDate && soh.OrderDate <= endDate
                //              join store in db.Stores on soh.SalesPersonID equals store.SalesPersonID
                              
                             

                //              select new 
                //              {
                //                  //productID = sod.ProductID,
                //                  soldAt = store.Name,
                //                  //soldTo = person.FirstName + " " + person.LastName,
                //                  //acctNum = cust.AccountNumber,
                //                  invoiceNum = soh.SalesOrderNumber,
                //                  customerPoNum = soh.PurchaseOrderNumber,
                //                  orderDate = soh.OrderDate,
                //                  dueDate = soh.DueDate,
                //                  invoiceTotal = soh.TotalDue,
                //                  //productNum = prod.ProductNumber,
                //                  //orderQty = sod.OrderQty,
                //                  //unitNet = sod.UnitPrice - sod.UnitPriceDiscount, //Assumed this was what this line represents
                //                  //lineTotal = sod.LineTotal,
                //                  salesOrderID = soh.SalesOrderID

                //              }).ToList();


                

                //var result2 = (from x in result
                //    join sod in db.SalesOrderDetails on x.salesOrderID equals sod.SalesOrderID
                //    select new
                //    {
                //        productID = sod.ProductID,
                //        //customerID = soh.CustomerID,
                //        soldAt = x.soldAt,
                //        //soldTo = x.soldTo,
                //        //acctNum = x.acctNum,
                //        invoiceNum = x.invoiceNum,
                //        customerPoNum = x.customerPoNum,
                //        orderDate = x.orderDate,
                //        dueDate = x.dueDate,
                //        invoiceTotal = x.invoiceTotal,
                //        //productNum = prod.ProductNumber,
                //        orderQty = sod.OrderQty,
                //        unitNet = sod.UnitPrice - sod.UnitPriceDiscount, //Assumed this was what this line represents
                //        lineTotal = sod.LineTotal,
                //        salesOrderID = x.salesOrderID

                //    }).ToList();




                //var result3 = (from x in result2
                //    join soh in db.SalesOrderHeaders on x.salesOrderID equals soh.SalesOrderID
                //    select new
                //    {
                //        customerID = soh.CustomerID,
                //        soldAt = x.soldAt,
                //        //soldTo = x.soldTo,
                //        //acctNum = x.acctNum,
                //        invoiceNum = x.invoiceNum,
                //        customerPoNum = x.customerPoNum,
                //        orderDate = x.orderDate,
                //        dueDate = x.dueDate,
                //        invoiceTotal = x.invoiceTotal,
                //        //productNum = prod.ProductNumber,
                //        orderQty = x.orderQty,
                //        unitNet = x.unitNet,
                //        lineTotal = x.lineTotal,
                //        productID = x.productID
                //    }).ToList();


                //var result4 = (from x in result3
                //    join cust in db.Customers on x.customerID equals cust.CustomerID
                //    select new
                //    {
                //        soldAt = x.soldAt,
                //        //soldTo = x.soldTo,
                //        acctNum = cust.AccountNumber,
                //        invoiceNum = x.invoiceNum,
                //        customerPoNum = x.customerPoNum,
                //        orderDate = x.orderDate,
                //        dueDate = x.dueDate,
                //        invoiceTotal = x.invoiceTotal,
                //        //productNum = prod.ProductNumber,
                //        orderQty = x.orderQty,
                //        unitNet = x.unitNet,
                //        lineTotal = x.lineTotal,
                //        productID = x.productID,
                //        personID = cust.PersonID

                //    }).ToList();

                //var result5 = (from x in result4
                //    join person in db.Persons on x.personID equals person.BusinessEntityID
                //    select new
                //    {
                //        //customerID = x.customerID,
                //        soldAt = x.soldAt,
                //        soldTo = person.FirstName + " " + person.LastName,
                //        acctNum = x.acctNum,
                //        invoiceNum = x.invoiceNum,
                //        customerPoNum = x.customerPoNum,
                //        orderDate = x.orderDate,
                //        dueDate = x.dueDate,
                //        invoiceTotal = x.invoiceTotal,
                //        //productNum = prod.ProductNumber,
                //        orderQty = x.orderQty,
                //        unitNet = x.unitNet,
                //        lineTotal = x.lineTotal,
                //        productID = x.productID

                //    }).ToList();



                





                //var result6 = (from x in result5
                //    join prod in db.Products on x.productID equals prod.ProductID
                //    select new Record()
                //    {
                //        soldAt = x.soldAt,
                //        soldTo = x.soldTo,
                //        acctNum = x.acctNum,
                //        invoiceNum = x.invoiceNum,
                //        customerPoNum = x.customerPoNum,
                //        orderDate = x.orderDate,
                //        dueDate = x.dueDate,
                //        invoiceTotal = x.invoiceTotal,
                //        productNum = prod.ProductNumber,
                //        orderQty = x.orderQty,
                //        unitNet = x.unitNet, 
                //        lineTotal = x.lineTotal
                //    }).ToList();


                //var test = result2;







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


