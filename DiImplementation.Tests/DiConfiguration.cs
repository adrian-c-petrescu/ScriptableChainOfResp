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
    public class DiConfiguration
    {

        [TestCase(typeof(ILocalDataGetter))]
        [TestCase(typeof(IRemoteDataGetter))]
        [TestCase(typeof(IDataMergeService))]
        public void ShouldResolveType(Type type)
        {
            var obj = IoC.Resolve(type);
            Assert.IsNotNull(obj);
            Assert.IsTrue(type.IsAssignableFrom(obj.GetType()));
        }
    }
}
