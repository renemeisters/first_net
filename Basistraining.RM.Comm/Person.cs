using Basistrainig.RM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basistraining.RM.Comm
{
    public class Person
    {
        public int PersonID { get; set; }
        public string fullname { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }

        public static List<Person> GetPerson()
        {

            var people = new List<Person>();
            using (var context = new SchoolEntities())
            {
                          
                foreach(Basistrainig.RM.DataAccess.Person p in context.Person)
                {
                    people.Add(MapDataToPerson(p));
                }

            }


                return people;
        }

        public static Person GetPersonById(int id)
        {
            Person pers = new Person();
            using (var context = new SchoolEntities())
            {

                foreach (Basistrainig.RM.DataAccess.Person p in context.Person)
                {
                    if (id == p.PersonID)
                    {
                         pers = MapDataToPerson(p);
                    }

                }
                // context.Reservation.Include("Platz") where record.ReservationId == reservationId select
            }


            return pers;

        }



        private static Person MapDataToPerson(Basistrainig.RM.DataAccess.Person p)
        {
            return new Person()
            {
                PersonID = p.PersonID,
                fullname = $"{p.FirstName} {p.LastName}",
                firstname = p.FirstName,
                lastname = p.LastName
            };
            
        }

    

        public Person Save()
        {

            using (var context = new SchoolEntities())
            {
                context.Person.Add(MapPersonToData(this));
                //TODO Check ob mit null möglich, sonst throw Ex
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this;
            }
        }

        private static Basistrainig.RM.DataAccess.Person MapPersonToData(Basistraining.RM.Comm.Person p)
        {
            return new Basistrainig.RM.DataAccess.Person()
            {
                PersonID = p.PersonID,
                FirstName = p.firstname,
                LastName = p.lastname
            };

        }



        public static void Loeschen(Basistrainig.RM.DataAccess.Person p)
        {
            using (var context = new SchoolEntities())
            {
                context.Person.Attach(p);
                context.Person.Remove(p);
                context.SaveChanges();
            }
        }


    }
}
