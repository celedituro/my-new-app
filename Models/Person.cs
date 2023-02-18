
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_new_app.Models
{   
    [Table("People")]
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; } = " ";

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [NotMapped]
        public Category? Category { get; private set; }

        [Column("Category")]
        public String? CategoryName { get; private set; }

        public void TransitionTo(Category category)
        {
            this.CategoryName = category.Name;
            this.Category = category;
            this.Category.SetContext(this);
        }
    }
}