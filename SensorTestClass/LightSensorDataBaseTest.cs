using LysSensorLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTestClass
{
    [TestClass]
    [DoNotParallelize]
    public sealed class LightSensorDataBaseTest
    {
        //Remember "Should fail" Tests!!! c: 

        private static LightSensorRepositoryDB _lightSensorDatabase;

        [TestInitialize]
        public void Init()
        {
            var optionBuilder = new DbContextOptionsBuilder<LightSensorDBContext>();
            optionBuilder.UseSqlServer(Secret.ConnectionString);
            LightSensorDBContext _context = new LightSensorDBContext(optionBuilder.Options);
            _lightSensorDatabase = new LightSensorRepositoryDB(_context);
        }

        [TestMethod, Priority(1)]
        [DoNotParallelize]
        public void AddObjectTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(DateTime.Now, 500, true, false);
            //act
            _lightSensorDatabase.Add(logEntry);
            var AllData = _lightSensorDatabase.Get();
            var LastEntry = AllData.Last();
            //assert 
            Assert.AreEqual(logEntry, LastEntry);
        }
		[TestMethod, Priority(2)]
		[DoNotParallelize]
		public void GetAllTest()
        {
            //act 
            var AllData = _lightSensorDatabase.Get();
            //Assert
            Assert.IsNotNull(AllData);
        }
		[TestMethod, Priority(3)]
		[DoNotParallelize]
		public void GetFilteredTest()
		{
			//Arrange DD/MM/YYYY HH:MM:SS
			LightSensorRepositoryDB DB = _lightSensorDatabase;
            LogEntry log1 = new LogEntry(DateTime.Now, 50000, true, false); log1.TimeTurnedOn.AddDays(2);
			LogEntry log2 = new LogEntry(DateTime.Now, 70000, true, false); log2.TimeTurnedOn.AddDays(1);
			LogEntry log3 = new LogEntry(DateTime.Now, 4000, false, true); log3.TimeTurnedOn.AddDays(3);
            DB.Add(log1); DB.Add(log2); DB.Add(log3);


            //Act
            var AllData = DB.Get(null,false);
            var firstEntry = AllData.First();
			var lastEntry = AllData.Last();

            //Assert
            Assert.AreEqual(firstEntry, log2);
            Assert.AreEqual(lastEntry, log3);
		}
		[TestMethod, Priority(4)]
		[DoNotParallelize]
		public void GetByIdTest()
        {
            //act 
            var AllData = _lightSensorDatabase.Get();
            var LastEntry = AllData.Last();
            var RetrievedEntry = _lightSensorDatabase.GetById(LastEntry.Id);
            //Assert
            Assert.AreEqual(LastEntry, RetrievedEntry);
        }

        [TestMethod, Priority(5)]
		[DoNotParallelize]
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
