using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly PathFinder.PathFinder _pathFinder;
        public UnitTest1()
        {
            _pathFinder = new PathFinder.PathFinder(PathFinder.SampleMaps.CreateSampleMap());
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = _pathFinder.GetShortestRoute('B', 'H');

            Assert.AreEqual('B', result[0].Name);
            Assert.AreEqual('D', result[1].Name);
            Assert.AreEqual('G', result[2].Name);
            Assert.AreEqual('H', result[3].Name);
            Assert.AreEqual(10, _pathFinder.GetDistance());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = _pathFinder.GetShortestRoute('D', 'H');

            Assert.AreEqual('D', result[0].Name);
            Assert.AreEqual('G', result[1].Name);
            Assert.AreEqual('H', result[2].Name);
            Assert.AreEqual(6, _pathFinder.GetDistance());
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = _pathFinder.GetShortestRoute('E', 'C');

            Assert.AreEqual('E', result[0].Name);
            Assert.AreEqual('B', result[1].Name);
            Assert.AreEqual('D', result[2].Name);
            Assert.AreEqual('C', result[3].Name);
            Assert.AreEqual(12, _pathFinder.GetDistance());
        }

        [TestMethod]
        public void TestMethod4()
        {
            var result = _pathFinder.GetShortestRoute('E', 'A');

            Assert.AreEqual('E', result[0].Name);
            Assert.AreEqual('B', result[1].Name);
            Assert.AreEqual('D', result[2].Name);
            Assert.AreEqual('C', result[3].Name);
            Assert.AreEqual('A', result[4].Name);
            Assert.AreEqual(14, _pathFinder.GetDistance());
        }

        [TestMethod]
        public void TestMethod5()
        {
            var result = _pathFinder.GetShortestRoute('A', 'E');

            Assert.AreEqual('A', result[0].Name);
            Assert.AreEqual('C', result[1].Name);
            Assert.AreEqual('D', result[2].Name);
            Assert.AreEqual('B', result[3].Name);
            Assert.AreEqual('E', result[4].Name);
            Assert.AreEqual(14, _pathFinder.GetDistance());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod6()
        {
            // Node 'I' does not exist, expect exception
            _pathFinder.GetShortestRoute('A', 'I');
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod7()
        {
            var path = new PathFinder.PathFinder(BrokenMaps.CreateSampleMap());
            // 'A' is disconnected, expect failure
            path.GetShortestRoute('H', 'A');
            // Should throw an exception because FindShortestRoute was unsuccessful
            path.GetDistance();
        }
    }
}
