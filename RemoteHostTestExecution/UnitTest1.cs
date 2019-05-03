using JetBrains.OsTestFramework;
using NUnit.Framework;


namespace RemoteHostTestExecution
{
    [TestFixture]
    public class UnitTest1
    {

        private const string Ip = "192.168.0.84";
        private const string UserName = "nunittest";
        private const string Password = "123456";

        [Test]
        public void TestMethod1()
        {
            var operatingSystem = new RemoteEnvironment(Ip, UserName, Password, @"c:\Users\\Eugene\source\repos\PSTools\PsExec.exe");
            operatingSystem.CopyFileFromHostToGuest(@"c:\Users\Eugene\source\repos\LeetCodeZigZag\ZigZagTest\bin\Debug\ZigZagConversion.zip", @"C:\_work");
            //Console.WriteLine(operatingSystem.GuestEnvironmentVariables.Count);

        }
    }
}
