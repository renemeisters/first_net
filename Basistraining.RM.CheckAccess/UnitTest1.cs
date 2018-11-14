using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basistrainig.RM.DataAccess;

using System.Linq;

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

                var p =  context.Person.ToList();
                Assert.IsNotNull(p.Count);
               
            }
        }

        [TestMethod]
        public void testPerson()
        {
            var pers = Comm.Person.GetPerson();
            Assert.IsNotNull(pers.Count);
        }
    }
}
