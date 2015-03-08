using AbstractDeserialization.DTOs;
using AbstractDeserialization.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserialization.Tests
{
    [TestFixture]
    public class PipelineTests
    {
        private const string jsonPipelineMetadata =
@"
{
    'OperType': 'DataMerge',
    'MaxResults': 5,

    'Source1': {
        'OperType': 'LocalDataGetter',
        'SomeOperationConfigurableParam': 512,
    },

    'Source2': {
        'OperType': 'RemoteDataGetter',
        'RemoteAddress': 'http://acme.org/restful/v1/data'
    }
}";

        [Test]
        public void TestJsonDeserialization()
        {
            
            //build the pipeline from json
            var pipeline = Bootstrapper.BuildPipelineFromJson(jsonPipelineMetadata);
            
            //do assertions on individual objects
            Assert.AreEqual(typeof(DataMerge), pipeline.GetType());
            var dm = (DataMerge)pipeline;
            Assert.IsTrue(dm.MaxResults != 0);

            Assert.AreEqual(typeof(LocalDataGetter), dm.Source1.GetType());
            var ldg = (LocalDataGetter)dm.Source1;
            Assert.IsTrue(ldg.SomeOperationConfigurableParam != 0m);

            Assert.AreEqual(typeof(RemoteDataGetter), dm.Source2.GetType());
            var rdg = (RemoteDataGetter)dm.Source2;
            Assert.IsNotNull(rdg.RemoteAddress);
        }


        [Test]
        public void TestPipelineExecution()
        {
            var pipeline = Bootstrapper.BuildPipelineFromJson(jsonPipelineMetadata);


            var referenceData = new List<string>{
                "product1",
                "product3",
                "product4"
            };

            var data = pipeline.Execute("123");

            Assert.AreEqual(referenceData, data.SomeProducts);
        }
    }
}
