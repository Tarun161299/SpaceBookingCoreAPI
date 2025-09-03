using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.interfaces;
using TalentNode.Domain.Models;

namespace TalentNode.Application.command
{
    public record UserAuthenticationCommand(UserDetails UserDetails) : IRequest<string>;

    public class UserAuthenticationCommandHandler(IUserAuthenticationRepository iemployeeRepository) : IRequestHandler<UserAuthenticationCommand, string>
    {
        

        public async Task<string> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
            return await iemployeeRepository.AuthenticateUser(request.UserDetails);
        }
    }
  
}
