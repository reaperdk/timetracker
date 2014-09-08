using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    [Table("Catygories")]
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
