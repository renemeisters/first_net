﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basistrainig.RM.DataAccess;

using System.Linq;
using System.Collections.Generic;

namespace Basistraining.RM.CheckAccess
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            // Datenbank Zugriff öffnen und schliessen
            using (var context = new SchoolEntities())
            {

                Assert.IsNotNull(context);

                var p = context.Person.ToList();
                Assert.IsNotNull(p.Count);
         
         
            }
        }

        [TestMethod]
        public void testPerson()
        {
            var pers = Comm.Person.GetPerson();
            Assert.IsNotNull(pers.Count);
        }

        //[TestMethod]
        //public void checkDelete()
        //{

        //    using (var context = new SchoolEntities())
        //    {



        //        var p = context.Person.ToList();
        //        Comm.Person.Delete(p[1]);

        //    }
        //}


        [TestMethod]
        public void checkCreate()
        {
            using(var context = new SchoolEntities())
            {
                var pers = new Comm.Person();
                pers.firstname = "Marcel";
                pers.lastname = "Schmutz2";
                var people = context.Person.ToList();
                int count = people.Count();
                pers.Save();
                var peopleAfter = context.Person.ToList();
                int countAfter = peopleAfter.Count();
                Assert.AreNotEqual(count, countAfter);
            }
        }

        public void CheckDelet()
        {

        }
    }
}
