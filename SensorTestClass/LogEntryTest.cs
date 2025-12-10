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
            
            LogEntry logEntry = new LogEntry(1764763357, 500, true, false);

            //assert 
            Assert.AreEqual(1764763357, logEntry.TimeTurnedOn);
            Assert.AreEqual(500, logEntry.LightLevel);
            Assert.AreEqual(true, logEntry.IsDrawn);
            Assert.AreEqual(false, logEntry.LightsOn);

        }

        [TestMethod]
        public void ToStringTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(1764763357, 300, false, true);
            //act
            var toStringResult = logEntry.ToString();
            //assert
            Assert.AreEqual("LogEntry [TimeTurnedOn = " + logEntry.TimeinDateTime + ", OutsideLightLevel = " + logEntry.LightLevel
                    + "lux, CurtainOpened = " + logEntry.IsDrawn + "]", toStringResult);
        }
    }
}
