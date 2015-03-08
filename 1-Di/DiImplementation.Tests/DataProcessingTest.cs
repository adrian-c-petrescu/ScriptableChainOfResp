using DiImplementation.Services;
using DiImplementation.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiImplementation.Tests
{
    [TestFixture]
    public class DataProcessingTest
    {
        [Test]
        public void TestLocalData()
        {
            var referenceData = new List<string> { "product1", "product2", "product3" };

            var localDataService = new LocalDataGetter();
            var data = localDataService.RetrieveLocalData("some customer");

            Assert.AreEqual(referenceData, data.SomeProducts);
        }

        [Test]
        public void TestRemoteData()
        {
            var referenceData = new List<string> { "product2", "product4" };

            var remoteDataService = new RemoteDataGetter();
            var data = remoteDataService.GetRemoteData("some customer");

            Assert.AreEqual(referenceData, data.SomeProducts);
        }

        [Test]
        public void TestMerge()
        {
            var referenceData = new List<string> { "product1", "product3", "product4"};
            //not mocking, becauwse we're working with hardcoded data anyway
            var mergeService = IoC.Resolve<IDataMergeService>();
            var mergedData = mergeService.MergeData("some customer");

            Assert.AreEqual(referenceData, mergedData.SomeProducts);
        }
    }
}
