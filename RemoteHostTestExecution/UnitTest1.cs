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

        private const string PathToNUnitTest = @"c:\Users\Eugene\source\repos\LeetCodeZigZag\ZigZagTest\bin\Debug";

        [Test]
        public void TestMethod1()
        {
            using (var operatingSystem = new RemoteEnvironment(Ip, UserName, Password,
                @"c:\Users\Eugene\source\repos\PSTools\PsExec.exe"))
            {

                // Copy nUnit test to Guest PC
                operatingSystem.CopyFileFromHostToGuest(
                    PathToNUnitTest+@"\ZigZagConversion.zip",
                    @"C:\_work");
                // Unzip nUnit test on Guest PC
                operatingSystem.WindowsShellInstance.DetachElevatedCommandInGuestNoRemoteOutput(
                    @"7z.exe x -aoa -oc:\_work\Output c:\_work\ZigZagConversion.zip", TimeSpan.FromSeconds(1));
                // Execute nUnit test on Guest PC
                operatingSystem.WindowsShellInstance.DetachElevatedCommandInGuestNoRemoteOutput(
                    @"nunit3-console --work=c:\_work\Output c:\_work\Output\ZigZagTest.dll", TimeSpan.FromSeconds(1));
                
                // Verify that nunit execution test result (TestResult.xml) exist in "c:\_work\Output"
                Assert.True(operatingSystem.FileExistsInGuest(@"c:\_work\Output\TestResult.xml"));

                // Copy Test Result from Guest to Host
                operatingSystem.CopyFileFromGuestToHost(
                    @"c:\_work\Output\TestResult.xml",
                    PathToNUnitTest);
            }
        }
    }
}
