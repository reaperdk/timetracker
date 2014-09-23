using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Model;
using TimeTracker.Repository;

namespace TimeTracker.ClassService
{
    public class SlotsService : ISlotsService
    {
        private IEntitiesRepository<SlotModel> _repository;
        private readonly Func<IEntitiesRepository<SlotModel>> _getRepository;

        public SlotsService()
        {
            _getRepository = () => new EntitiesRepository<SlotModel>();
        }
        public SlotsService(Func<IEntitiesRepository<SlotModel>> getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<SlotModel> GetAll()
        {
            using (_repository = _getRepository())
            {
                return _repository.Get().ToArray();
            }
        }

        public SlotModel GetById(int id)
        {
            using (_repository = _getRepository())
            {
                return _repository.Get(id);
            }
        }

        public void Create(SlotModel slot)
        {
            using (_repository = _getRepository())
            {
                _repository.Insert(slot);
                _repository.Save();
            }
        }

        public void Update(SlotModel slot)
        {
            using (_repository = _getRepository())
            {
                SlotModel toUpdate = _repository.Get(item => item.Id == slot.Id).First();
                toUpdate.Name = slot.Name;
                toUpdate.StartDate = slot.StartDate;
                toUpdate.FinishDate = slot.FinishDate;
                toUpdate.TaskId = slot.TaskId;
                _repository.Update(toUpdate);
                _repository.Save();
            }
        }

        public void Delete(int id)
        {
            using (_repository = _getRepository())
            {
                _repository.Remove(id);
                _repository.Save();
            }
        }
    }
}
