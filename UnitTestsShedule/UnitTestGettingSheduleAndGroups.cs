using Microsoft.VisualStudio.TestTools.UnitTesting;
 
using SharedSTANDARTLogic.Models;
using SharedSTANDARTLogic.Models.Resource;

namespace UnitTestsShedule
{
    [TestClass]
    public class UnitTestGettingSheduleAndGroups
    {
        private SheduleGetter SG = new SheduleGetter();
        [TestMethod]
        [DataRow("—œ-15")]
        [DataRow(" Ã")]
        public  void TestGettingGroups(string value)
        {
 
            SheduleRequest result =   SG.GetGroups(value);
         
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGettingShedule()
        {
          Assert.IsNotNull(SG.GetShedule("","","—œ-156","21.10.2018","29.10.2018"));
        }
    }
}
