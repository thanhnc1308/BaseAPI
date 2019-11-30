using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Model
{
    //[Table("")]
    public partial class TodoItem : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool? IsComplete { get; set; } = false;
        [StringLength(500)]
        public string Description { get; set; }
    }
}
