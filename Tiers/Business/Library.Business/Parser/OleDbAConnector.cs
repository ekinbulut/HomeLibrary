using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using Castle.Core.Internal;

namespace Library.Business.Parser
{
    /// <summary>
    /// 
    /// </summary>
    public static class OleDbAConnector
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public static string ConnectionStr;

        /// <summary>
        /// The sheet name
        /// </summary>
        public static string SheetName;

        /// <summary>
        /// Executes the OLE database connection.
        /// </summary>
        /// <returns></returns>
        public static DataTable ExecuteOleDbConnection()
        {

            var query = String.Format("Select * FROM [{0}$]", SheetName);
            var oldbadapter = new OleDbDataAdapter(query, ConnectionStr);

            var dataset = new DataSet();

            oldbadapter.Fill(dataset, "DataSet");

            return dataset.Tables["DataSet"];

        }

        /// <summary>
        /// Executes the OLE database connection.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DataTable ExecuteOleDbConnection(string[] parameters)
        {
            var strbuilder = new StringBuilder();
            parameters.ForEach(t =>
            {
                strbuilder.Append((string)t);
                strbuilder.Append(',');
            });

            var appendedline = strbuilder.ToString();

            var line = appendedline.Remove(appendedline.LastIndexOf(','));

            var query = String.Format("Select {0} FROM [{1}$]", line, SheetName);

            var oldbadapter = new OleDbDataAdapter(query, ConnectionStr);

            var dataset = new DataSet();

            oldbadapter.Fill(dataset, "DataSet");

            return dataset.Tables["DataSet"];

        }
    }
}
