using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    class CategoryModel : IModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
