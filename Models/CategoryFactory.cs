using System.ComponentModel.DataAnnotations.Schema;
using my_new_app.Models;

namespace my_new_app.Models
{
    [NotMapped]
    public class CategoryFactory
    {
        public const String CHILD = "Niño";
        public const String TEEN = "Adolescente";
        public const String ADULT = "Adulto";
        public const String OCTOGENARIAN = "Octogenario";

        private CategoryMapper mapper;
        private Dictionary<String, Category> categories;

        private Dictionary<String, Category> InitializeCategories()
        {
            Dictionary<String, Category> categories = new Dictionary<String, Category>();
            categories.Add(CHILD, new ChildCategory());
            categories.Add(TEEN, new TeenCategory());
            categories.Add(ADULT, new AdultCategory());
            categories.Add(OCTOGENARIAN, new OctogenarianCategory());
            
            return categories;
        }
 
        public CategoryFactory(CategoryMapper mapper)
        {
            this.mapper = mapper;
            this.categories = this.InitializeCategories();
        }

        public Category CreateCategory(DateOnly birth)
        {
            String name = this.mapper.Map(birth);
            return this.categories[name];
        }
    }
}