using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }



        #region Coruse-topic
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>(); 
        #endregion
    }
}
