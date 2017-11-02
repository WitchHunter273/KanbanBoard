
namespace Provider.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CaseType { get; set; }
    }
}
