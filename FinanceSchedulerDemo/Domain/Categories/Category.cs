using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Categories
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
