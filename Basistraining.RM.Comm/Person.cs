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

        public static Int64 Erstellen(string first, string last)
        {
            Basistrainig.RM.DataAccess.Person pers = new Basistrainig.RM.DataAccess.Person();
            pers.FirstName = first;
            pers.LastName = last;
            //if (reservation.Spielername == null || reservation.Spielername == "") reservation.Spielername = "leer";

            using (var context = new SchoolEntities())
            {
                context.Person.Add(pers);
                //TODO Check ob mit null möglich, sonst throw Ex
               
                context.SaveChanges();
                return pers.PersonID;
            }
        }
        public static void Aktualisieren(Basistrainig.RM.DataAccess.Person p)
        {
            using (var context = new SchoolEntities())
            {
                //TODO null Checks?
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
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
