using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace my_new_app.Models
{
    [Keyless]
    public abstract class Category
    {
        public abstract String Name
        {
            get;
        }

        protected Person? _person;

        public void SetContext(Person person)
        {
            this._person = person;
        }

        public abstract void GetOlder();
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

        public override void GetOlder()
        {
            if(this._person is not null)
            {
                this._person.TransitionTo(new TeenCategory());
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

        public override void GetOlder()
        {
            if(this._person is not null)
            {
                this._person.TransitionTo(new AdultCategory());
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

        public override void GetOlder()
        {
            if(this._person is not null)
            {
                this._person.TransitionTo(new OctogenarianCategory());
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

        public override void GetOlder()
        {   
            if(this._person is not null)
            {
                this._person.TransitionTo(this);
            }
        }
    }
}