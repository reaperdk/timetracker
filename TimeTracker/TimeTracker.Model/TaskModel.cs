using System;

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
        public int AssignedPersonId { get; set; }
        public int AssigningPersonId { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
