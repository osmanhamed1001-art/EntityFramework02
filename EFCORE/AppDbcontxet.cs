using EFCORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE
{
    internal class AppDbcontxet : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EF01G01;Trusted_connection=true;TrustServerCertificate=True");
        }
        public DbSet<Badge> Badgee { get; set; }
        public DbSet<Attendee> Attendeee { get; set; }
        public DbSet<Event> Eventt { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfilee { get; set; }
        public DbSet<Organizer> Organizerr { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Organizer>(D =>
            {

                D.ToTable("EventOrganizers");
                D.HasOne(O => O.Profile).WithOne(O => O.Organizer).HasForeignKey<OrganizerProfile>(C => C.OrganizerId);


            }
            );
            modelBuilder.Entity<Organizer>(C =>
            {

                C.HasMany(G => G.Events).WithOne(q => q.Organizer).HasForeignKey(t => t.OrganizerId);

            });
            modelBuilder.Entity<Attendee>(A =>
            {
                A.HasOne(a => a.Badge).WithOne(b => b.Attendee).HasForeignKey<Badge>(b => b.AttendeeId);
            });


            modelBuilder.Entity<Event>(builder =>
            {
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Title) .IsRequired()  .HasMaxLength(200);

                builder.Property(e => e.Description)  .IsRequired();

                builder.Property(e => e.StartDate) .IsRequired();

                builder.Property(e => e.EndDate) .IsRequired(false);

                builder.Property(e => e.MaxAttendees) .IsRequired();

            });


            modelBuilder.Entity<Badge>(builder =>
            {
                builder.HasKey(b => b.Id);

                builder.Property(b => b.BadgeNumber) .IsRequired();

                builder.HasIndex(b => b.BadgeNumber) .IsUnique();

                builder.Property(b => b.IssuedDate) .IsRequired();

                builder.Property(b => b.Tier) .IsRequired()  .HasMaxLength(20);

                builder.HasIndex(b => b.AttendeeId).IsUnique();
            });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
