using NUnit.Framework;
using WarmUpMay20;

namespace WarmUp.Tests
{
    public class Tests
    {
        [TestCase("4103432323", "6957678787")]
        [TestCase("4103438970", "6957672135")]
        [TestCase("4104305768", "6956750342")]
        [TestCase("4102204351", "6958856709")]
        [TestCase("4107056043", "6953504567")]
        [TestCase("4105753410", "6950307695")]
        [TestCase("appleSuace", "")]
        public void ShouldDecode(string input, string output)
        {
            var decoded = Decoder.Decode(input);
            Assert.AreEqual(output, decoded);
        }
    }
}