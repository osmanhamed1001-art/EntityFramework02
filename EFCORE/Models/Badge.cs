using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.Models
{
    public class Badge
    {
        public int Id { get; set; }

        public int BadgeNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public BadgeTiercs Tier { get; set; }

        // Foreign Key
        public int AttendeeId { get; set; }

        // Navigation Property
        public Attendee Attendee { get; set; } = null!;

    }
}
