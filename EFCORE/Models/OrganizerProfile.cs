using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.Models
{
    public class OrganizerProfile
    {
        public int Id { get; set; }

        public string? Biography { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        // Foreign Key
        public int OrganizerId { get; set; }

        // Navigation Property
        public Organizer Organizer { get; set; } = null!;
    }
}
