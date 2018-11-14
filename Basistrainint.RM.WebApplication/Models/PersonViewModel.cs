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
    }
}