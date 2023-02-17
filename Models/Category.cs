using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Models
{
    [NotMapped]
    public abstract class Category
    {
        public abstract String Name
        {
            get;
        }
    }
    [NotMapped]
    public class ChildCategory : Category
    {
        public const String CHILD = "Niño";
        public override string Name
        {
            get
            {
                return CHILD;
            }
        }
    }  

    [NotMapped]
    public class TeenCategory : Category
    {
        public const String TEEN = "Adolescente";
        public override string Name
        {
            get
            {
                return TEEN;
            }
        }
    }

    [NotMapped]
    public class AdultCategory : Category
    {
        public const String ADULT = "Adulto";
        public override string Name
        {
            get
            {
                return ADULT;
            }
        }
    }

    [NotMapped]
    public class OctogenarianCategory : Category
    {
        public const String OCTOGENARIAN = "Octogenario";
        public override string Name
        {
            get
            {
                return OCTOGENARIAN;
            }
        }
    }
}