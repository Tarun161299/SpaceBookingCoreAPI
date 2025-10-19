using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.Entities;
using TalentNode.Domain.interfaces;
using TalentNode.Domain.Models;
using TalentNode.Infrastructure.Data;

namespace TalentNode.Infrastructure.Repositories
{
    public class BookingRepository(TalentNodeDbContext dbContext) : IBooking
    {

      

        public async Task<int> CreateAsync(BookingModel bookingDto)
        {
            var booking = new Booking
            {
                Name = bookingDto.Name,
                Email = bookingDto.Email,
                Phone = bookingDto.Phone,
                NoOfGuest = bookingDto.NoOfGuest.ToString(),
                Date = bookingDto.Date, // Store only date part
                Time = bookingDto.Time,
                SpecialRequest =  bookingDto.SpecialRequest??"NA",
                
            };

            dbContext.Booking.Add(booking);
            return await dbContext.SaveChangesAsync();

        }

    }
}
