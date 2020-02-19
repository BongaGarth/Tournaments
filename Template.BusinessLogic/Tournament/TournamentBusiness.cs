using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model.ViewModels;
using Template.Service.UnitOfWork;

namespace Template.BusinessLogic.Tournament
{
    public class TournamentBusiness : ITournamentBusiness
    {
        public void AddTournament(TournamentModel model)
        {
            using (var unitofwork = new UnitOfWork())
            {
                unitofwork.TournamentRepository.Insert(new Data.Entities.Tournament { TournamentName = model.TournamentName, });
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
        public List<TournamentViewModel> GetAllTournaments()
        {
            using (var unitofwork = new UnitOfWork())
            {
                return unitofwork.TournamentRepository.GetAll().Select(x =>
                    new TournamentViewModel()
                    {
                        TournamentID = x.TournamentID,
                        TournamentName = x.TournamentName,
                        Events = x.Events.Select(p => new EventViewModel
                        {
                            EventID=p.EventID,
                            EvenStarTime = p.EvenStarTime,
                            EventName = p.EventName,
                            EventEndTime = p.EventEndTime,
                            EventNumber = p.EventNumber,
                            TournamentID=p.TournamentID,

                        }).ToList()
                    }).ToList();
            }
        }
        public TournamentViewModel GetById(int Id)
        {
            var tournament = new TournamentViewModel();
            using (var unitofwork = new UnitOfWork())
            {
                var item = unitofwork.TournamentRepository.GetById(Id);
                if (item != null)
                {
                    tournament.TournamentName = item.TournamentName;
                    tournament.TournamentID = item.TournamentID;
                }
                return tournament;
            }
        }
    }
}
