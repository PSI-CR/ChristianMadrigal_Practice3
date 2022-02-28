using NUnit.Framework;
using System;
using WpfApp1.Business;

namespace UnitTestProject1.Business_Test
{
    [TestFixture]
    public class FilterSobel_Test
    {
        [Test]

        public void FilterSobelImageNull_Test()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => FilterSobel.ApplicateFilterSobel(null));
            Assert.That(ex.Message, Is.EqualTo("No Image. Please Load Image."));
        }

    }
}
