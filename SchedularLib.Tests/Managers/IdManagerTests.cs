using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchedularLib.Managers;

namespace SchedularLib.Tests.Managers
{
    [TestClass]
    public class IdManagerTests
    {
        [TestMethod]
        public void TestIdIncrement()
        {
            uint firstId = IdManager.GetId();
            uint secondId = IdManager.GetId();

            Assert.IsTrue(firstId + 1 == secondId);
        }

        [TestMethod]
        public void TestIdsDrop()
        {
            IdManager.DropIds();
            uint id = IdManager.GetId();

            Assert.AreEqual(1u, id);
        }
    }
}
