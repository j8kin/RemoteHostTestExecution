using System;
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
            using (var operatingSystem = new RemoteEnvironment(Ip, UserName, Password,
                @"c:\Users\\Eugene\source\repos\PSTools\PsExec.exe"))
            {

                // Copy nUnit test to Guest PC
                operatingSystem.CopyFileFromHostToGuest(
                    @"c:\Users\Eugene\source\repos\LeetCodeZigZag\ZigZagTest\bin\Debug\ZigZagConversion.zip",
                    @"C:\_work");
                // Unzip nUnit test on Guest PC
                operatingSystem.WindowsShellInstance.DetachElevatedCommandInGuestNoRemoteOutput(
                    @"7z.exe x -aoa -oc:\_work\Output c:\_work\ZigZagConversion.zip", TimeSpan.FromSeconds(1));
                // Execute nUnit test on Guest PC
                //Console.WriteLine(operatingSystem.GuestEnvironmentVariables.Count);
            }
        }
    }
}
