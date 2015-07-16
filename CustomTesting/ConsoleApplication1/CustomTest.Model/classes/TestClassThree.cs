using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomTesting.Attributes;

namespace CustomTesting.Model
{
    [TestClass]
    public class TestClassThree
    {
        [TestMethod]
        [Ignore]
        public void M1()
        {

        }
        [TestMethod]
        public void M2()
        {

        }
        [TestMethod]
        [Ignore]
        public void M3()
        {

        }
    }
}
