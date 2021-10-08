using BikeSharingAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace BikeSharingAPI.Test
{
    public class HelperXMLTest
    {
        [Fact]
        public void ToXMLTest()
        {
            string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?><SampleXMLClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Header>TestHeader</Header><IntElement>-12</IntElement><SubClasses TestStringAttribute=\"TestStringAttribute0\" TestIntAttribute=\"0\"><SubHeader>TestSubHeader0</SubHeader><SubIntElement>0</SubIntElement></SubClasses><SubClasses TestStringAttribute=\"TestStringAttribute1\" TestIntAttribute=\"1\"><SubHeader>TestSubHeader1</SubHeader><SubIntElement>1</SubIntElement></SubClasses></SampleXMLClass>";

            SampleXMLClass sampleXMLClass = new SampleXMLClass();
            sampleXMLClass.Header = "TestHeader";
            sampleXMLClass.IntElement = -12;

            sampleXMLClass.SubClasses = new SampleXMLSubClass[2];

            sampleXMLClass.SubClasses[0] = new SampleXMLSubClass();
            sampleXMLClass.SubClasses[1] = new SampleXMLSubClass();

            sampleXMLClass.SubClasses[0].TestStringAttribute = "TestStringAttribute0";
            sampleXMLClass.SubClasses[0].TestIntAttribute = 0;
            sampleXMLClass.SubClasses[1].TestStringAttribute = "TestStringAttribute1";
            sampleXMLClass.SubClasses[1].TestIntAttribute = 1;

            sampleXMLClass.SubClasses[0].SubHeader = "TestSubHeader0";
            sampleXMLClass.SubClasses[0].SubIntElement = 0;
            sampleXMLClass.SubClasses[1].SubHeader = "TestSubHeader1";
            sampleXMLClass.SubClasses[1].SubIntElement = 1;

            string result = HelperXML.TOXML<SampleXMLClass>(sampleXMLClass);

            Assert.Equal(expected, result);
        }

        public class SampleXMLClass
        {
            [XmlElement("Header")]
            public string Header { get; set; }

            [XmlElement("IntElement")]
            public int IntElement { get; set; }

            [XmlElement("SubClasses")]
            public SampleXMLSubClass[] SubClasses { get; set; }

        }

        public class SampleXMLSubClass
        {
            [XmlAttribute("TestStringAttribute")]
            public string TestStringAttribute { get; set; }

            [XmlAttribute("TestIntAttribute")]
            public int TestIntAttribute { get; set; }

            [XmlElement("SubHeader")]
            public string SubHeader { get; set; }

            [XmlElement("SubIntElement")]
            public int SubIntElement { get; set; }
        }
    }
}
