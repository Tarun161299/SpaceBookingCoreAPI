using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentNode.Domain.Entities
{
    public class Booking
    { 
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string NoOfGuest { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string SpecialRequest{get; set;}

            
    }
}
