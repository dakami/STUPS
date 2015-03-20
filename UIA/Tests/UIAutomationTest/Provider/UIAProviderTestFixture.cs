﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/27/2012
 * Time: 11:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Provider
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UiaProviderTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="UiaProvider test")]
    public class UiaProviderTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void CheckProvider()
        {
            string name = "UiaProvider";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSProvider -PSProvider " + 
                name + 
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void CheckDefaultDrive()
        {
            string name = "UIA";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-PSDrive -Name " + 
                name +
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void CheckNewDriveByWindowName()
        {
            string driveName = "UIA1";
            string providerName = "UiaProvider";
            string rootpath = @"UIAutomation\UiaProvider::Services";
            string windowName = "Services";
            string processName = @"""""";
            int processId = 0;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId.ToString() + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void CheckNewDrivebyProcessName()
        {
            string driveName = "UIA2";
            string providerName = "UiaProvider";
            string rootpath = @"UIAutomation\UiaProvider::Services";
            string windowName = @"""""";
            string processName = "mmc";
            int processId = 0;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId.ToString() + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void CheckNewDriveByProcessId()
        {
            string driveName = "UIA3";
            string providerName = "UiaProvider";
            string rootpath = @"UIAutomation\UiaProvider::Services";
            string windowName = @"""""";
            string processName = @"""""";
            int processId = 1024;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-PSDrive -Name  " + 
                driveName +
                " -PSProvider " +
                providerName +
                " -Root " +
                rootpath +
                " -WindowName " +
                windowName +
                " -ProcessName " +
                processName +
                " -ProcessId " +
                processId.ToString() + 
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                driveName);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Provider")]
        public void RemoveDefaultDrive()
        {
            string driveName = "UIA";
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Remove-PSDrive -Name " + 
                driveName +
                "; (Get-PSDrive -Name " +
                driveName +
                ").Name;",
                // 20130207
                //"DriveNotFoundException",
                "AssertionFailureException",
                "An assertion failed.");
                //"Cannot find drive. A drive with the name " + 
                //driveName +
                //" does not exist.");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}