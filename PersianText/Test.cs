using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersionText;

namespace PersianText
{
    public class Test
    {
        [TestMethod]
        public void Test_Persian_ToEnglishNumbers_Works()
        {
            var actual = "١٢٣".CleanString();
            Assert.AreEqual(expected: "123", actual: actual);
        }

        [TestMethod]
        public void Test_Arabic_ToEnglishNumbers_Works()
        {
            var actual = "\u06F1\u06F2\u06F3".CleanString();
            Assert.AreEqual(expected: "123", actual: actual);
        }

        [TestMethod]
        public void Test_Arabic_ToPersionKe_Works()
        {
            var actual = "كرمان خودرو".CleanString();
            Assert.AreEqual(expected: "کرمان خودرو", actual: actual);
        }

        [TestMethod]
        public void Test_Arabic_ToPersionYe_Work()
        {
            var actual = "برليان".CleanString();
            Assert.AreEqual(expected: "برلیان", actual: actual);
        }

    }
}
