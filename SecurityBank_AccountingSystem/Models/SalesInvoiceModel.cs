using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBank_AccountingSystem.Models
{
    class SalesInvoiceModel
    {
       // public int SalesInvoice { get; set; }
        public string Batch { get; set; }
        public string ChequeName { get; set; }
        public string ChkType { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }


    }
}
