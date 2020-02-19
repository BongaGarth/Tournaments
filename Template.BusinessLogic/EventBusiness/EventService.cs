using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model.Models;
using Template.Model.ViewModels;
using Template.Service.UnitOfWork;

namespace Template.BusinessLogic.EventBusiness
{
    public class EventService : IEventService
    {
        public void AddEvent(EventModel model)
        {
            using (var unitofwork = new UnitOfWork())
            {
                unitofwork.EventRepository.Insert(new Data.Entities.Event { TournamentID = model.TournamentID, EventName = model.EventName, EvenStarTime = model.EvenStarTime, EventEndTime = model.EventEndTime, EventNumber = model.EventNumber, AutoClose = model.AutoClose }); ;
            }
        }
        public void Delete(int Id)
        {
            using (var unitofwork = new UnitOfWork())
            {
                var item = unitofwork.TournamentRepository.GetById(Id);
                if (item != null)
                {
                    unitofwork.TournamentRepository.Delete(item);
                }
            }
        }
        public List<EventViewModel> GetAllEvents()
        {
            using (var unitofwork = new UnitOfWork())
            {
                return unitofwork.EventRepository.GetAll().Select(x =>
                    new EventViewModel()
                    {
                        EventID = x.EventID,
                        EventName = x.EventName,
                        EvenStarTime = x.EvenStarTime,
                        EventEndTime = x.EventEndTime,
                        EventNumber = x.EventNumber,
                        Details = x.EventDetails.Select(p => new EventDetailsViewModel
                        {
                            EventDetailID = p.EventDetailID,
                            EventID = p.EventID,
                            EventDetailsName = p.EventDetailsName,
                            EventDetailNumber = p.EventDetailNumber,
                            EventOdd = p.EventOdd,
                            FinishingPosition=p.FinishingPosition,
                            FirstTimer=p.FirstTimer
                        }).ToList()
                    }).ToList();
            }
        }
        public EventViewModel GetById(int Id)
        {
            var tournament = new EventViewModel();
            using (var unitofwork = new UnitOfWork())
            {
                var item = unitofwork.EventRepository.GetById(Id);
                if (item != null)
                {
                    tournament.EventName = item.EventName;
                    tournament.EventNumber = item.EventNumber;
                    tournament.EvenStarTime = item.EvenStarTime;
                    tournament.EventEndTime = item.EventEndTime;
                }
                return tournament;
            }
        }
        public void AddDetails(EventDetailModel model)
        {
           
            using (var unitofwork = new UnitOfWork())
            {
                var item = unitofwork.EventRepository.GetById(model.EventID);
                if (item != null)
                {
                    item.EventDetails.Add(new Data.Entities.EventDetail {
                        EventDetailID=model.EventDetailID,
                        EventID=model.EventID,
                        EventDetailNumber=model.EventDetailNumber,
                        EventDetailsName=model.EventDetailsName,
                        EventOdd=model.EventOdd,
                        FinishingPosition=model.FinishingPosition,
                        FirstTimer=model.FirstTimer,
                    });
                }
                unitofwork.EventRepository.Update(item);
            }
        }
    }
}
