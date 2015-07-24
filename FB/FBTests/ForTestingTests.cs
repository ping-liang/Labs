using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FB;
using NUnit.Framework;
namespace FB.Tests
{
    [TestFixture()]
    public class ForTestingTests
    {
        [Test()]
        public void isValidTest()
        {
            FB.ForTesting test = new ForTesting();
            if (test.isValid("ping"))
            {
                Assert.Fail();
            }    
 
        }
    }
}
