using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.Models;

namespace TalentNode.Domain.interfaces
{
    public interface IUserAuthenticationRepository
    {
      public  Task<string> AuthenticateUser(UserDetails User);

    }
}
