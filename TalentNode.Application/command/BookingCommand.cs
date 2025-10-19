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

        public record BookingCommand(BookingModel BookingModel) : IRequest<int>;

        public class BookingCommandHandler(IBooking BookingRepository) : IRequestHandler<BookingCommand, int>
        {


            public async Task<int> Handle(BookingCommand request, CancellationToken cancellationToken)
            {
                return await BookingRepository.CreateAsync(request.BookingModel);
            }
        }
}
