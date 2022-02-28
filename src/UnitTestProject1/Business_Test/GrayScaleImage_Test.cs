using NUnit.Framework;
using System;
using WpfApp1.Business;

namespace UnitTestProject1.Business_Test
{
    [TestFixture]
    public class GrayScaleImage_Test
    {
        [Test]

        public void GrayScaleImageNull_Test()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => GrayScaleImage.Grayscale(null));
            Assert.That(ex.Message, Is.EqualTo("No Image. Please Load Image."));
        }

    }
}
