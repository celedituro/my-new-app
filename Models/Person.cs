
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
        public string FirstName { get; set; } = " ";
        
        [Required]
        public string LastName { get; set; } = " ";

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [NotMapped]
        private Category? Category { get; set; }

        [Column("Category")]
        public String? CategoryName { get; private set; }

        public void TransitionTo(Category category)
        {
            this.CategoryName = category.Name;
            this.Category = category;
            this.Category.SetContext(this);
        }

        public void GetOlder()
        {
            if(this.Category is not null)
            {
                this.Category.GetOlder();
            }
        }
    }
}