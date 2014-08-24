using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Model
{
    public class TaskModel : IModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string TimeEstimate { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Filepath { get; set; }
        public int Version { get; set; }

        public int ProjectId { get; set; }
        public int AssignedPersonId { get; set; }
        public int AssigningPersonId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int TypeId { get; set; }

        public virtual ProjectModel Project { get; set; }
        //[ForeignKey("AssignedPersonId")]
        public virtual UserModel AssignedPerson { get; set; }
        //[ForeignKey("AssigningPersonId")]
        //public virtual UserModel AssigningPerson { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual StatusModel Status { get; set; }
        public virtual PriorityModel Priority { get; set; }
        public virtual TypeModel Type { get; set; }

        public virtual IEnumerable<SlotModel> Slots { get; set; }
    }
}
