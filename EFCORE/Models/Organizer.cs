using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.Models
{
    public class Organizer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        // One-to-One
        public OrganizerProfile? Profile { get; set; }

        // One-to-Many
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
