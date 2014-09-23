using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface ISlotsService
    {
        IEnumerable<SlotModel> GetAll();
        SlotModel GetById(int id);
        void Create(SlotModel slot);
        void Update(SlotModel slot);
        void Delete(int id);
    }
}
