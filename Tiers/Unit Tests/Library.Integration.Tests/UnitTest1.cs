using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.Dts.Runtime;

namespace Library.Integration.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void RunPackage()
        {
            Application app = new Application();
            Package package = null;
            //Load the SSIS Package which will be executed
            package = app.LoadPackage(
                @"E:\Ekin\Documents\Visual Studio 2015\Projects\Integration Services Project1\Integration Services Project1\Package.dtsx", null);
            //Pass the varibles into SSIS Package
            //package.Variables["User::EmpCode"].Value = '1';
            //package.Variables["User::EmpName"].Value = "SANDEEP";
            //Execute the SSIS Package and store the Execution Result
            Microsoft.SqlServer.Dts.Runtime.DTSExecResult results = package.Execute();
            //Check the results for Failure and Success
            if (results == Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure)
            {
                string err = "";
                foreach (Microsoft.SqlServer.Dts.Runtime.DtsError local_DtsError in package.Errors)
                {
                    string error = local_DtsError.Description.ToString();
                    err = err + error;
                }
            }
            if (results == Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success)
            {
                string message = "Package Executed Successfully....";
            }
            //You can also return the error or Execution Result
            //return Error;
        }
    }
}
