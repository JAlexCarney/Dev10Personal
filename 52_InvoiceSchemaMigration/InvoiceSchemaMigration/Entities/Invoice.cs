using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSchemaMigration.Entities
{
    public class Invoice
    {
        // Table Properties
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int CarrierID { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public Carrier Carrier {get; set;}
    }
}
