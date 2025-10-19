using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentNode.Domain.Models
{
    public class FoodData
    {
        public int Id { get; set; }
        public string FoodDescription { get; set; }
        public int Quantity { get; set; }
        public string Rate { get; set; }
        public string Category { get; set; }

        public string CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public string FileBase64String { get; set; }
        public string FileType { get; set; }
    }
}
