using NUnit.Framework;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant_DCITest
{
    public class PlaceAnOrderContex_RoleMethodsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<CartItem> list;
            list =PlaceAnOrderRoleMethods.GetCart(new SessionManager());
            Assert.AreEqual(0, list.Count());
        }
    }
}
