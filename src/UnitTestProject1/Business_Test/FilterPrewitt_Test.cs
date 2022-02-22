using NUnit.Framework;
using System;
using WpfApp1.Business;


namespace UnitTestProject1.Business_Test
{
    [TestFixture]
    public class FilterPrewitt_Test
    {
        [Test]

        public void FilterPresittImageNull ()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => FilterPrewitt.ApplicateFilterPrewitt(null));
            Assert.That(ex.Message, Is.EqualTo("No Image. Please Load Image."));
        }

    }
}
