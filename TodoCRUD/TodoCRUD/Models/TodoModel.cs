using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoCRUD.Models
{
    public enum TodoStatus { NOT_STARTED, IN_PROGRESS, FINISHED };
    public class TodoModel
    {
        [Key]
        public int TodoId { get; set; }
        public int? TodoIdParent { get; set; }
        [DisplayName("Status")]
        public TodoStatus TodoStatus { get; set; }
        [DisplayName("Tytuł")]
        public string TodoTitle { get; set; }
        [DisplayName("Opis")]
        public string TodoDescription { get; set; }
    }
}
