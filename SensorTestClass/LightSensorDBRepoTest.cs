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
    public sealed class LightSensorDBRepoTest
    {
        //Remember "Should fail" Tests!!! c: 

        private LightSensorRepositoryDB _repoDB;
        private IPiDataRepositoryDB _piRepo;

        [TestInitialize]
        public void Init()
        {
            var optionBuilder = new DbContextOptionsBuilder<LightSensorDBContext>();
            optionBuilder.UseSqlServer(Secret.ConnectionString);
            LightSensorDBContext _context = new LightSensorDBContext(optionBuilder.Options);
            _repoDB = new LightSensorRepositoryDB(_context, _piRepo);
        }

        [TestMethod, Priority(1)]
        [DoNotParallelize]
        public void AddObjectTest()
        {
            Thread.Sleep(1000);
            //arrange 
            LogEntry logEntry = new LogEntry(1764763357, 500, true, false);
            //act
            int beforeCount = _repoDB.Get().Count();
            _repoDB.ManualAdd(logEntry);
            int afterCount = _repoDB.Get().Count();

            //assert 
            Assert.AreEqual(beforeCount,afterCount-1);
        }
		[TestMethod, Priority(2)]
		[DoNotParallelize]
		public void GetAllTest()
        {
            //act 
            var AllData = _repoDB.Get();
            //Assert
            Assert.IsNotNull(AllData);
        }

		[TestMethod, Priority(3)]
        [DoNotParallelize]
		public void GetFilteredTest()
		{
            // Previous Test

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

            // Current Working Test

            var AllData = _repoDB.Get(null, false).ToList();
            long lastEntry = 0;
            foreach (var entry in AllData)
            {
                if (entry.TimeTurnedOn < lastEntry && entry.TimeTurnedOn != lastEntry)
                {
                    throw new AssertFailedException("Entries are not in ascending order by TimeTurnedOn");
                }
                else
                {
                    lastEntry = entry.TimeTurnedOn;
                }
            }
        }
		[TestMethod, Priority(4)]
		[DoNotParallelize]
		public void GetByIdTest()
        {
            //act 
            var AllData = _repoDB.Get();
            var LastEntry = AllData.Last();
            var RetrievedEntry = _repoDB.GetById(LastEntry.Id);
            //Assert
            Assert.AreEqual(LastEntry, RetrievedEntry);
        }

        [TestMethod, Priority(5)]
		[DoNotParallelize]
		public void DeleteObjectTest()
        {
            //act 
            var AllData = _repoDB.Get();
            var LastEntry = AllData.Last();
            _repoDB.Delete(LastEntry.Id);
            var DeletedEntry = _repoDB.GetById(LastEntry.Id);
            //Assert
            Assert.IsNull(DeletedEntry);

        }
    }
}
