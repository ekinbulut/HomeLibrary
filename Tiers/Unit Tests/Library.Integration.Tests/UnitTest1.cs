using System;
using System.Data;
using System.IO;
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

        [TestMethod]
        public void ReadCSVFile()
        {
            var table = ReadCSVFile($"E:\\Ekin\\Desktop\\Library.csv");
        }


        public DataTable ReadCSVFile(string filepath)
        {
            DataTable table = new DataTable();

            //Name	Author	Publisher	Series	Genre	PublishDate	No	Cilt	RackNumber	Shelf


            using (StreamReader reader = new StreamReader(filepath))
            {
                string Fulltext;
                while (!reader.EndOfStream)
                {
                    Fulltext = reader.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Length - 1; i++)  
                    {  
                        string[] rowValues = rows[i].Split(';'); //split each row with comma to get individual values  
                        {  
                            if (i == 0)  
                            {  
                                for (int j = 0; j < rowValues.Length; j++)  
                                {  
                                    table.Columns.Add(rowValues[j]); //add headers  
                                }  
                            }  
                            else  
                            {  
                                DataRow dr = table.NewRow();  
                                for (int k = 0; k < rowValues.Length; k++)  
                                {  
                                    dr[k] = rowValues[k].ToString();  
                                }  
                                table.Rows.Add(dr); //add other rows  
                            }  
                        }  
                    } 

                }

            }

            return table;

        }
    }
}
