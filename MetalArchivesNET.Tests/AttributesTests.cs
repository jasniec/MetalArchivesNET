using MetalArchivesNET.Attributes;
using MetalArchivesNET.Attributes.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void DateTimeConverterOk()
        {
            DateTimeConverterAttribute dateTimeConverter = new DateTimeConverterAttribute("yyyy-MM-dd");
            TestDecorator valueProvider = new TestDecorator("2019-10-14");

            dateTimeConverter.SetDecorator(valueProvider);
            DateTime actual = (DateTime)dateTimeConverter.GetValue();

            Assert.AreEqual(new DateTime(2019, 10, 14), actual);
        }

        [TestMethod]
        public void DateTimeAmericanConverterOk()
        {
            DateTimeConverterAttribute dateTimeConverter = new DateTimeConverterAttribute("MM/dd/yyyy");
            TestDecorator valueProvider = new TestDecorator("10/14/2019");

            dateTimeConverter.SetDecorator(valueProvider);
            DateTime actual = (DateTime)dateTimeConverter.GetValue();

            Assert.AreEqual(new DateTime(2019, 10, 14), actual);
        }

        [TestMethod]
        public void RegexReplaceOk()
        {
            RegexReplaceAttribute regexReplace = new RegexReplaceAttribute("https?://", "");
            TestDecorator valueProvider = new TestDecorator("http://example.com");

            regexReplace.SetDecorator(valueProvider);
            string actual = (string)regexReplace.GetValue();

            Assert.AreEqual("example.com", actual);
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
