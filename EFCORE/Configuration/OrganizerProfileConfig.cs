using EFCORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE.OrganizerProfileConfig
{
    internal class OrganizerProfileConfig : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.Biography).HasMaxLength(100);
            builder.Property(p => p.Website).HasMaxLength(300);
            builder.Property(p => p.Logo) .HasMaxLength(500);
            builder.HasOne(p => p.Organizer) .WithOne(o => o.Profile).HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        }

    }
    
}
