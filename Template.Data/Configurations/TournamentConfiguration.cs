using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Entities;

namespace Template.Data.Configurations
{
    public class TournamentConfiguration
    {
        public TournamentConfiguration(DbModelBuilder modelBuilder)
        {
            //Tournament relationship configuration
            modelBuilder.Entity<Event>().HasRequired(p => p.Tournament)
            .WithMany(c => c.Events).HasForeignKey(r => r.TournamentID)
            .WillCascadeOnDelete(true);
        }
    }
}
