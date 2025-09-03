using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentNode.Domain.Entities
{
   
        public class FoodCategoryMaster
        {
            [Key]
            [Required]
            [MaxLength(50)]
            public string CategoryId { get; set; }  // now a string PK

            [Required]
            [MaxLength(200)]
            public string CategoryName { get; set; }
        }
  

}
