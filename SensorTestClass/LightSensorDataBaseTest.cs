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
    public sealed class LightSensorDataBaseTest
    {
        //Remember "Should fail" Tests!!! c: 

        private LightSensorRepositoryDB _lightSensorDatabase;

        [TestInitialize]
        public void Init()
        {
            var optionBuilder = new DbContextOptionsBuilder<LightSensorDBContext>();
            optionBuilder.UseSqlServer(Secret.ConnectionString);
            LightSensorDBContext _context = new LightSensorDBContext(optionBuilder.Options);
            _lightSensorDatabase = new LightSensorRepositoryDB(_context);
        }

        [TestMethod]
        public void AddObjectTest()
        {
            //arrange 
            LogEntry logEntry = new LogEntry(500, true, false);
            //act
            int beforeCount = _lightSensorDatabase.Get().Count();
            _lightSensorDatabase.Add(logEntry);
            int afterCount = _lightSensorDatabase.Get().Count();

            //assert 
            Assert.AreEqual(beforeCount,afterCount-1 );
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
            /*LightSensorRepositoryDB DB = _lightSensorDatabase;
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
            */
            var AllData = _lightSensorDatabase.Get(null, false).ToList();
            DateTime lastentry = DateTime.MinValue;
            foreach (var entry in AllData)
            {
                if (entry.TimeTurnedOn < lastentry && entry.TimeTurnedOn != lastentry)
                {
                    throw new AssertFailedException("Entries are not in ascending order by TimeTurnedOn");
                }
                else
                {
                    lastentry = entry.TimeTurnedOn;
                }
            }
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
