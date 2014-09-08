using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ClassService
{
    public interface ICategoriesService
    {
        void InitializeCategories();
        IEnumerable<CategoryModel> GetAll();
        CategoryModel Get(int id);
    }
}
