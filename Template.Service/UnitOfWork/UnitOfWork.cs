using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data;
using Template.Data.Entities;

namespace Template.Service.UnitOfWork
{
    public class UnitOfWork:    IDisposable
    {
        private DataContext context = new DataContext();


        private RepositoryService<Tournament> tournamentrepository;
        private RepositoryService<Event> eventrepository;
        private RepositoryService<EventDetail> eventdetailsrepository;
        private RepositoryService<EventDetailStatus> eventdetailsstatusrepository;



        public RepositoryService<Tournament> TournamentRepository
        {
            get
            {
                if(this.tournamentrepository == null)
                {
                    this.tournamentrepository = new RepositoryService<Tournament>(context);
                }
                return tournamentrepository;
            }
        }

        public RepositoryService<Event> EventRepository
        {
            get
            {
                if (this.eventrepository == null)
                {
                    this.eventrepository = new RepositoryService<Event>(context);
                }
                return eventrepository;
            }
        }
        public RepositoryService<EventDetail> EventDetailsRepository
        {
            get
            {
                if (this.eventdetailsrepository == null)
                {
                    this.eventdetailsrepository = new RepositoryService<EventDetail>(context);
                }
                return eventdetailsrepository;
            }
        }
        public RepositoryService<EventDetailStatus> EventDetailsStatusRepository
        {
            get
            {
                if (this.eventdetailsstatusrepository == null)
                {
                    this.eventdetailsstatusrepository = new RepositoryService<EventDetailStatus>(context);
                }
                return eventdetailsstatusrepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
