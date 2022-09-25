using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationPractice;
using System;



namespace AutomationPractice
{
    [TestClass]
    public class automationpracticetest
    {
        [TestInitialize]
        public void Init()
        {

            TestArguments parameters = new TestArguments();

            int a = int.Parse(parameters.browser);

            Driver.Initialize(a);
        }
        [TestMethod]
        public void TestMethod1()
        {
            string subject = "";
            string body = "";

            TestArguments parameters = new TestArguments();
            string URL = parameters.url;

            OpenUrl.GoTo(URL);

           string message = EcommSite.Registration("automation practice");
            string searchMessage = EcommSite.SearchProduct();
            
            if (!message.Contains("ERROR!!!") && (!searchMessage.Contains("ERROR!!!")))
            {
                subject = "Passed!!! " + subject;
                body = "Test je prosao!!!" + "\n" + message + searchMessage;
            }
            else
            {
                subject = "Failed!!! " + subject;
                body = message + searchMessage;
            }
            Assert.IsTrue(subject.Contains("Passed"));
            Assert.IsFalse(subject.Contains("Failed"));
        }

    }
}