using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomTesting.Attributes;

namespace CustomTesting.Model
{
    [TestClass]
    public class TestClassOne
    {
        [TestMethod,Category("Smoke Test")]
        public void M1()
        {

        }
        [TestMethod]
        public void M2()
        {

        }
        [TestMethod]
        public void M3()
        {

        }
    }
}

