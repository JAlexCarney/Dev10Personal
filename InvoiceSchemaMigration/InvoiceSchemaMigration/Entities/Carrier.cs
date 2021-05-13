using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSchemaMigration.Entities
{
    public class Carrier
    {
        // Table Properties
        public int CarrierID { get; set; }
        public string CarrierName { get; set; }

        // Navigation Properties
        public List<Invoice> Invoices { get; set; }
    }
}
