using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.Models;

namespace TalentNode.Domain.Entities
{
    public class UserRoleMapping
    {
      
        public string UserName { get; set; }
        
        public int RoleId { get; set; }
    }
}
