using LysSensorLib;
using System.Runtime.CompilerServices;

namespace SensorTestClass
{
    [TestClass]
    public sealed class LogEntryTest
    {
        [TestMethod]
        public void CreateObjectTest()
        {
            //arrange
            DateTime now = DateTime.Now;
            LogEntry logEntry = new LogEntry(now, 500, true, false);

            //assert 
            Assert.AreEqual(now, logEntry.TimeTurnedOn);
            Assert.AreEqual(500, logEntry.LightLevel);
            Assert.AreEqual(true, logEntry.IsDrawn);
            Assert.AreEqual(false, logEntry.LightsOn);

        }

        [TestMethod]
        public void ToStringTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(DateTime.Now, 300, false, true);
            //act
            var toStringResult = logEntry.ToString();
            //assert
            Assert.AreEqual("LogEntry [TimeTurnedOn = " + logEntry.TimeTurnedOn + ", OutsideLightLevel = " + logEntry.LightLevel
                    + "lux, CurtainOpened = " + logEntry.IsDrawn + "]", toStringResult);
        }

     
    }
}
