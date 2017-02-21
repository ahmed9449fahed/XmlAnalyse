using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using XmlAnalyser.Business;

namespace XmlAnalyser.Test
{
    [TestFixture]
    public class StructureAnalyserTest
    {
        [Test]
        public void AhmedLerntUnitTest()
        {
        }

        [Test]
        public void NullInputTest()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                var result = XmlParser.Execute(null);
            });
        }

        [Test]
        public void SimpleDataTest()
        {
            var content = XDocument.Parse(@"<Test><Child>Value1</Child><Child>Value2</Child></Test>");
            var result = XmlParser.Execute(content);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Test");
            Assert.AreEqual(result.Childs.Count(), 2);
            var child = result.Childs.FirstOrDefault();
            Assert.IsNotNull(child);
            Assert.AreEqual(child.Data.Count(), 2);
        }


        [Test]
        public void SimpleSameNodeNamesTest()
        {
            var content = XDocument.Parse(@"<Test><Child></Child><Child></Child></Test>");
            var result = XmlParser.Execute(content);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Test");
            Assert.AreEqual(result.Childs.Count(), 1);
        }
    }
}