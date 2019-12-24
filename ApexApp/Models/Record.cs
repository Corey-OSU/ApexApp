using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ApexApp.Models
{
    public class Record
    {
        [DisplayName("Sold At")]
        public string soldAt { get; set; }

        [DisplayName("Sold To")]
        public string soldTo { get; set; }

        [DisplayName("Account Number")]
        public string acctNum { get; set; }

        [DisplayName("Invoice #")]
        public string invoiceNum { get; set; }

        [DisplayName("Customer PO #")]
        public string customerPoNum { get; set; }

        [DisplayName("Order Date")]
        public DateTime orderDate { get; set; }

        [DisplayName("Due Date")]
        public DateTime dueDate { get; set; }

        [DisplayName("Invoice Total")]
        public decimal invoiceTotal { get; set; }

        [DisplayName("Product Number")]
        public string productNum { get; set; }

        [DisplayName("Order Qty")]
        public int orderQty { get; set; }

        [DisplayName("Unit Net")]
        public decimal unitNet { get; set; }

        [DisplayName("Line Total")]
        public decimal lineTotal { get; set; }


    }
}