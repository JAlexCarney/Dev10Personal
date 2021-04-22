using System;
using FileHelpers;

namespace LINQSamples.Core
{
    [DelimitedRecord(",")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [FieldConverter(ConverterKind.Date, "MM/dd/yyyy")]
        public DateTime BirthDate { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}