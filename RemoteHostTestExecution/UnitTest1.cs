using System;
using System.IO;
using System.Reflection;
using JetBrains.OsTestFramework;
using NUnit.Framework;


namespace RemoteHostTestExecution
{
    [TestFixture]
    public class UnitTest1
    {
        private readonly string _assemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).AbsolutePath);


        private const string Ip = "192.168.0.84";
        private const string UserName = "IEUser";
        private const string Password = "Passw0rd!";

        [Test()]
        public void TestMethod1()
        {

            var operatingSystem = new RemoteEnvironment(Ip, UserName, Password, Path.Combine(_assemblyDirectory, @"..\..\tools\PsExec.exe"));
            operatingSystem.CopyFileFromGuestToHost(@"C:\Downloads\7z920-x64.msi", @"C:\Temp");
            //Console.WriteLine(operatingSystem.GuestEnvironmentVariables.Count);

        }
    }
}
