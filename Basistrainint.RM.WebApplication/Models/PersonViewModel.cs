using Basistrainig.RM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basistrainint.RM.WebApplication.Models
{
    public class PersonViewModel
    {
        public IEnumerable<Basistraining.RM.Comm.Person> people { get; set; }

        public PersonViewModel()
        {

            people =  Basistraining.RM.Comm.Person.GetPerson();
            
        }

        public void addPerson(string first, string last)
        {
            using (var context = new SchoolEntities())
            {
        
               /* Basistraining.RM.Comm.Person.Erstellen(first, last)*/;
                var p = context.Person.ToList();
            }
        }

        public void removePerson()
        {

        }

        public void changePerson()
        {

        }
    }
}