using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentNode.Domain.Models
{
    public class SaveFoodData
    {
        public string FoodDescription { get; set; }

        public int Quantity { get; set; }

        public string Rate { get; set; }

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        // Document info
        public string FileType { get; set; }           // pdf, docx, jpg, etc.
        public string FileBase64String { get; set; }
    }
}
