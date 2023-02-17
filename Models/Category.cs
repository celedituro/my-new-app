using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Models
{
    public abstract class Category
    {
        public abstract String Name
        {
            get;
        }
    }

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