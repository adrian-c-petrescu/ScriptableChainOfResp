using AbstractDeserWithVisitor.Bl;
using AbstractDeserWithVisitor.Bl.Utils;
using AbstractDeserWithVisitor.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDeserWithVisitor.Tests
{
    [TestFixture]
    public class PipelineWithVisitorTests
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
        public void TestJsonDeserializePlainObj()
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
        public void TestPlainObjectExecution()
        {
            var pipeline = Bootstrapper.BuildPipelineFromJson(jsonPipelineMetadata);

            //this class can be created by IoC
            //and the functionality can be delegated to other BL/Service classes
            var pipelineVisitor = new PipelineVisitor();

            var resultData = pipeline.Execute(pipelineVisitor, "the-cool-customer");

            var referenceData = new List<string> 
            {
                "product1",
                "product3",
                "product4"
            };

            Assert.AreEqual(referenceData, resultData.SomeProducts);
        }

    }
}
