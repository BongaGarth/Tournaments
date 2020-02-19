using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Entities
{
    public class EventDetailStatus
    {
        [Key]
        public int EventDetailStatusID { get; set; }

        [ForeignKey("EventDetails")]
        public int EventDetailsID { get; set; }
        public string EventDetailStatusName { get; set; }
        public virtual EventDetail EventDetails { get; set; }
    }
}
