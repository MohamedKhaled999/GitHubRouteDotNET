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
        [ForeignKey("Course")]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Course Course { get; set; }= new Course();
    }
}
