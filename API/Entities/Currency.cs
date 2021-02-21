using System;

namespace API.Entities
{
    public class Currency
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime UpdatedOn { get; set; }
        
    }
}