using LysSensorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTestClass
{
    [TestClass]
    public sealed class LightSensorDataBaseTest
    {
        //Remember "Should fail" Tests!!! c: 

        private readonly LightSensorDatabase _lightSensorDatabase;

        [TestMethod]
        public void AddObjectTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(500, true, false);
            //act
            _lightSensorDatabase.Add(logEntry);
            var AllData = _lightSensorDatabase.Get();
            var LastEntry = AllData.Last();
            //assert 
            Assert.AreEqual(logEntry, LastEntry);
        }
        [TestMethod]
        public void GetAllTest()
        {
            //act 
            var AllData = _lightSensorDatabase.Get();
            //Assert
            Assert.IsNotNull(AllData);
        }
		[TestMethod]
		public void GetFilteredTest()
		{
			//Arrange DD/MM/YYYY HH:MM:SS
			LightSensorDatabase DB = _lightSensorDatabase;
            LogEntry log1 = new LogEntry(50000, true, false); log1.TimeTurnedOn.AddDays(2);
			LogEntry log2 = new LogEntry(70000, true, false); log2.TimeTurnedOn.AddDays(1);
			LogEntry log3 = new LogEntry(4000, false, true); log3.TimeTurnedOn.AddDays(3);
            DB.Add(log1); DB.Add(log2); DB.Add(log3);


            //Act
            var AllData = DB.Get(null,false);
            var firstEntry = AllData.First();
			var lastEntry = AllData.Last();

            //Assert
            Assert.AreEqual(firstEntry, log2);
            Assert.AreEqual(lastEntry, log3);
		}
		[TestMethod] 
        public void GetByIdTest()
        {
            //act 
            var AllData = _lightSensorDatabase.Get();
            var LastEntry = AllData.Last();
            var RetrievedEntry = _lightSensorDatabase.GetById(LastEntry.Id);
            //Assert
            Assert.AreEqual(LastEntry, RetrievedEntry);
        }

        [TestMethod]
        public void DeleteObjectTest()
        {
            //act 
            var AllData = _lightSensorDatabase.Get();
            var LastEntry = AllData.Last();
            _lightSensorDatabase.Delete(LastEntry.Id);
            var DeletedEntry = _lightSensorDatabase.GetById(LastEntry.Id);
            //Assert
            Assert.IsNull(DeletedEntry);

        }
    }
}
