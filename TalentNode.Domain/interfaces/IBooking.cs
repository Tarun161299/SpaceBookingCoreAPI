using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.Entities;
using TalentNode.Domain.Models;

namespace TalentNode.Domain.interfaces
{
    public interface IBooking
    {
        public Task<int> CreateAsync(BookingModel bookingDto);


    }
}
