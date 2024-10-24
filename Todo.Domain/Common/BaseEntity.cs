
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
