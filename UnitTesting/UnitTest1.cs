using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_CaptureScreen()
        {
            NCSTest.Home homeObj = new NCSTest.Home();
            Bitmap output = homeObj.CaptureScreen();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void Test_ImageType()
        {
            NCSTest.Home homeObj = new NCSTest.Home();
            ImageCodecInfo output = homeObj.ImageType();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void Test_CompressionConfiguration()
        {
            NCSTest.Home homeObj = new NCSTest.Home();
            EncoderParameters output = homeObj.CompressionConfiguration();
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void Test_SaveImage()
        {
            NCSTest.Home homeObj = new NCSTest.Home();
            Bitmap input1 = homeObj.CaptureScreen();
            ImageCodecInfo input2 = homeObj.ImageType();
            EncoderParameters input3 = homeObj.CompressionConfiguration();
            bool output = homeObj.SaveImage(input1, input2, input3);
            Assert.IsTrue(output);
        }
    }
}
