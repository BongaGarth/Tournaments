using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Entities;

namespace Template.Data.Configurations
{
    public class EventConfiguration
    {
        public EventConfiguration(DbModelBuilder modelBuilder)
        {
            //Event relationship configuration
            modelBuilder.Entity<EventDetail>().HasRequired(p => p.Event)
            .WithMany(c => c.EventDetails).HasForeignKey(r => r.EventID)
            .WillCascadeOnDelete(true);
        }
    }
}
