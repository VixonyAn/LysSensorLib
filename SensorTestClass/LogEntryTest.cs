using LysSensorLib;

namespace SensorTestClass
{
    [TestClass]
    public sealed class LogEntryTest
    {
        [TestMethod]
        public void CreateObjectTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(500, true, false);

            //assert 
            Assert.AreEqual(500, logEntry.OutsideLightLevel);
            Assert.AreEqual(true, logEntry.CurtainOpened);
            Assert.AreEqual(false, logEntry.LightOn);

        }

        [TestMethod]
        public void ToStringTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(300, false, true);
            //act
            var toStringResult = logEntry.ToString();
            //assert
            Assert.AreEqual("LogEntry [TimeTurnedOn = " + logEntry.TimeTurnedOn + ", OutsideLightLevel = " + logEntry.OutsideLightLevel
                    + "lux, CurtainOpened = " + logEntry.CurtainOpened + "]", toStringResult);
        }

        [TestMethod]
        public void TestFail() 
        {
            throw new NotImplementedException();
        }
    }
}
