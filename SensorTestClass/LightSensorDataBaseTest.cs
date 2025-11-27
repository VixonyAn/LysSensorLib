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
            var AllData = _lightSensorDatabase.GetAll();
            var LastEntry = AllData.Last();
            //assert 
            Assert.AreEqual(logEntry, LastEntry);
        }
        [TestMethod]
        public void GetAllTest()
        {
            //act 
            var AllData = _lightSensorDatabase.GetAll();
            //Assert
            Assert.IsNotNull(AllData);
        }
        [TestMethod] 
        public void GetByIdTest()
        {
            //act 
            var AllData = _lightSensorDatabase.GetAll();
            var LastEntry = AllData.Last();
            var RetrievedEntry = _lightSensorDatabase.GetById(LastEntry.Id);
            //Assert
            Assert.AreEqual(LastEntry, RetrievedEntry);
        }

        [TestMethod]
        public void DeleteObjectTest()
        {
            //act 
            var AllData = _lightSensorDatabase.GetAll();
            var LastEntry = AllData.Last();
            _lightSensorDatabase.Delete(LastEntry.Id);
            var DeletedEntry = _lightSensorDatabase.GetById(LastEntry.Id);
            //Assert
            Assert.IsNull(DeletedEntry);

        }
    }
}
