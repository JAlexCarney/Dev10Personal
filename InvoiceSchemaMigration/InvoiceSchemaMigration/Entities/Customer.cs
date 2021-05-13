using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSchemaMigration.Entities
{
    public class Customer
    {
        // Table Properties
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        // Navigation Properties
        public List<Invoice> Invoice { get; set; }
    }
}
