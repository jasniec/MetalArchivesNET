using MetalArchivesNET.Attributes;
using MetalArchivesNET.Attributes.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace MetalArchivesNET.Tests
{
    /// <summary>
    /// These tests tells us if enum converters for parsing JSON responses are working correctly
    /// </summary>
    [TestClass]
    public class AttributesTests
    {
        [TestMethod]
        public void RegexConverterOk()
        {
            RegexConverterAttribute regex = new RegexConverterAttribute(@"http://(.*)");
            TestDecorator valueProvider = new TestDecorator("http://example.com");

            regex.SetDecorator(valueProvider);
            string actual = (string)regex.GetValue();

            Assert.AreEqual("example.com", actual);
        }

        [TestMethod]
        public void EnumConverterLiternalOk()
        {
            EnumConverterAttribute enumConverter = new EnumConverterAttribute(typeof(TestEnum));
            TestDecorator valueProvider = new TestDecorator("TestValue1");

            enumConverter.SetDecorator(valueProvider);
            TestEnum actual = (TestEnum)enumConverter.GetValue();

            Assert.AreEqual(TestEnum.TestValue1, actual);
        }

        [TestMethod]
        public void EnumConverterDescriptionOk()
        {
            EnumConverterAttribute enumConverter = new EnumConverterAttribute(typeof(TestEnum));
            TestDecorator valueProvider = new TestDecorator("DescriptionValue1");

            enumConverter.SetDecorator(valueProvider);
            TestEnum actual = (TestEnum)enumConverter.GetValue();

            Assert.AreEqual(TestEnum.DescVal1, actual);
        }
    }

    class TestDecorator : FieldDecoratorBase
    {
        private string _value;

        public TestDecorator(string value)
        {
            _value = value;
        }
        public override object GetValue()
        {
            return _value;
        }
    }

    enum TestEnum
    {
        TestValue1,
        [Description("DescriptionValue1")]
        DescVal1,
    }

}
