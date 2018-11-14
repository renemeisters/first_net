using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basistraining.RM.Web.Models
{
    public class PersonViewModel
    {
        List<Comm.Person> pers = Comm.Person.GetPerson();
    }
}