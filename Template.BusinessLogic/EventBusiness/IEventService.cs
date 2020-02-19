using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model.Models;
using Template.Model.ViewModels;

namespace Template.BusinessLogic.EventBusiness
{
    public interface IEventService
    {
        void AddEvent(EventModel model);
        List<EventViewModel> GetAllEvents();
        void Delete(int Id);
        EventViewModel GetById(int Id);
    }
}
