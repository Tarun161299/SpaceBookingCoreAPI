using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentNode.Domain.Entities
{
    public class FoodMenu
    {
        public int Id { get; set; }

        public string FoodDescription { get; set; }

        public int Quantity { get; set; }

        public string Rate { get; set; }

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        

        // Foreign key reference to Document
        public int DocId { get; set; }
    }
}
